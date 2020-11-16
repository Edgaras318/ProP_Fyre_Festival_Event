using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_ATM_APP
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
        public void UpdateBalance (double amount, int selectedUser)
        {

            String sql = "UPDATE user SET balance = @amount WHERE idUser = @SelectedUser";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@SelectedUser", selectedUser);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("If rfid reader ofline you cannot add money");
            }
            finally
            {
                connection.Close();
            }
        }
        public void InsertDeposits(int userId, double amount)
        {
            String sql = "INSERT INTO deposits (idUser, depositAmount) VALUES (@idUser, @depositAmount)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@depositAmount", amount);
            command.Parameters.AddWithValue("@idUser", userId);
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
    }
}
