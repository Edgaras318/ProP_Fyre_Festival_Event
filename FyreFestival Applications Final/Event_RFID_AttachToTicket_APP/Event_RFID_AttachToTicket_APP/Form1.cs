using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;

namespace Event_RFID_AttachToTicket_APP
{
    public partial class lblFullName : Form
    {
        private RFID myRFIDReader;
        private DbConnection db;
        private List<User> myUsers;
        private List<Ticket> myTickets;
        public lblFullName()
        {
            InitializeComponent();
            db = new DbConnection();
            myRFIDReader = new RFID();
            myRFIDReader.Attach += new AttachEventHandler(Attached);
            myRFIDReader.Detach += new DetachEventHandler(Detached);
            myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);
            myRFIDReader.Open();
            myUsers = new List<User>();
            myTickets = new List<Ticket>();
        }
        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lbInfo.Items.Add("RFID Reader attached");
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lbInfo.Items.Add("RFID Reader detached");
        }
        public void ReadTagNewID(object sender, RFIDTagEventArgs e)
        {
            lblRfid.Text = e.Tag;
        }
        // Reading , loading from file, saving 

        public void LoadTicketsFromFile(string fileName)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read));
                this.myTickets.Clear();
                String line, rfid, typeTicket, idCampspot;
                int idTicket, idUser, type;
                double priceTicket;
                line = sr.ReadLine();
                while (line != null)
                {
                    var lines = line.Split(new[] { '-' });
                    idTicket = Convert.ToInt32(lines[0]);
                    idUser = Convert.ToInt32(lines[1]);
                    rfid = lines[2];
                    typeTicket = lines[3];
                    idCampspot = lines[4];
                    priceTicket = Convert.ToInt32(lines[5]);
                    type = Convert.ToInt32(lines[6]);
                    this.myTickets.Add(new Ticket(idTicket, idUser, rfid, typeTicket, idCampspot, priceTicket, type));
                    line = sr.ReadLine();
                }
            }
            catch (IOException ex)
            {
                throw new Exception("Input/Output exception with message \"" + ex.Message + "\" occurred", ex);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
        public void LoadUsersFromFile(string fileName)
        {

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
                this.myUsers.Clear();
                String line, name, email;
                int userId;
                double balance;
                line = sr.ReadLine();
                while (line != null)
                {
                    var lines = line.Split(new[] { '-' });
                    name = lines[1];
                    email = lines[2];
                    balance = Convert.ToDouble(lines[3]);
                    userId = Convert.ToInt32(lines[0]);
                    this.myUsers.Add(new User(userId, name, email, balance));
                    line = sr.ReadLine();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Creating empty logging files");
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
        public void SaveTicketsFromFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
                foreach (Ticket t in myTickets)
                {
                    streamWriter.WriteLine($"{t.IdTicket}-{t.IdUser}-{t.Rfid}-{t.TypeTicket}-{t.IdCampspot}-{t.PriceTicket}-{t.Type}");
                    //  streamWriter.WriteLine(t);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Something went wrong with accessing the file tickets!");
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
        public void SaveUsersFromFile(string fileName)
        {

            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
                foreach (User u in myUsers)
                {
                    streamWriter.WriteLine($"{u.ID}-{u.Name}-{u.Email}-{u.Balance}");
                    // Console.WriteLine("********" + u.Type);
                    //streamWriter.WriteLine(u);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Something went wrong with accessing the file users!");
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        public void LogToFile(string s)
        {
            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "EventCheckInOutLogFile.txt"), FileMode.Append, FileAccess.Write);
                //Append keep what is in the file and add more info after it 
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine($"{s}  {DateTime.Now}");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Something went wrong with accessing the file!");
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        private void btnReadingFromFile_Click_1(object sender, EventArgs e)
        {
            if (btnReadingFromFile.Text == "START READING FROM A FILE")
            {
                lbInfo.Items.Clear();
                LoadUsersFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingUsers.txt"));
                LoadTicketsFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingTickets.txt"));
                MessageBox.Show("Inforamtion from the files loaded!");
                btnReadingFromFile.Text = "SAVE CHANGES IN THE FILES";
                lbInfo.Items.Clear();
            }
            else
            {
                SaveUsersFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingUsers.txt"));
                SaveTicketsFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingTickets.txt"));
                MessageBox.Show("Inforamtion saved in the files!");
                btnReadingFromFile.Text = "START READING FROM A FILE";
            }
        }

        private void btnPushChanges_Click_1(object sender, EventArgs e)
        {
            if (db.PushChanges(0, "") == "Database inforamtion Updated!" && btnReadingFromFile.Text == "START READING FROM A FILE")
            {
                MessageBox.Show("Database inforamtion Updated!");
            }
            else
            {
                MessageBox.Show("Connection Error!");
            }
            if (btnReadingFromFile.Text == "START READING FROM A FILE")
            {
                LoadUsersFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingUsers.txt"));
                // int counter = 0;
                foreach (Ticket t in myTickets)
                {
                    db.PushChanges(t.IdUser, t.Rfid);
                    // counter++;
                    //lbInfo.Items.Insert(0, counter + " users were updated!");
                }
            }
            else
            {
                MessageBox.Show("Please make sure you saved file changes first!");
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (btnReadingFromFile.Text == "START READING FROM A FILE") 
            {
                db.SelectUserName(tbFullName.Text);
                // Console.WriteLine( "**************" + db.SelectUserName(tbFullName.Text));
                if (tbFullName.Text != "" && db.UniqueRfidCheck(lblRfid.Text) != "true" && lblRfid.Text != "rfid" && db.SelectUserName(tbFullName.Text) == "true")
                {
                    db.PushChanges(db.SelectUserId(tbFullName.Text), lblRfid.Text);
                    lbInfo.Items.Insert(0, "Name: " + tbFullName.Text + " Attached Rfid: " + lblRfid.Text);
                    LogToFile("Name: " + tbFullName.Text + " Attached Rfid: " + lblRfid.Text);
                    MessageBox.Show("Name: " + tbFullName.Text + " Attached Rfid: " + lblRfid.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tbFullName.Text == "" || db.SelectUserName(tbFullName.Text) == "false")
                {
                    MessageBox.Show("Please first enter valid full name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if( lblRfid.Text == "rfid")
                {
                    MessageBox.Show("Please first scan rfid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("This Rfid already attached to someone!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (db.PullUsersFromDbToFile() == "Connection Online!")
                {
                    db.PullUsersFromDbToFile();
                    db.PullTicketsFromDbToFile();
                    lblDbStatus.Text = "Connection Online!";
                    lblUpdateDate.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt").ToString();
                }
            }
            else if (btnReadingFromFile.Text == "SAVE CHANGES IN THE FILES")
            {
                string selectUserName = "";
                int selectedUserId = 0;
                string selectRfid = "empty";
                //string 
                foreach (User u in myUsers)
                {
                    if (tbFullName.Text == u.Name)
                    {
                        selectUserName = u.Name;
                        selectedUserId = u.ID;
                    }
                }
                 //Console.WriteLine("%%%%%%%%%%  " + "pp"+ selectedUserId + "pp");
                foreach (Ticket t in myTickets)
                {
                    if (lblRfid.Text == t.Rfid)
                    {
                        selectRfid = "true";
                    }
                }
               // Console.WriteLine("%%%%%%%%%%  " + "pp"+selectRfid+"pp");
                // Console.WriteLine( "**************" + db.SelectUserName(tbFullName.Text));
                    if(tbFullName.Text != "" && lblRfid.Text != "rfid" && tbFullName.Text == selectUserName && selectRfid != "true") {
                    //db.PushChanges(db.SelectUserId(tbFullName.Text), lblRfid.Text);
                    lbInfo.Items.Insert(0, "Name: " + tbFullName.Text + " Attached Rfid: " + lblRfid.Text);
                    LogToFile("Name: " + tbFullName.Text + " Attached Rfid: " + lblRfid.Text);
                    //Console.WriteLine("%%%%%%%%%%  " + "pp" + selectRfid + "pp");
                   // Console.WriteLine("%%%%%%%%%%  " + "pp" + selectedUserId + "pp");
                    foreach (Ticket t in myTickets)
                    {
                        if (t.IdUser == selectedUserId)
                        {
                            t.AddRfid(lblRfid.Text);
                        }
                    }
                }
                else if (tbFullName.Text == "" || selectUserName != tbFullName.Text)
                {
                    MessageBox.Show("Please first enter valid full name!");
                }
                else if (lblRfid.Text == "rfid")
                {
                    MessageBox.Show("Please first scan rfid!");
                }
                else
                {
                    MessageBox.Show("This Rfid already attached to someone!");
                }
            }
        }
    }
}
