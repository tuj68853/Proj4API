using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Utilities;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class RestaurantController : Controller
    {
        [HttpGet]

        public List<Restaurant> Get()

        {

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Restaurants");
            List<Restaurant> restaurants = new List<Restaurant>();

            Restaurant restaurant;

            foreach (DataRow record in ds.Tables[0].Rows)

            {
                restaurant = new Restaurant();
                restaurant.Name = record["Name"].ToString();
                restaurant.Color = record["Color"].ToString();
                restaurant.Quantity = record["Quantity"].ToString();

                restaurants.Add(restaurant);

            }
            return restaurants;

        }
    }
}
