using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public partial class MemberReviewsPage : System.Web.UI.Page
    {
        string currentUser;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        ArrayList ReservationList = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetReviews();
            }

        }

        private void GetReviews()
        {
            //currentUser = Session["currentUser"].ToString();
            //lblUsername.Text = currentUser;
            //// Set the SQLCommand object's properties for executing a Stored Procedure
            //objCommand = new SqlCommand();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "GetReviewsByUsername";     // identify the name of the stored procedure to execute

            //objCommand.Parameters.AddWithValue("@username_input", currentUser);

            //try
            //{
            //    DataSet ds = objDB.GetDataSet(objCommand);
            //    // Bind the DataTable to the GridView
            //    gvMemberReviews.DataSource = ds.Tables[0];
            //    gvMemberReviews.DataBind();
            //    objDB.CloseConnection();

            //}
            //catch (Exception ex)
            //{
            //    // Handle any exceptions
            //    lblAlert.Text = "Error getting data for the reviews: " + ex.Message;
            //}


            // Check if the session variable is not null
            if (Session["currentUser"] != null)
            {
                currentUser = Session["currentUser"].ToString();
                lblUsername.Text = currentUser;

                // Create a Web Request to fetch reviews based on the restaurant name
                WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/GetReviewsByUsername/" + Session["CurrentUser"].ToString());

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
                gvMemberReviews.DataSource = reviews;
                gvMemberReviews.DataBind();

                

            }
            else
            {
                // Handle the case where the session variable is null
                lblAlert.Text = "Error: The restaurant name is not available.";
            }





        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {


        }

        protected void gvMemberReviews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMemberReviews.EditIndex = -1;
            GetReviews();
        }



        protected void gvMemberReviews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMemberReviews.EditIndex = e.NewEditIndex;
            GetReviews();
        }

        protected void gvMemberReviews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string restaurantName = gvMemberReviews.DataKeys[e.RowIndex].Value.ToString();
            string comment = (gvMemberReviews.Rows[e.RowIndex].FindControl("txtComment") as TextBox).Text;
            string fq = (gvMemberReviews.Rows[e.RowIndex].FindControl("txtFoodQuality") as TextBox).Text;
            string service = (gvMemberReviews.Rows[e.RowIndex].FindControl("txtService") as TextBox).Text;
            string atmosphere = (gvMemberReviews.Rows[e.RowIndex].FindControl("txtAtmosphere") as TextBox).Text;
            string pricelevel = (gvMemberReviews.Rows[e.RowIndex].FindControl("txtPriceLevel") as TextBox).Text;

            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReviewByRestaurant";

            objCommand.Parameters.AddWithValue("@review_restaurantname", restaurantName);
            objCommand.Parameters.AddWithValue("@review_comment", comment);
            objCommand.Parameters.AddWithValue("@review_fq", fq);
            objCommand.Parameters.AddWithValue("@review_service", service);
            objCommand.Parameters.AddWithValue("@review_atmosphere", atmosphere);
            objCommand.Parameters.AddWithValue("@review_pricelevel", pricelevel);


            try
            {
                objDB.DoUpdateUsingCmdObj(objCommand); // Execute the stored procedure
                objDB.CloseConnection();
                gvMemberReviews.EditIndex = -1;
                GetReviews(); // Refresh the data in the GridView
                lblAlert.Text = "Reviews updated successfully";

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lblAlert.Text = "Error updating Reviews: " + ex.Message;
            }




        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (txtRestaurantName.Text == "" || txtComment.Text == "" || txtFoodQuality.Text == "" || txtService.Text == "" || txtAtmosphere.Text == "" || txtPriceLevel.Text == "")
            //{
            //    lblAlert.Text = "Please fill out everything on the form to add a review";
            //}
            //else
            //{
            //    Review newReview = new Review(lblUsername.Text, txtRestaurantName.Text, txtComment.Text, txtFoodQuality.Text, txtService.Text, txtAtmosphere.Text, txtPriceLevel.Text);
            //    // Set the SQLCommand object's properties for executing a Stored Procedure
            //    objCommand = new SqlCommand();
            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "CreateReviews";     // identify the name of the stored procedure to execute

            //    objCommand.Parameters.AddWithValue("@username_input", newReview.Username.ToString());
            //    objCommand.Parameters.AddWithValue("@restaurant_input", newReview.Restaurant.ToString());
            //    objCommand.Parameters.AddWithValue("@comment_input", newReview.Comment.ToString());
            //    objCommand.Parameters.AddWithValue("@foodQuality_input", newReview.FoodQuality.ToString());
            //    objCommand.Parameters.AddWithValue("@service_input", newReview.Service.ToString());
            //    objCommand.Parameters.AddWithValue("@atmosphere_input", newReview.Atmosphere.ToString());
            //    objCommand.Parameters.AddWithValue("@priceLevel_input", newReview.PriceLevel.ToString());

            //    try
            //    {
            //        objDB.DoUpdateUsingCmdObj(objCommand);
            //        objDB.CloseConnection();
            //        GetReviews();
            //        txtRestaurantName.Text = "";
            //        txtComment.Text = "";
            //        txtFoodQuality.Text = "";
            //        txtService.Text = "";
            //        txtAtmosphere.Text = "";
            //        txtPriceLevel.Text = "";
            //        lblAlert.Text = "Review was successfully added";
            //    }
            //    catch (Exception ex)
            //    {
            //        lblAlert.Text = "Error adding the review: " + ex.Message;
            //    }
            //}



            if (txtRestaurantName.Text == "" || txtComment.Text == "" || txtFoodQuality.Text == "" || txtService.Text == "" || txtAtmosphere.Text == "" || txtPriceLevel.Text == "")
            {
                lblAlert.Text = "Please fill out everything on the form to add a review";
            }
            else
            {
                Review newReview = new Review(lblUsername.Text, txtRestaurantName.Text, txtComment.Text, txtFoodQuality.Text, txtService.Text, txtAtmosphere.Text, txtPriceLevel.Text);

                newReview.Username = lblUsername.Text;
                newReview.Restaurant = txtRestaurantName.Text;
                newReview.Comment = txtComment.Text;
                newReview.FoodQuality = txtFoodQuality.Text;
                newReview.Service = txtService.Text;
                newReview.Atmosphere = txtAtmosphere.Text;
                newReview.PriceLevel = txtPriceLevel.Text;


                // Serialize a User object into a JSON string.
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonReview = js.Serialize(newReview);
                try
                {
                    // Send the User object to the Web API that will be used to store a new customer record in the database.
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/AddReview/");

                    request.Method = "POST";
                    request.ContentLength = jsonReview.Length;
                    request.ContentType = "application/json";
                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonReview);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    GetReviews();
                    txtRestaurantName.Text = "";
                    txtComment.Text = "";
                    txtFoodQuality.Text = "";
                    txtService.Text = "";
                    txtAtmosphere.Text = "";
                    txtPriceLevel.Text = "";
                    lblAlert.Text = "Review was successfully added";

                }
                catch (Exception ex)
                {
                    lblAlert.Text = "Error: " + ex.Message;
                }
            }









        }

        protected void gvMemberReviews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string restaurantName = gvMemberReviews.DataKeys[e.RowIndex].Values["Restaurant"].ToString();

            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReviewByRestaurant";

            objCommand.Parameters.AddWithValue("@restaurant_name", restaurantName);

            try
            {
                objDB.DoUpdateUsingCmdObj(objCommand);
                GetReviews();
                lblAlert.Text = "Review deleted successfully";

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lblAlert.Text = "Error deleting the reservation: " + ex.Message;
            }
        }
    }
}