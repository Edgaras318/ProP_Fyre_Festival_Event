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


namespace Event_LoanStore
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DbConnection db;
        private List<Item> items;
        private double totalPrice = 0;
        private string rfidItem;
        private int loanId;
        //private List<SoldProducts> soldProducts;

        public Form1()
        {
            InitializeComponent();
            db = new DbConnection();
            myRFIDReader = new RFID();
            items = new List<Item>();
            myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            myRFIDReader.Open();
            myRFIDReader.Attach += new AttachEventHandler(Attached);
            myRFIDReader.Detach += new DetachEventHandler(Detached);
        }
        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lbInfo.Items.Insert(0,"RFID Reader attached");
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lbInfo.Items.Insert(0, "RFID Reader detached");
            // lblItemName.Text = "";
            //lblPrice.Text = "";
        }

        public void ReadTagNewID(object sender, RFIDTagEventArgs e)
        {
            if (btnSell.Text == "RENT ITEMS")
            {
                db.ItemPrice(e.Tag);
                lblPrice.Text = db.Price.ToString();
                lblProduct.Text = db.Name.ToString();
                rfidItem = e.Tag;
                loanId = db.SelectLoanId(e.Tag);
            }
        }
        public void ReadTagUser(object sender, RFIDTagEventArgs e)
        {
            if (db.SelectUserId(e.Tag) > 0)
            {
                int userId = db.SelectUserId(e.Tag);
                double balance = db.SelectBalance(userId);
               // Console.WriteLine("** " + loanId);
                // Console.WriteLine("********** hiiiiiiiiiiiiiiiiiiiiiii" + db.Price);
                if (balance >= db.Price)
                {
                    // lblTag.Text = e.Tag;
                    //  Console.WriteLine("********** " + balance);
                    balance = balance - totalPrice;
                    //Console.WriteLine("********** " + balance);
                    foreach (Item p in items)
                    {
                        //db.ProductQty(p.P_rfid);
                        
                        lbInfo.Items.Insert(0, "UserRfid: " + e.Tag + " " + p.Name + " Price: " + p.Price);
                        //Console.WriteLine("*** " + userId+"*"+ shopId+ "*"+p.P_rfid);
                        db.InsertTransction(userId, loanId, p.P_rfid);
                        db.InsertUpTransction(userId, loanId, p.P_rfid, p.Price);
                        db.Paying(userId, balance);
                    }
                    MessageBox.Show("Products Rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // lblTag.Text = "";
                    //lblItemName.Text = "";
                    // lblPrice.Text = "";
                    btnSell.Text = "RENT ITEMS";
                    myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
                    myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
                    lblTotalPrice.Text = "0";
                    items.Clear();
                    lbItems.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Buyer don't have enough credits!");
                }
            }
            else if (btnSell.Text == "RENT ITEMS")
            {
                MessageBox.Show("This item is out of stock!");
            }
            else
            {
                MessageBox.Show("This ticket does not exist!");
            }
        }
        public void ReadTagUserReturn(object sender, RFIDTagEventArgs e)
        {
           // if (db.SelectUserId(e.Tag) > 0)
            //{
                
                int userId = db.SelectUserId(e.Tag);
                // double balance = db.SelectBalance(userId);
                // Console.WriteLine("** " + loanId);
                // Console.WriteLine("********** hiiiiiiiiiiiiiiiiiiiiiii" + db.Price);
                // Console.WriteLine("Hello " + db.SelectUserId(e.Tag));
                //Console.WriteLine("Hello3 " + e.Tag);
                //Console.WriteLine("Hello2 " + db.CheckIfBorrowed(e.Tag));
                int test = 0;
                foreach (Item i in items)
                {
                    if (db.SelectUserId(e.Tag) >= 1 && db.CheckIfBorrowed(i.P_rfid) > 0)
                    {
                        lbInfo.Items.Insert(0, "UserRfid: " + e.Tag + " Returned: " + i.Name);
                        //Console.WriteLine("*** " + userId+"*"+ shopId+ "*"+p.P_rfid);
                        db.ReturnItems(i.P_rfid);
                    test = 1;
                }

                    // lblTag.Text = "";
                    //lblItemName.Text = "";
                    // lblPrice.Text = "";
                }
            if (test == 1)
            {
                MessageBox.Show("Items Returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReturn.Text = "RETURN ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUserReturn);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
                lblTotalPrice.Text = "0";
                items.Clear();
                lbItems.Items.Clear();
            }


            else if (btnReturn.Text == "RETURN ITEMS")
            {
                MessageBox.Show("This item is out of stock!");
                btnReturn.Text = "RETURN ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUserReturn);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            }
            else
            {
                MessageBox.Show("This item is already rented!");
                btnReturn.Text = "RETURN ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUserReturn);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID); ;
            }
        }
        private void TotalPrice()
        {
            totalPrice = 0;
            foreach (Item p in items)
            {
                totalPrice = totalPrice + p.Price;
            }
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (btnSell.Text == "CANCEL RENT" && items.Count > 0)
            {
                //myRFIDReader.Open();
                //MessageBox.Show("Scan rfid!");
                // lblItemName.Text = "";
                // lblPrice.Text = "";
                btnSell.Text = "RENT ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            }
            else if(items.Count > 0)
            {
                btnSell.Text = "CANCEL RENT";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagNewID);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagUser);
            }
            else
            {
                MessageBox.Show("Please first add items");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblProduct.Text != "Name of product" || lblProduct.Text != "not exist")
            {
            }
            if (lblProduct.Text != "not exist" && lblProduct != null && lblProduct.Text != "Name of item" && lblProduct.Text != "")
            {
                lbItems.Items.Clear();
                items.Add(new Item(db.Rfid, lblProduct.Text, db.Price));
                TotalPrice();
                lblTotalPrice.Text = totalPrice.ToString();
                lblProduct.Text = "Name of item";
                lblPrice.Text = "$";
                foreach (Item p in items)
                {
                    lbItems.Items.Insert(0, p.ToString());
                }
            }
            else if (lblProduct.Text == "Name of item" || lblProduct.Text == "not exist")
            {
                MessageBox.Show("Please make sure you scanned Item!", "Item does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex >= 0 && btnReturn.Text != "CANCEL RETURN" && btnSell.Text != "CANCEL RENT")
            {
                items.RemoveAt(lbItems.SelectedIndex);
                TotalPrice();
                lblTotalPrice.Text = totalPrice.ToString();
               // myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUserReturn);
               // myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
               // myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
               // btnSell.Text = "RENT ITEMS";
               // btnReturn.Text = "RETURN ITEMS";
            }
            else if (lbItems.SelectedIndex < 0)
            {
                MessageBox.Show("Please first select product from listbox");
            }
            else
            {
                MessageBox.Show("You cannot remove item. Please first cancel RENT or RETURN");
            }
            //lbInfo.Items.RemoveAt(lbInfo.SelectedIndex);
            lbItems.Items.Clear();
            foreach (Item p in items)
            {
                lbItems.Items.Insert(0, p.ToString());
            }
            //int selectedIndex = lbInfo.Items.RemoveAt()
            //Console.WriteLine("***** " + selectedIndex);
            //products.RemoveAt(selectedIndex);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (btnReturn.Text == "CANCEL RETURN" && items.Count >0)
            {
                //myRFIDReader.Open();
                //MessageBox.Show("Scan rfid!");
                // lblItemName.Text = "";
                // lblPrice.Text = "";
                btnReturn.Text = "RETURN ITEMS";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUserReturn);
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagUser);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            }
            else if (items.Count > 0)
            {
                btnReturn.Text = "CANCEL RETURN";
                myRFIDReader.Tag -= new RFIDTagEventHandler(ReadTagNewID);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagUserReturn);
            }
            else
            {
                MessageBox.Show("Please first add items");
            }
        }
    }
}
