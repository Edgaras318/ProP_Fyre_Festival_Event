using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Event_LoanStore
{
    class DbConnection
    {
        public MySqlConnection connection;
        public string Rfid { get; private set; }
        public double Price { get; private set; }
        public string Name { get; private set; }
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
        // User Name get by rfid
        //public string CheckUserName(string TicketRIFD)
        //{

        //    // String sql = "UPDATE user SET user.type = @type FROM user INNER JOIN ticket ON user.id = ticket.user_id WHERE ticket.state = @TicketRIFD";
        //    String sql = "SELECT name FROM user INNER JOIN ticket ON ticket.user_id = user.id AND ticket.state = @TicketRIFD";
        //    MySqlCommand command = new MySqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
        //    //command.Parameters.AddWithValue("@type", 0);
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

        //}
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
        public double SelectBalance(int UserId)
        {

            String sql = "SELECT balance FROM user WHERE idUser = @SelectedUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@SelectedUser", UserId);
            double balance = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    balance = Convert.ToDouble(reader["balance"]);
                }
            }
            catch (Exception e)
            {

                balance = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return balance;
        }
        public void ItemPrice(string TicketRIFD)
        {

            String sql = "SELECT i_rfid, price, name FROM item WHERE i_rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            //string name = "";
            // double price = 0;
            //int qty = 0;
            Name = "not exist";
            Price = -1;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    //Qty = Convert.ToInt32(reader["quantity"]);
                    Price = Convert.ToDouble(reader["price"]);
                    Name = (reader["name"]).ToString();
                    Rfid = (reader["i_rfid"]).ToString();
                }
            }
            catch (Exception e)
            {

                Name = "not exist";
                Price = -1;
                Rfid = "not exist";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
                Price = Price / 100 *10;
            }
        }
        public void Paying(int userId, double balance)
        {
            String sql = "UPDATE user SET balance = @balance WHERE idUser = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@balance", balance);
            // int type = -1;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void InsertTransction(int userId, int shopId, string product_rfid)
        {
            String sql = "INSERT INTO loan_transaction (user_id, amount,loan_has_item_loan_id ,loan_has_item_item_i_rfid) VALUES (@idUser, @amount, @shopId, @product_rfid)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@amount", 1);
            command.Parameters.AddWithValue("@idUser", userId);
            command.Parameters.AddWithValue("@shopId", shopId);
            command.Parameters.AddWithValue("@product_rfid", product_rfid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("If rfid reader ofline you cannot add money");
            }
            finally
            {
                connection.Close();
            }
        }
        public void InsertUpTransction(int userId, int shopId, string product_rfid, double rentPrice)
        {
            String sql = "INSERT INTO loan_transaction_up (user_id, amount,loan_has_item_loan_id ,loan_has_item_item_i_rfid, rentprice) VALUES (@idUser, @amount, @shopId, @product_rfid, @rentprice)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@amount", 1);
            command.Parameters.AddWithValue("@idUser", userId);
            command.Parameters.AddWithValue("@shopId", shopId);
            command.Parameters.AddWithValue("@product_rfid", product_rfid);
            command.Parameters.AddWithValue("@rentprice", rentPrice);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("If rfid reader ofline you cannot add money");
            }
            finally
            {
                connection.Close();
            }
        }
        public void ReturnItems(string product_rfid)
        {
            String sql = "DELETE FROM loan_transaction WHERE loan_has_item_item_i_rfid = @product_rfid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@product_rfid", product_rfid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("If rfid reader ofline you cannot add money");
            }
            finally
            {
                connection.Close();
            }
        }
        public int SelectLoanId(string TicketRIFD)
        {

            String sql = "SELECT loan_id FROM loan_has_item WHERE item_i_rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            int shopId = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    shopId = Convert.ToInt32(reader["loan_id"]);
                }
            }
            catch (Exception e)
            {

                shopId = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return shopId;
        }
        public int CheckIfBorrowed(string TicketRIFD)
        {

            String sql = "SELECT user_id FROM loan_transaction WHERE loan_has_item_item_i_rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            int user_id = 0; 
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["user_id"]);
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
    }
}