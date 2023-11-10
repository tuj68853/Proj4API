using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Proj4API
{
    public partial class ReviewsPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblRestaurantName.Text = Session["restaurantName"].ToString();

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByRestaurant";     // identify the name of the stored procedure to execute

            objCommand.Parameters.AddWithValue("@Restaurant_Name", Session["restaurantName"].ToString());

            // Fetch data from the stored procedure 
            DataSet ds = objDB.GetDataSet(objCommand);

            // Bind the DataTable to the GridView
            gvReviews.DataSource = ds;
            gvReviews.DataBind();



        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}