using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_LoanStore
{
    class Item
    {
        public string P_rfid { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Item(string p_rifd, string name, double price)
        {
            P_rfid = p_rifd;
            Name = name;
            Price = price;
        }
        public string ToString()
        {
            return $"Item: {Name} Rent Price: {Price}€";
        }
    }
}
