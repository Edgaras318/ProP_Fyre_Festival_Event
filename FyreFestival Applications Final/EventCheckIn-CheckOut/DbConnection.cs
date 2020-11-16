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

namespace EventCheckIn_CheckOut
{
    class DbConnection
    {
        public MySqlConnection connection;
        string checkIn = "lol";
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
        //
        public int SelectUserId(string TicketRIFD)
        {

            String sql = "SELECT idUser FROM ticket WHERE rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            int user_id = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["idUser"]);
                }
            }
            catch (Exception e)
            {

                user_id = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return user_id;
        }
        public string SelectUserName(int id)
        {

            String sql = "SELECT unameUser FROM user WHERE idUser = @Userid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Userid", id);
            string name = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    name = (reader["unameUser"]).ToString();
                }
            }
            catch (Exception e)
            {

                name = "";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return name;
        }
        public string PushChanges(int id, int type)
        {
            String sql = "UPDATE ticket SET type = @type WHERE idUser = @idUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idUser", id);
            command.Parameters.AddWithValue("@type", type);
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
                FileStream fileStream = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingUsers.txt"), FileMode.OpenOrCreate, FileAccess.Write); streamWriter = new StreamWriter(fileStream);
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
        public int CheckIfBorrowed(int userId)
        {

            String sql = "SELECT amount FROM loan_transaction_up WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            int user_id = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["amount"]);
                }
            }
            catch (Exception e)
            {

                user_id = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return user_id;
        }
        public string CheckTicketType(int idUser)
        {

            String sql = "SELECT typeTicket FROM ticket WHERE idUser = @idUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idUser", idUser);
            string name = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    name = (reader["typeTicket"]).ToString();
                }
            }
            catch (Exception e)
            {

                name = "";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return name;
        }
        public int CheckType(int idUser)
        {

            String sql = "SELECT type FROM ticket WHERE idUser = @idUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idUser", idUser);
            int name = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    name = Convert.ToInt32(reader["type"]);
                }
            }
            catch (Exception e)
            {

                name = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return name;
        }
        public void UpdateType(int idUser, int checkType)
        {

            String sql = "UPDATE ticket SET type = @checkType WHERE idUser = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", idUser);
            command.Parameters.AddWithValue("@checkType", checkType);
            //int name = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception e)
            {

              //  name = -1;
                System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
          //  return name;
        }
    }
}

