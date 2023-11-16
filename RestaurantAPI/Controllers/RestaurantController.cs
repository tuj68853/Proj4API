using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace RestaurantAPI.Controllers
{
    [Produces("application/json")]
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
                restaurant.Category = record["Category"].ToString();
                restaurant.Address = record["Address"].ToString();
                restaurant.AvgFoodQuality = record["AvgFoodQuality"].ToString();
                restaurant.AvgService = record["AvgService"].ToString();
                restaurant.AvgAtmosphere = record["AvgAtmosphere"].ToString();
                restaurant.AvgPriceLevel = record["AvgPriceLevel"].ToString();
                restaurant.Represenative = record["Represenative"].ToString();
                restaurants.Add(restaurant);

            }
            return restaurants;

        }

        [HttpPost()]                // POST api/Restaurant/
        [HttpPost("AddUser")]   // POST api/Restaurant/AddUser/
        public Boolean AddUser([FromBody] User user)
        {
            if (user != null)

            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateUsers";
                objCommand.Parameters.AddWithValue("@name_input", user.Name);
                objCommand.Parameters.AddWithValue("@phone_input", user.Phone);
                objCommand.Parameters.AddWithValue("@user_input", user.Username);
                objCommand.Parameters.AddWithValue("@password_input", user.Password);
                objCommand.Parameters.AddWithValue("@type_input", user.Type);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }






    }
}
