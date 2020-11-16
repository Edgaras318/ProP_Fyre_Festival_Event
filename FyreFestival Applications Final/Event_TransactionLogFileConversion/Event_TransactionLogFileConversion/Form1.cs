using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Event_TransactionLogFileConversion
{
    public partial class Form1 : Form
    {
        //MySqlConnection connection = new MySqlConnection("server=127.0.0.1;" +//the hera-server
        //                           "database=test2;" +
        //                           "userid=root;" +
        //                           "password=;" +
        //                           "connect timeout=1;");
        MySqlConnection connection = new MySqlConnection("server=studmysql01.fhict.local;" +//the hera-server
                               "database=dbi412570;" +
                               "userid=dbi412570;" +
                               "password=21735;" +
                               "connect timeout=1;");

        FileStream fs;
        StreamReader sr;
        LogFile log;
        string filename = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogFile_Click(object sender, EventArgs e)
        {
            var browser = new OpenFileDialog();

            browser.Filter = "Text files (*.txt)|*.txt";
            browser.RestoreDirectory = true;
            //browser.Title = filename;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                filename = browser.FileName;
                lblFileName.Text = browser.FileName;
                //sr.FileName = browser.FileName;
                lblStatus.Text = "Transaction file selected, run transacions or choose another file";
                lbInfo.Items.Clear();
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            log = new LogFile();
            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                lbInfo.Items.Add(line);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                log = new LogFile();
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                log.ProcessFile(fs, sr);
                //fs.Close();

                string query;
                MySqlCommand command;
                int tempint;
                string sqlStartDate = $"{log.StartTime.Year}-{log.StartTime.Month}-{log.StartTime.Day} {log.StartTime.Hour}:{log.StartTime.Minute}:{log.StartTime.Second}";
                string sqlEndDate = $"{log.EndTime.Year}-{log.EndTime.Month}-{log.EndTime.Day} {log.EndTime.Hour}:{log.EndTime.Minute}:{log.EndTime.Second}";

                for (int i = 0; i < log.NumberOfDeposits; i++)
                {
                    connection.Open();
                    query = $"INSERT INTO banktransactions (StartTime, EndTime, UserId, Amount) " + $"VALUES ('" + sqlStartDate + "', '" + sqlEndDate + "', '" + log.Deposits[i].Item1 + "', '" + log.Deposits[i].Item2 + "')";
                    command = new MySqlCommand(query, connection);
                    tempint = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Successfully exported the log file to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            finally
            {
                fs.Close();
                connection.Close();
            }
        }
    }
}
