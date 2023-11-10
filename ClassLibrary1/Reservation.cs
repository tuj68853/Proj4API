using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Reservation
    {
        int id;
        string restaurant;
        string name;
        string date;
        string time;
        string contactPhone;
        string totalGuests;

        public Reservation(string restaurant, string name, string date, string time, string contactPhone, string totalGuests)
        {
            this.name = name;
            this.restaurant = restaurant;
            this.date = date;
            this.time = time;
            this.contactPhone = contactPhone;
            this.totalGuests = totalGuests;

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }

        public string TotalGuests
        {
            get { return totalGuests; }
            set { totalGuests = value; }
        }


    }
}
