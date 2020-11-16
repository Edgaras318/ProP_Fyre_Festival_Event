using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CampingCheck_APP
{
    class Ticket
    {
        private int idTicket;
        private int idUser;
        private String rfid;
        private string typeTicket;
        private string idCampspot;
        private double priceTicket;
        private int type;

        public Ticket(int idTicket, int idUser, String rfid, string typeTicket, string idCampspot, double priceTicket, int type)
        {
            this.idTicket = idTicket;
            this.idUser = idUser;
            this.rfid = rfid;
            //this.balance = balance;
            this.typeTicket = typeTicket;
            this.priceTicket = priceTicket;
            this.idCampspot = idCampspot;
            this.type = type;
        }

        public int IdTicket { get { return this.idTicket; } }
        public int IdUser { get { return this.idUser; } }
        public String Rfid { get { return this.rfid; } }
        public string TypeTicket { get { return this.typeTicket; } }
        public String IdCampspot { get { return this.idCampspot; } }
        public double PriceTicket { get { return this.priceTicket; } }
        public int Type { get { return this.type; } }
        public void TypeString()
        {
            if (type == 0)
            {
                type = 1;
                //return "Checked In!";
            }
            else
            {
                type = 0;
                //return "Checked Out!";
            }
        }
        public string ToString()
        {
            string holder;
            if (type == 0)
            {
                holder = "Checked Out";
            }
            else
            {
                holder = "Checked In";
            }
            return holder;
        }
    }
}
