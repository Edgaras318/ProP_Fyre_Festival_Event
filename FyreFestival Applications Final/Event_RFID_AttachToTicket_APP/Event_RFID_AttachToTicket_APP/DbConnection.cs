using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Reflection;

namespace Event_RFID_AttachToTicket_APP
{
    class DbConnection
    {
        public MySqlConnection connection;
        public DbConnection()
        {
            //Local
            //String connectionInfo = "server=127.0.0.1;" +//the hera-server
            //           "database=test2;" +
            //           "userid=root;" +
            //           "password=;" +
            //           "connect timeout=1;";
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                   "database=dbi412570;" +
                                   "userid=dbi412570;" +
                                   "password=21735;" +
                                   "connect timeout=1;";

            connection = new MySqlConnection(connectionInfo);
        }
        public int SelectUserId(string name)
        {

            String sql = "SELECT idUser FROM user WHERE unameUser = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            int id = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["idUser"]);
                }
            }
            catch (Exception e)
            {

                id = 0;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
        public string SelectUserName(string name)
        {

            String sql = "SELECT unameUser FROM user WHERE unameUser = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            string userExist = "false";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string count = reader["unameUser"].ToString();
                    if (count != null)
                    {
                        userExist = "true";
                    }
                }
            }
            catch (Exception e)
            {

                userExist = "false";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return userExist;
        }

        public string UniqueRfidCheck(string rfid)
        {

            String sql = "SELECT rfid FROM ticket WHERE rfid = @rfid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@rfid", rfid);
            string rfidExist = "false";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string count = reader["rfid"].ToString();
                    if (count != null)
                    {
                        rfidExist = "true";
                    }
                }
            }
            catch (Exception e)
            {

                rfidExist = "false";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return rfidExist;
        }
        public string PushChanges(int id, string rfid)
        {
            String sql = "UPDATE ticket SET rfid = @rfid WHERE idUser = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", id);
            command.Parameters.AddWithValue("@rfid", rfid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // return 1;

            }
            catch (MySqlException ex)
            {
                return "Connection Error!";
            }

            finally
            {
                connection.Close();
            }
            return "Database inforamtion Updated!";

        }
        public string PullUsersFromDbToFile()
        {
            String sql = "SELECT idUser,unameUser,emailUser,balance FROM user";
            MySqlCommand command = new MySqlCommand(sql, connection);
            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingUsers.txt"), FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                //string check;
                while (reader.Read())
                {
                    streamWriter.Write((reader["idUser"]));
                    streamWriter.Write("-");
                    streamWriter.Write((reader["unameUser"]));
                    streamWriter.Write("-");
                    streamWriter.Write((reader["emailUser"]));
                    streamWriter.Write("-");
                    streamWriter.Write(reader["balance"]);
                    streamWriter.WriteLine("");
                }
            }
            catch (MySqlException ex)
            {
                return "Connection Error!";
            }

            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    connection.Close();
                }
            }
            return "Connection Online!";
        }
        public string PullTicketsFromDbToFile()
        {
            String sql = "SELECT idTicket,idUser,rfid,typeTicket,idCampspot,priceTicket,type FROM ticket";
            MySqlCommand command = new MySqlCommand(sql, connection);
            StreamWriter streamWriter = null;
            try
            {
                FileStream fileStream = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingTickets.txt"), FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    streamWriter.Write((reader["idTicket"]));
                    streamWriter.Write("-");
                    streamWriter.Write((reader["idUser"]));
                    streamWriter.Write("-");
                    streamWriter.Write(reader["rfid"]);
                    streamWriter.Write("-");
                    streamWriter.Write((reader["typeTicket"]));
                    streamWriter.Write("-");
                    streamWriter.Write(reader["idCampspot"]);
                    streamWriter.Write("-");
                    streamWriter.Write(reader["priceTicket"]);
                    streamWriter.Write("-");
                    streamWriter.Write(reader["type"]);
                    streamWriter.WriteLine("");
                }
            }
            catch (MySqlException ex)
            {
                return "Connection Error!";
            }

            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    connection.Close();
                }
            }
            return "Connection Online!";
        }

    }
}

