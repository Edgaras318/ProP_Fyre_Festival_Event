using Phidget22;
using Phidget22.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_ATM_APP
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DbConnection db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnection();
            myRFIDReader = new RFID();
            myRFIDReader.Attach += new AttachEventHandler(Attached);
            myRFIDReader.Detach += new DetachEventHandler(Detached);
            myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            myRFIDReader.Open();
        }
        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lblRfidConnetion.Text = "RFID Reader Online";
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lblRfidConnetion.Text = "RFID Reader Offline";
        }
        public void ReadTagNewID(object sender, RFIDTagEventArgs e)
        {
            lblRfid.Text = e.Tag;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (lblRfid.Text != "rfid" && nudAmount.Value > 0 && db.SelectBalance(999) != -1)
            {
                int selectedUser = db.SelectUserId(lblRfid.Text);
                double balance = db.SelectBalance(selectedUser);
                double amount = Convert.ToDouble(nudAmount.Text);
                double updatedAmount = balance + amount;
                db.UpdateBalance(updatedAmount, selectedUser);
                db.InsertDeposits(selectedUser, amount);
                MessageBox.Show("You successfully added " + amount + " € to your balance!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRfid.Text = "rfid";
            }
            else if (lblRfid.Text == "rfid")
            {
                MessageBox.Show("Please scan ticket you want add money to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.SelectBalance(999) == -1)
            {
                MessageBox.Show("ATM is Offline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter amount you want to Add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDeposit5_Click(object sender, EventArgs e)
        {
            if (lblRfid.Text != "rfid" && db.SelectBalance(999) != -1)
            {
                int selectedUser = db.SelectUserId(lblRfid.Text);
                double balance = db.SelectBalance(selectedUser);
                double amount = 5;
                double updatedAmount = balance + amount;
                db.UpdateBalance(updatedAmount, selectedUser);
                db.InsertDeposits(selectedUser, amount);
                MessageBox.Show("You successfully added " + amount + " € to your balance!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRfid.Text = "rfid";
            }
            else if (lblRfid.Text == "rfid")
            {
                MessageBox.Show("Please scan ticket you want add money to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.SelectBalance(999) == -1)
            {
                MessageBox.Show("ATM is Offline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeposit10_Click(object sender, EventArgs e)
        {
            if (lblRfid.Text != "rfid" && db.SelectBalance(999) != -1)
            {
                int selectedUser = db.SelectUserId(lblRfid.Text);
                double balance = db.SelectBalance(selectedUser);
                double amount = 10;
                double updatedAmount = balance + amount;
                db.UpdateBalance(updatedAmount, selectedUser);
                db.InsertDeposits(selectedUser, amount);
                MessageBox.Show("You successfully added " + amount + " € to your balance!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRfid.Text = "rfid";
            }
            else if (lblRfid.Text == "rfid")
            {
                MessageBox.Show("Please scan ticket you want add money to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.SelectBalance(999) == -1)
            {
                MessageBox.Show("ATM is Offline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeposit20_Click(object sender, EventArgs e)
        {
            if (lblRfid.Text != "rfid" && db.SelectBalance(999) != -1)
            {
                int selectedUser = db.SelectUserId(lblRfid.Text);
                double balance = db.SelectBalance(selectedUser);
                double amount = 20;
                double updatedAmount = balance + amount;
                db.UpdateBalance(updatedAmount, selectedUser);
                db.InsertDeposits(selectedUser, amount);
                MessageBox.Show("You successfully added " + amount + " € to your balance!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRfid.Text = "rfid";
            }
            else if (lblRfid.Text == "rfid")
            {
                MessageBox.Show("Please scan ticket you want add money to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.SelectBalance(999) == -1)
            {
                MessageBox.Show("ATM is Offline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeposit50_Click(object sender, EventArgs e)
        {
            if (lblRfid.Text != "rfid" && db.SelectBalance(999) != -1)
            {
                int selectedUser = db.SelectUserId(lblRfid.Text);
                double balance = db.SelectBalance(selectedUser);
                double amount = 50;
                double updatedAmount = balance + amount;
                db.UpdateBalance(updatedAmount, selectedUser);
                db.InsertDeposits(selectedUser, amount);
                MessageBox.Show("You successfully added " + amount + " € to your balance!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRfid.Text = "rfid";
            }
            else if (lblRfid.Text == "rfid")
            {
                MessageBox.Show("Please scan ticket you want add money to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.SelectBalance(999) == -1)
            {
                MessageBox.Show("ATM is Offline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
