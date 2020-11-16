using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;


namespace EventShopApp
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DbConnection db;
        private List<Product> products;
        private double totalPrice = 0;
        private string rfidProduct;
        private int shopId;
        //private List<SoldProducts> soldProducts;

        public Form1()
        {
            InitializeComponent();
            db = new DbConnection();
            myRFIDReader = new RFID();
            products = new List<Product>();
            myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            myRFIDReader.Open();
            myRFIDReader.Attach += new AttachEventHandler(Attached);
            myRFIDReader.Detach += new DetachEventHandler(Detached);
        }
        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lbInfo.Items.Insert(0, "RFID Reader attached");
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lbInfo.Items.Insert(0,"RFID Reader detached");
           // lblItemName.Text = "";
            //lblPrice.Text = "";
        }

        public void ReadTagNewID(object sender, RFIDTagEventArgs e)
        {
            if (btnSell.Text == "SELL ITEMS")
            {
                db.ProductNamePrice(e.Tag);
                lblPrice.Text = db.Price.ToString();
                lblProduct.Text = db.Name.ToString();
                rfidProduct = e.Tag;
            }
            if (btnSell.Text == "SELL ITEMS" && lblProduct.Text != "not exist" && lblProduct.Text != "Name of product")
            {
                rfidProduct = e.Tag;
                shopId = db.SelectShopId(e.Tag);
               // Console.WriteLine("****** " + shopId);
            }
        }
        public void ReadTagUser(object sender, RFIDTagEventArgs e)
        {
            if (db.SelectUserId(e.Tag) > 0) {
                int userId = db.SelectUserId(e.Tag);
                double balance = db.SelectBalance(userId);
                if (balance >= db.Price)
                {
                    // lblTag.Text = e.Tag;
                  //  Console.WriteLine("********** " + balance);
                    balance = balance - totalPrice;
                      //Console.WriteLine("********** " + balance);
                    foreach (Product p in products) {
                        db.ProductQty(p.P_rfid);
                         //Console.WriteLine("********** " + db.Qty);
                        int qty = db.Qty - p.Qty;
                        //Console.WriteLine("********** " + qty);
                        lbInfo.Items.Insert(0,"BuyerRfid: " + e.Tag +" "+ p.Name + " Price: " + p.Price + " Quantity: " + p.Qty);
                        db.InsertTransction(userId, p.Qty, shopId, p.P_rfid, p.Price *p.Qty);
                       // Console.WriteLine("****** " + p.Qty + " " + qty + " " + shopId + " " + rfidProduct);
                        db.Paying(userId, balance);
                        db.UpdateQty(p.P_rfid, qty);
                    }
                    MessageBox.Show("Products sold successfully!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   // lblTag.Text = "";
                    //lblItemName.Text = "";
                   // lblPrice.Text = "";
                    btnSell.Text = "SELL ITEMS";
                    myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
                    myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
                    lblTotalPrice.Text = "0";
                    products.Clear();
                    lbSellList.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Buyer don't have enough credits!");
                }
            }
            else if (btnSell.Text == "SELL ITEMS")
            {
                MessageBox.Show("This item is out of stock!");
            }
            else
            {
                MessageBox.Show("This ticket does not exist!");
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (btnSell.Text == "CANCEL SELL")
            {
                //myRFIDReader.Open();
                //MessageBox.Show("Scan rfid!");
               // lblItemName.Text = "";
               // lblPrice.Text = "";
                btnSell.Text = "SELL ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            }
            else
            {
                btnSell.Text = "CANCEL SELL";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagNewID);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagUser);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int qty = -1;
            if (lblProduct.Text != "Name of product" || lblProduct.Text != "not exist") {
                db.ProductQty(rfidProduct);
                qty = db.Qty - Convert.ToInt32(nudAmount.Value);

            }
            if (lblProduct.Text != "not exist" && lblProduct != null && lblProduct.Text != "Name of product" && lblProduct.Text != "" && nudAmount.Value > 0 && db.Qty >= nudAmount.Value) {
                lbSellList.Items.Clear();
                products.Add(new Product(db.Rfid, lblProduct.Text, db.Price, Convert.ToInt32(nudAmount.Value)));
                TotalPrice();
                lblTotalPrice.Text = totalPrice.ToString();
                lblProduct.Text = "Name of product";
                lblPrice.Text = "$";
                nudAmount.Value = 0;
                foreach (Product p in products)
                {
                    lbSellList.Items.Insert(0, p.ToString());
                }
            }
            else if (lblProduct.Text == "Name of product" || lblProduct.Text == "not exist")
            {
                MessageBox.Show("Please make sure you scanned product!", "Item does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Please first enter quantity", "Quantity amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (qty < nudAmount.Value && lblProduct.Text != "not exist")
            {
                MessageBox.Show("Quantity of that product is currently: " + qty, "Stock info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudAmount.Value = qty;
            }
        }
        private void TotalPrice()
        {
            totalPrice = 0;
            foreach (Product p in products)
            {
               totalPrice = totalPrice + p.Price * p.Qty;
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selctedIndex = lbSellList.SelectedIndex;
            if (selctedIndex >= 0)
            {
                products.RemoveAt(lbSellList.SelectedIndex);
                TotalPrice();
                lblTotalPrice.Text = totalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Please first select product from listbox");
            }
            //lbInfo.Items.RemoveAt(lbInfo.SelectedIndex);
            lbSellList.Items.Clear();
            foreach (Product p in products)
            {
                lbSellList.Items.Insert(0, p.ToString());
            }
            //int selectedIndex = lbInfo.Items.RemoveAt()
            //Console.WriteLine("***** " + selectedIndex);
            //products.RemoveAt(selectedIndex);
        }


    }
}
