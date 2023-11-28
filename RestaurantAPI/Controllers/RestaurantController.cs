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



        [HttpPost("AddReview")]   // POST api/Restaurant/AddReview/
        public Boolean AddReview([FromBody] Review review)
        {
            if (review != null)

            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateReviews";
                objCommand.Parameters.AddWithValue("@username_input", review.Username);
                objCommand.Parameters.AddWithValue("@restaurant_input", review.Restaurant);
                objCommand.Parameters.AddWithValue("@comment_input", review.Comment);
                objCommand.Parameters.AddWithValue("@foodQuality_input", review.FoodQuality);
                objCommand.Parameters.AddWithValue("@service_input", review.Service);
                objCommand.Parameters.AddWithValue("@atmosphere_input", review.Atmosphere);
                objCommand.Parameters.AddWithValue("@priceLevel_input", review.PriceLevel);

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


        [HttpGet("GetReviewsByUsername/{username}")]
        public List<Review> GetReviewsByUsername(string username)
        {
            List<Review> reviewList = new List<Review>();
            DBConnect objDB;
            SqlCommand objCommand;

            try
            {
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetReviewsByUsername";
                objCommand.Parameters.AddWithValue("@username_input", username);


                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                foreach (DataRow record in myDS.Tables[0].Rows)
                {
                    Review review = new Review
                    {
                        Restaurant = record["Restaurant"].ToString(),
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
                Console.WriteLine($"Error in GetReviewsByUsername: {ex.Message}");
                // You might want to throw the exception here or handle it in a way that makes sense for your application
            }
            return reviewList;
        }



        [HttpPost("AddReservation")]   // POST api/Restaurant/AddReservation/
        public Boolean AddReservation([FromBody] Reservation reservation)
        {
            if (reservation != null)

            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateReservations";
                objCommand.Parameters.AddWithValue("@restaurant_input", reservation.Restaurant);
                objCommand.Parameters.AddWithValue("@name_input", reservation.Name);
                objCommand.Parameters.AddWithValue("@date_input", reservation.Date);
                objCommand.Parameters.AddWithValue("@time_input", reservation.Time);
                objCommand.Parameters.AddWithValue("@contactPhone_input", reservation.ContactPhone);
                objCommand.Parameters.AddWithValue("@totalGuests_input", reservation.TotalGuests);
        
                
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



        [HttpPost("UpdateReviewsByRestaurant/{restaurant}")]
        public IActionResult UpdateReviewsByRestaurant(string restaurant, [FromBody] Review updatedReview)
        {
            if (updatedReview == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateReviewByRestaurant";
                objCommand.Parameters.AddWithValue("@review_restaurantname", restaurant);
                objCommand.Parameters.AddWithValue("@review_comment", updatedReview.Comment);
                objCommand.Parameters.AddWithValue("@review_fq", updatedReview.FoodQuality);
                objCommand.Parameters.AddWithValue("@review_service", updatedReview.Service);
                objCommand.Parameters.AddWithValue("@review_atmosphere", updatedReview.Atmosphere);
                objCommand.Parameters.AddWithValue("@review_pricelevel", updatedReview.PriceLevel);

                int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);

                if (rowsAffected > 0)
                {
                    return Ok("Review updated successfully");
                }
                else
                {
                    return NotFound("Review not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in UpdateReviewsByRestaurant: {ex.Message}");
                // You might want to throw the exception here or handle it in a way that makes sense for your application
                return StatusCode(500, "Internal Server Error");
            }
        }








    }
}
