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



        [HttpPost("Login")]
        public bool Login([FromBody] User user)
        {
            if (user != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "FindUsers";
                objCommand.Parameters.AddWithValue("@username_input", user.Username);
                objCommand.Parameters.AddWithValue("@password_input", user.Password);
                objCommand.Parameters.AddWithValue("@type_input", user.Type);

                // Execute the stored procedure and get the result as a DataSet
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int loginResult = Convert.ToInt32(ds.Tables[0].Rows[0]["LoginResult"]);

                    // Check if the login was successful
                    return loginResult == 1;
                }

            }
            return false;
        }


        [HttpGet("GetReviewsByRestaurant/{restaurant}")]
        public List<Review> GetReviewsByRestaurant(string restaurant)
        {
            List<Review> reviewList = new List<Review>();
            DBConnect objDB;
            SqlCommand objCommand;

            try
            {
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetReviewsByRestaurant";
                objCommand.Parameters.AddWithValue("@Restaurant_Name", restaurant);
                

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                foreach (DataRow record in myDS.Tables[0].Rows)
                {
                    Review review = new Review
                    {
                        Username = record["Username"].ToString(),
                        Comment = record["Comment"].ToString(),
                        FoodQuality = record["FoodQuality"].ToString(),
                        Service = record["Service"].ToString(),
                        Atmosphere = record["Atmosphere"].ToString(),
                        PriceLevel = record["PriceLevel"].ToString(),
                    };

                    reviewList.Add(review);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in GetReviewsByRestaurant: {ex.Message}");
                // You might want to throw the exception here or handle it in a way that makes sense for your application
            }
            return reviewList;
        }







    }
}
