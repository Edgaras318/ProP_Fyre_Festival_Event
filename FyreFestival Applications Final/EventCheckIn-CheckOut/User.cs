using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCheckIn_CheckOut
{
    class User
    {
        private int id;
        private String name;
        private String email;
        private double balance;

        public User(int id, String name, String email, double balance)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.balance = balance;
        }

        public int ID { get { return this.id; } }
        public String Name { get { return this.name; } }
        public String Email { get { return this.email; } }
        public double Balance { get { return this.balance; } }
        
        public string ToString()
        {
            return $"Name: {name}";
        }
    }

}
