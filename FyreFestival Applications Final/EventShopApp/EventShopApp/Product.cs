using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventShopApp
{
    class Product
    {
        public string P_rfid { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Qty { get; private set; }

        public Product(string p_rifd, string name, double price, int qty)
        {
            P_rfid = p_rifd;
            Name = name;
            Price = price;
            Qty = qty;
        }
        public string ToString()
        {
            return $"Product: {Name} Price: {Price}€ Qty: {Qty}";
        }
    }
}
