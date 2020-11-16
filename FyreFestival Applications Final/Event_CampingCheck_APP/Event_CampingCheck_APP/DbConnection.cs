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

namespace Event_CampingCheck_APP
{
    class DbConnection
    {
        public MySqlConnection connection;
        public DbConnection()
        {
            String connectionInfo = "server=127.0.0.1;" +//the hera-server
                                   "database=test2;" +
                                   "userid=root;" +
                                   "password=;" +
                                   "connect timeout=1;";

            connection = new MySqlConnection(connectionInfo);
        }
        //
        public string CheckIn(int id)
        {
            String sql = "UPDATE ticket SET typeC = @in WHERE idUser = @userId AND typeC = @out";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", id);
            command.Parameters.AddWithValue("@in", 1);
            command.Parameters.AddWithValue("@out", 0);
            string checkIn = "";
            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                if (nrOfRecordsChanged >= 1)
                {
                    return checkIn = "Checked In!";
                }
                // return 1;

            }
            catch
            {
                return checkIn = "There is no connection! Please check internet connection!";
            }
            finally
            {
                connection.Close();
            }
            return checkIn;
        }
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
        public void CheckOut(int id)
        {
            String sql = "UPDATE ticket SET typeC = @in WHERE idUser = @userId AND typeC = @out";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", id);
            command.Parameters.AddWithValue("@in", 0);
            command.Parameters.AddWithValue("@out", 1);
            // int typeC = -1;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                // while (reader.Read())
                // {
                //    typeC = Convert.ToInt32(reader["typeC"]);
                //  }
            }
            catch
            {

                // typeC = 0;
            }
            finally
            {
                connection.Close();
            }
            //return typeC;
        }
        public string PushChanges(int id, int typeC)
        {
            String sql = "UPDATE ticket SET typeC = @typeC WHERE idUser = @idUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idUser", id);
            command.Parameters.AddWithValue("@typeC", typeC);
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
            String sql = "SELECT idTicket,idUser,rfid,typeTicket,idCampspot,priceTicket,typeC FROM ticket";
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
                    streamWriter.Write(reader["typeC"]);
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
        //public string UpdateTypeJoinTestCheckIn(int id)
        //{

        //    // String sql = "UPDATE user SET user.typeC = @typeC FROM user INNER JOIN ticket ON user.id = ticket.user_id WHERE ticket.state = @TicketRIFD";
        //    String sql = "SELEC*T * FROM user INNER JOIN ticket ON ticket.user_id = user.id";
        //    MySqlCommand command = new MySqlCommand(sql, connection);
        //    //command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
        //    //command.Parameters.AddWithValue("@typeC", 0);
        //    string name = "";
        //    try
        //    {
        //        connection.Open();
        //        MySqlDataReader reader = command.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            name = (reader["name"]).ToString();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        name = "lol";
        //        //System.Windows.Forms.MessageBox.Show("no connetion");
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return name;          

        //public List<string> PullUsersChanges()
        //{

        //    String sql = "SELECT id,name,email,typeC FROM user";
        //    MySqlCommand command = new MySqlCommand(sql, connection);
        //    //command.Parameters.AddWithValue("@id", id);
        //    string user = "";
        //                    test = new List<string>();
        //    try
        //    {

        //        connection.Open();
        //        MySqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //           user = ((reader["id"]), (reader["name"]), (reader["email"]), (reader["typeC"])).ToString();
        //        }
        //    }
        //    catch(MySqlException EX)
        //    {
        //        System.Windows.Forms.MessageBox.Show(EX.Message);
        //    }
        //    finally 
        //    {
        //        connection.Close();
        //    }
        //    return user.ToList<User>();
        //}

        //3Days check in check out
        //public string CheckIn3Days (int id)
        //{
        //    String sql = "UPDATE user SET typeC = @in WHERE id = @userId AND typeC = @out";
        //    MySqlCommand command = new MySqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@userId", id);
        //    command.Parameters.AddWithValue("@in", 4);
        //    command.Parameters.AddWithValue("@out", 3);
        //    string checkIn = "";
        //    try
        //    {
        //        connection.Open();
        //        int nrOfRecordsChanged = command.ExecuteNonQuery();
        //        if (nrOfRecordsChanged >= 1)
        //        {
        //            return checkIn = "Checked In User: ";
        //        }
        //        // return 1;

        //    }
        //    catch
        //    {
        //        return checkIn = "There is no connection! Please check internet connection!";
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return checkIn;
        //}
        //public void CheckOut3Days(int id)
        //{
        //    String sql = "UPDATE user SET typeC = @in WHERE id = @userId AND typeC = @out";
        //    MySqlCommand command = new MySqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@userId", id);
        //    command.Parameters.AddWithValue("@in", 4);
        //    command.Parameters.AddWithValue("@out", 3);
        //    // int typeC = -1;
        //    try
        //    {
        //        connection.Open();
        //        MySqlDataReader reader = command.ExecuteReader();


        //        // while (reader.Read())
        //        // {
        //        //    typeC = Convert.ToInt32(reader["typeC"]);
        //        //  }
        //    }
        //    catch
        //    {

        //        // typeC = 0;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    //return typeC;
        //}
    }
}

