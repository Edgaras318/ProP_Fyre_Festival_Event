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

namespace EventCheckIn_CheckOut
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DbConnection db;
        private List<User> myUsers;
        private List<Ticket> myTickets;
        private string selectedTicketType;
        ///************delegates and events***********************************/

        //public delegate void TimerHandler(Timer t);

        //public event TimerHandler _timerHandler;
        public Form1()
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
           // btnLogging.Text = "STOP LOGGING";
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
            if (rbnMay15.Checked)
            {
                selectedTicketType = "15May";
            }
            else if (rbnMay16.Checked)
            {
                selectedTicketType = "16May";
            }
            else
            {
                selectedTicketType = "17May";
            }
            if (btnReadingFromFile.Text == "START READING FROM A FILE")
            {

                //string checkIn = db.UpdateTypeJoinTestCheckIn(1);
                //MessageBox.Show(checkIn);
                int catchnr = db.SelectUserId(e.Tag);
                int checkType = db.CheckType(catchnr);
               // Console.WriteLine("*************" + checkType);
                if (catchnr > 0)
                {
                    if (checkType == 0 && db.CheckTicketType(catchnr) == selectedTicketType || checkType == 0 && db.CheckTicketType(catchnr) == "BasicFull" || checkType == 0 && db.CheckTicketType(catchnr) == "FanFull")
                    {
                        lbInfo.Items.Insert(0, $"RFID: {e.Tag} Name: {db.SelectUserName(catchnr)} Checked In!");
                        LogToFile($"RFID: {e.Tag} Name: {db.SelectUserName(catchnr)} Checked In!");
                        pbCheckIn.Visible = true;
                        pbCheckOut.Visible = false;
                        db.UpdateType(catchnr, 1);
                    }
                    else if(db.CheckTicketType(catchnr) != selectedTicketType && db.CheckTicketType(catchnr) != "BasicFull" && db.CheckTicketType(catchnr) != "FanFull")
                    {
                        MessageBox.Show("Today is "+ selectedTicketType + "Your ticket is for "+ db.CheckTicketType(catchnr));
                    }
                    else if (checkType == 1)
                    {
                        //Console.WriteLine("*************" + checkType);
                        if (db.CheckIfBorrowed(catchnr) < 1) {
                        string checkIn = "Checked Out!";
                       // db.CheckOut(catchnr);
                        lbInfo.Items.Insert(0, $"RFID: {e.Tag} Name: {db.SelectUserName(catchnr)} {checkIn}");
                        LogToFile($"RFID: {e.Tag} Name: {db.SelectUserName(catchnr)} {checkIn}");
                        pbCheckIn.Visible = false;
                        pbCheckOut.Visible = true;
                           // Console.WriteLine("*************" + catchnr + "*************");
                            db.UpdateType(catchnr, 0);
                        }
                        else
                        {
                            MessageBox.Show("This user still have rented items!");
                        }
                        //AutoClosingMessageBox.Show(checkIn + e.Tag, "Alert Box!", 1000);
                    }
                    if (db.PullUsersFromDbToFile() == "Connection Online!")
                    {
                        db.PullUsersFromDbToFile();
                        db.PullTicketsFromDbToFile();
                        lblDbStatus.Text = "Connection Online!";
                        lblUpdateDate.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt").ToString();
                    }
                }
                else if (db.CheckType(catchnr) == -1)
                {
                    pbCheckIn.Visible = false;
                    pbCheckOut.Visible = false;
                    MessageBox.Show("User does not exist!");
                }
                else
                {
                   // MessageBox.Show(checkIn);
                    lblDbStatus.Text = "Connection Offline!";
                }
            }
            else if(btnReadingFromFile.Text == "SAVE CHANGES IN THE FILES")
            {// Logging from file started
                int userIdTicket = 0;
                int type = 0;
                string name = "";
                
                foreach (Ticket t in myTickets)
                {
                    if (e.Tag == t.Rfid)
                    {
                        userIdTicket = t.IdUser;
                    }
                }
                if (userIdTicket > 0)
                {
                    foreach (User u in myUsers)
                    {
                        if (u.ID == userIdTicket)
                        {
                           name = u.ToString();
                        }
                    }
                    // Console.WriteLine("***********************" + name);
                    foreach (Ticket t in myTickets)
                    {
                        if (t.IdUser == userIdTicket)
                        {
                            t.TypeString();
                            lbInfo.Items.Insert(0,$"RIFD: {e.Tag} {name} Type: {t.ToString()}");
                            LogToFile($"RIFD: {e.Tag} {name} Type: {t.ToString()}");
                            type = t.Type;
                            if(db.PullUsersFromDbToFile() == "Connection Online!")
                            {
                                lblDbStatus.Text = "Connection Online!";
                               // MessageBox.Show("Connection is back! You can save changes and go online now!");
                            }
                        }
                        //Console.WriteLine("*************" +type);
                        if (type == 0)
                        {
                            pbCheckIn.Visible = false;
                            pbCheckOut.Visible = true;
                        }
                        else
                        {
                            pbCheckIn.Visible = true;
                            pbCheckOut.Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(e.Tag+ " This user does not exist in loggingUsers.txt file!");
                }
            }
        }

        private void btnReadingFromFile_Click(object sender, EventArgs e)
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
                    var lines = line.Split(new[] {'-'});
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
                    var lines = line.Split(new[] {'-'});
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
       

        private void btnPushChanges_Click(object sender, EventArgs e)
        {
            if (db.PushChanges(0, 0) == "Database inforamtion Updated!" && btnReadingFromFile.Text == "START READING FROM A FILE")
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
                db.PushChanges(t.IdUser, t.Type);
                // counter++;
                //lbInfo.Items.Insert(0, counter + " users were updated!");
            }
        }
            else
            {
                MessageBox.Show("Please make sure you saved file changes first!");
            }
    }
        public void LogToFile(string s)
        {
            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "EventCheckInOutLogFile.txt"), FileMode.OpenOrCreate, FileAccess.Write);
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

    }
}
