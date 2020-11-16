using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EventShopApp
{
    class DbConnection
    {
        public MySqlConnection connection;
        public int Qty { get; private set; }
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
        public void ProductNamePrice(string TicketRIFD)
            {

                String sql = "SELECT name, price, p_rfid FROM Product WHERE p_rfid = @TicketRIFD";
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
                        Rfid = (reader["p_rfid"]).ToString();
                }
                }
                catch (Exception e)
                {

                Name = "This item does not exist";
                Price = -1;
                Qty = -1;
                Rfid = "not exist";
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
                finally
                {
                    connection.Close();
                }
            }
        public void ProductQty(string TicketRIFD)
        {

            String sql = "SELECT amount FROM shop_has_product WHERE product_p_rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            //string name = "";
            // double price = 0;
            //int qty = 0;
            Qty = -1;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Qty = Convert.ToInt32(reader["amount"]);
                    //Price = Convert.ToDouble(reader["price"]);
                   //Name = (reader["name"]).ToString();
                }
            }
            catch (Exception e)
            {

               // Name = "This item does not exist";
               // Price = -1;
                Qty = -1;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
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
        public void UpdateQty(string rfid, int qty)
        {
            String sql = "UPDATE shop_has_product SET amount = @qty WHERE product_p_rfid = @rfid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@rfid", rfid);
            command.Parameters.AddWithValue("@qty", qty);
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
        public void InsertTransction(int userId, int amount, int shopId, string product_rfid, double soldPrice)
        {
            String sql = "INSERT INTO shop_transaction (user_id, amount,shop_has_product_shop_id ,shop_has_product_product_p_rfid, soldPrice) VALUES (@idUser, @amount, @shopId, @product_rfid, @soldPrice)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@idUser", userId);
            command.Parameters.AddWithValue("@shopId", shopId);
            command.Parameters.AddWithValue("@product_rfid", product_rfid);
            command.Parameters.AddWithValue("@soldPrice", soldPrice);

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
        public int SelectShopId(string TicketRIFD)
        {

            String sql = "SELECT shop_id FROM shop_has_product WHERE product_p_rfid = @TicketRIFD";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TicketRIFD", TicketRIFD);
            int shopId = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    shopId = Convert.ToInt32(reader["shop_id"]);
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
    }
    }