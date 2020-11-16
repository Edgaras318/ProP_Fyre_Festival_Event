using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Overview_APP
{
    public partial class Form1 : Form
    {
        private DbConnection db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnection();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTotalCheckInVisitors.Text = Convert.ToString(db.TotalCheckedInVisitors());
            lblTotalVisitors.Text = Convert.ToString(db.TotalVisitors());
            lblTotalSpentInShop.Text = Convert.ToString(db.TotalMoneySpentInShop())+"€";
            lblTotalVisitorsBalance.Text = Convert.ToString(db.TotalVisitorsBalance())+ "€";
            lblTotalSpent.Text = Convert.ToString(db.TotalMoneySpentInLoan()+ db.TotalMoneySpentInShop())+ "€";
            lblTotalBorrowed.Text = Convert.ToString(db.TotalBorrowedItems());
            lblTransShop.Text = Convert.ToString(db.TotalTransShop());
            lblTransAtm.Text = Convert.ToString(db.TotalTransAtm());
            lblTransLoan.Text = Convert.ToString(db.TotalTransLoan());
            lblTotalVisitorsCampingSite.Text = Convert.ToString(db.TotalCampingSiteInVisitors());
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (tbProductName.Text != "" && db.GetProductRfid(tbProductName.Text) != "no")
            {
                lblTotalCertainProduct.Text = Convert.ToString((db.TotalProductsSold(db.GetProductRfid(tbProductName.Text))));
            }
            else
            {
                MessageBox.Show("Please enter valid product name");
            }
        }

        private void btnCheckVisitor_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && db.GetUserId(tbName.Text) > 0)
            {
                lblVisitorBalance.Text = Convert.ToString(db.GetUserBalance(tbName.Text));
                lblVisitorTotalSpent.Text = Convert.ToString(db.GetVisitorShopSpentMoney(db.GetUserId(tbName.Text)));
                string status = "";
                if (db.GetVisitorStatus(db.GetUserId(tbName.Text)) == 1)
                {
                    status = "Checked In";
                }
                else
                {
                    status = "Checked Out";
                }
                lblVisitorStatus.Text = status;
                string camping = "";
                if (db.GetVisitorCamping(db.GetUserId(tbName.Text)) == 1)
                {
                    camping = "In Camping Site";
                }
                else
                {
                    camping = "Not In Camping Site";
                }
                lblVisitorCamping.Text = camping;
            }
            else
            {
                MessageBox.Show("Please enter valid name");
            }
        }
    }
}
