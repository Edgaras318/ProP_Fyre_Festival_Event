using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_LoanStore
{
    class Shop
    {
        public int Shop_id { get; private set; }
        public int Amount { get; private set; }
        public string Product_p_rfid { get; private set; }
        public Shop(int shop_id, int amount, string product_p_rfid)
        {
            Shop_id = shop_id;
            Amount = amount;
            Product_p_rfid = product_p_rfid;
        }
    }
}
