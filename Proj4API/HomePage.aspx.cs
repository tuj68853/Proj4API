using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Proj4API
{
    public partial class HomePage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        String strSQL = "";
        string currentUser;
        DataSet myDS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //If session is not blank meaning an account was created as current user
                if (Session["CurrentUser"] != null)
                {
                    // User just created an account
                    currentUser = Session["CurrentUser"].ToString();
                    lblSignUpNote.Visible = false;
                    lblHello.Text = "Hello! you are signed in as " + currentUser;
                    btnCreateAccount.Visible = false;
                    btnSignIn.Visible = false;
                    btnLogout.Visible = true;

                    if (Session["CurrentUserType"].ToString() == "Member")
                    {
                        //Show that the user is able to make review 
                        btnWriteReview.Visible = true;


                    }
                    if (Session["CurrentUserType"].ToString() == "Represenative")
                    {
                        //show that the user could do a higher level access
                        btnManageInfo.Visible = true;
                        btnManageReservations.Visible = true;

                    }
                }

                //////binding data to visitor gv

                //strSQL = "SELECT * FROM Restaurants";
                //myDS = objDB.GetDataSet(strSQL);
                //gvVisitor.DataSource = myDS;
                //// Set the DataKeyNames collection to store the ProductNumber in a DataKeys collection.
                //// This is needed when you want to use primary keys in columns of a GridView and hide those columns.
                //// Hidden columns are not rendered into HTML making the unavailable through the Cells collection of a Rom.
                String[] names = new String[1];
                names[0] = "Name";
                gvVisitor.DataKeyNames = names;
                gvVisitor.DataBind();






                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("http://localhost:50241/api/Restaurant"); 
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();

                Restaurant[] restaurants = js.Deserialize<Restaurant[]>(data);
                gvVisitor.DataSource = restaurants;
                gvVisitor.DataBind();



            }
        }

        public void DisplaySortForVisitor(String sortKey)

        {
            String strSQL = "SELECT * FROM Restaurants ORDER BY '" + sortKey + "'";
            gvVisitor.DataSource = objDB.GetDataSet(strSQL);
            gvVisitor.DataBind();
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void ddlSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySortForVisitor(ddlSortBy.SelectedValue);
        }

        protected void gvVisitor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get the index of the row that a command was issued on
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            // Get the ProductNumber from the DataKeys colletion of the row
            // The values were previously stored in the DataKeys collection during the DataBind method
            // because the GridView control's property DataKeyNames="ProductNumber"

            if (e.CommandName == "MakeReservation")
            {
                String restaurantName = gvVisitor.DataKeys[rowIndex].Value.ToString();
                Session["restaurantName"] = restaurantName;
                Response.Redirect("MakeReservationForm.aspx");
            }

            if (e.CommandName == "ViewReviews")
            {
                string restaurantName = gvVisitor.DataKeys[rowIndex].Value.ToString();
                Session["restaurantName"] = restaurantName;
                Response.Redirect("ReviewsPage.aspx");
            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Session.Clear();
            lblSignUpNote.Visible = true;
            lblHello.Visible = false;
            btnCreateAccount.Visible = true;
            btnSignIn.Visible = true;
            btnLogout.Visible = false;
            btnWriteReview.Visible = false;
            btnManageInfo.Visible = false;
            btnManageReservations.Visible = false;

        }

        protected void btnWriteReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberReviewsPage.aspx");
        }

        protected void btnManageReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageReservationPage.aspx");
        }

        protected void btnManageInfo_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void gvVisitor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}