
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Overview_APP
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
        public int TotalCheckedInVisitors()
        {

            String sql = "SELECT SUM(type) FROM ticket WHERE type = @type";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@type", "1");
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalCampingSiteInVisitors()
        {

            String sql = "SELECT SUM(typeC) FROM ticket WHERE typeC = @type";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@type", "1");
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalVisitors()
        {

            String sql = "SELECT idUser FROM ticket";
            MySqlCommand command = new MySqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@type", 1);
            int Total = 0;
            try
            {
                connection.Open();
                Total = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {

                Total = 0;
                //System.Windows.Forms.MessageBox.Show("no connetion");
            }
            finally
            {
                connection.Close();
            }
            return Total;
        }
        public double TotalMoneySpentInShop()
        {

            String sql = "SELECT SUM(soldPrice) FROM shop_transaction";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalVisitorsBalance()
        {

            String sql = "SELECT SUM(balance) FROM user";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public double TotalMoneySpentInLoan()
        {

            String sql = "SELECT SUM(rentprice) FROM loan_transaction_up";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalBorrowedItems()
        {

            String sql = "SELECT COUNT(transactionId) FROM loan_transaction";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalProductsSold(string rfid)
        {

            String sql = "SELECT SUM(amount) FROM shop_transaction WHERE shop_has_product_product_p_rfid = @rfid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@rfid", rfid);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public string GetProductRfid(string product)
        {

            String sql = "SELECT p_rfid FROM product WHERE name = @product";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@product", product);
            string total ="";
            try
            {
                connection.Open();
                total = Convert.ToString(command.ExecuteScalar());
            }
            catch
            {

                total = "no";
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalTransLoan()
        {

            String sql = "SELECT COUNT(transactionId) FROM loan_transaction_up";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalTransShop()
        {

            String sql = "SELECT COUNT(transactionId) FROM shop_transaction";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int TotalTransAtm()
        {

            String sql = "SELECT COUNT(iddeposits) FROM deposits";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public double GetUserBalance(string name)
        {

            String sql = "SELECT balance FROM user WHERE unameUser = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int GetUserId(string name)
        {

            String sql = "SELECT idUser FROM user WHERE unameUser = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int GetVisitorStatus(int userId)
        {

            String sql = "SELECT type FROM ticket WHERE idUser = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
                int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int GetVisitorCamping(int userId)
        {

            String sql = "SELECT typeC FROM ticket WHERE idUser = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public double GetVisitorShopSpentMoney(int userId)
        {

            String sql = "SELECT sum(soldPrice*amount) FROM shop_transaction WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
    }
}
