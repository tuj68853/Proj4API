using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Utilities;

namespace Proj4API
{
    public partial class ReviewsPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblRestaurantName.Text = Session["restaurantName"].ToString();

            //// Set the SQLCommand object's properties for executing a Stored Procedure
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "GetReviewsByRestaurant";     // identify the name of the stored procedure to execute

            //objCommand.Parameters.AddWithValue("@Restaurant_Name", Session["restaurantName"].ToString());

            //// Fetch data from the stored procedure 
            //DataSet ds = objDB.GetDataSet(objCommand);

            //// Bind the DataTable to the GridView
            //gvReviews.DataSource = ds;
            //gvReviews.DataBind();


            //try
            //{

            // Check if the session variable is not null
            if (Session["restaurantName"] != null)
            {

                // Create a Web Request to fetch reviews based on the restaurant name
                WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/GetReviewsByRestaurant/" + Session["restaurantName"].ToString());

                // Get the Web Response
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response using streams
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                // Close the reader and release resources
                reader.Close();
                response.Close();

                // Deserialize the JSON string into a list of Review objects
                JavaScriptSerializer js = new JavaScriptSerializer();
                //Review[] reviews = js.Deserialize<Review[]>(data);
                List<Review> reviews = js.Deserialize<List<Review>>(data);

                // Bind the data to the GridView
                gvReviews.DataSource = reviews;
                gvReviews.DataBind();

                lblRestaurantName.Text = Session["restaurantName"].ToString();

            }
            else
            {
                // Handle the case where the session variable is null
                lblAlert.Text = "Error: The restaurant name is not available.";
            }


            //catch (Exception ex)
            //{
            //    // Log the exception or handle it based on your application's needs
            //    lblAlert.Text = $"Error: {ex.Message}";
            //}




        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}