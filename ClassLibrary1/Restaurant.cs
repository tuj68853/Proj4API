using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Restaurant
    {
        string name;
        string category;
        string address;
        string avgFoodQuality;
        string avgService;
        string avgAtmosphere;
        string avgPriceLevel;
        


        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Category
        {
            get { return category; }
            set { this.category = value; }
        }
        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }
        public string AvgFoodQuality
        {
            get { return avgFoodQuality; }
            set { this.avgFoodQuality = value; }
        }
        public string AvgService
        {
            get { return avgService; }
            set { this.avgService = value; }
        }

        public string AvgAtmosphere
        {
            get { return avgAtmosphere; }
            set { this.avgAtmosphere = value; }
        }

        public string AvgPriceLevel
        {
            get { return avgPriceLevel; }
            set { this.avgPriceLevel = value; }
        }
        public Restaurant()
        {

        }


    }
}
