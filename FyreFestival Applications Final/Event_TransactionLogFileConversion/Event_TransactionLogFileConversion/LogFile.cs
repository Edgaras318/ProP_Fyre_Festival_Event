using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Event_TransactionLogFileConversion
{
    class LogFile
    {
        public string Iban { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Tuple<int, string>> Deposits { get; set; }
        public int NumberOfDeposits { get; set; }

        public LogFile()
        {
            Deposits = new List<Tuple<int, string>>();
        }

        public void ProcessFile(FileStream f, StreamReader sr)
        {
            string temp;

            Iban = sr.ReadLine();
            StartTime = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            EndTime = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

            NumberOfDeposits = int.Parse(sr.ReadLine());
            for (int i = 0; i < NumberOfDeposits; i++)
            {
                temp = sr.ReadLine();
                Deposits.Add(new Tuple<int, string>(int.Parse(temp.Split(' ')[0]), temp.Split(' ')[1].Replace(',', '.')));
            }
        }


    }
}

