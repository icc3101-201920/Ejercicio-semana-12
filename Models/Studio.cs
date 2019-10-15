using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Studio
    {
        string name;
        string address;
        DateTime openingDate;

        public Studio(string name, string address, DateTime openingDate)
        {
            this.name = name;
            this.address = address;
            this.openingDate = openingDate;
        }

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public DateTime OpeningDate { get => openingDate; set => openingDate = value; }

        int maxLength()
        {
            if (Address.Length > 20)
                return 20;
            else
                return Address.Length;
        }
        public override string ToString()
        {
            return Name + ", DATA | Opening Date: " + OpeningDate.ToShortDateString() + " | Address: " + Address.Substring(0, maxLength()) + "... |";
        }
    }
}
