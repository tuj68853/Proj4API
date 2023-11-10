using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Review
    {

        string username;
        string restaurant;
        string comment;
        string foodQuality;
        string service;
        string atmosphere;
        string priceLevel;


        public Review(string username, string restaurant, string comment, string foodQuality, string service, string atmosphere, string priceLevel)
        {
            this.username = username;
            this.restaurant = restaurant;
            this.comment = comment;
            this.foodQuality = foodQuality;
            this.service = service;
            this.atmosphere = atmosphere;
            this.priceLevel = priceLevel;

        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public string FoodQuality
        {
            get { return foodQuality; }
            set { foodQuality = value; }
        }
        public string Service
        {
            get { return service; }
            set { service = value; }
        }
        public string Atmosphere
        {
            get { return atmosphere; }
            set { atmosphere = value; }
        }
        public string PriceLevel
        {
            get { return priceLevel; }
            set { priceLevel = value; }
        }
    }
}
