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
    public partial class MakeReservationForm : System.Web.UI.Page
    {
        string restaurantName;

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        ArrayList ReservationList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            restaurantName = Session["restaurantName"].ToString();
            lblRestaurantName.Text = restaurantName;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (txtReservationName.Text == "" || txtReservationDate.Text == "" || txtReservationTime.Text == "" || txtContactPhone.Text == "" || txtTotalGuests.Text == "")
            //{
            //    lblAlert.Text = "Please fill out everything on this form";
            //}
            //else
            //{
            //    Reservation newReservation = new Reservation(restaurantName, txtReservationName.Text, txtReservationDate.Text, txtReservationTime.Text, txtContactPhone.Text, txtTotalGuests.Text);
            //    // Set the SQLCommand object's properties for executing a Stored Procedure
            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "CreateReservations";     // identify the name of the stored procedure to execute

            //    objCommand.Parameters.AddWithValue("@restaurant_input", newReservation.Restaurant.ToString());
            //    objCommand.Parameters.AddWithValue("@name_input", newReservation.Name.ToString());
            //    objCommand.Parameters.AddWithValue("@date_input", newReservation.Date.ToString());
            //    objCommand.Parameters.AddWithValue("@time_input", newReservation.Time.ToString());
            //    objCommand.Parameters.AddWithValue("@contactPhone_input", newReservation.ContactPhone.ToString());
            //    objCommand.Parameters.AddWithValue("@totalGuests_input", newReservation.TotalGuests.ToString());
            //    objDB.DoUpdateUsingCmdObj(objCommand);
            //    lblAlert.Text = "You successfully booked a reservation!";

            //    txtReservationName.Text = "";
            //    txtReservationDate.Text = "";
            //    txtReservationTime.Text = "";
            //    txtContactPhone.Text = "";
            //    txtTotalGuests.Text = "";

            //}





            if (txtReservationName.Text == "" || txtReservationDate.Text == "" || txtReservationTime.Text == "" || txtContactPhone.Text == "" || txtTotalGuests.Text == "")
            {
                lblAlert.Text = "Please fill out everything on this form";
            }
            else
            {
                Reservation newReservation = new Reservation(lblRestaurantName.Text, txtReservationName.Text, txtReservationDate.Text, txtReservationTime.Text, txtContactPhone.Text, txtTotalGuests.Text);

                newReservation.Restaurant = lblRestaurantName.Text;
                newReservation.Name = txtReservationName.Text;
                newReservation.Date = txtReservationDate.Text;
                newReservation.Time = txtReservationTime.Text;
                newReservation.ContactPhone = txtContactPhone.Text;
                newReservation.TotalGuests = txtTotalGuests.Text;


                // Serialize a User object into a JSON string.
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonReservation = js.Serialize(newReservation);
                try
                {
                    // Send the User object to the Web API that will be used to store a new customer record in the database.
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/AddReservation/");

                    request.Method = "POST";
                    request.ContentLength = jsonReservation.Length;
                    request.ContentType = "application/json";
                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonReservation);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    txtReservationName.Text = "";
                    txtReservationDate.Text = "";
                    txtReservationTime.Text = "";
                    txtContactPhone.Text = "";
                    txtTotalGuests.Text = "";
                    lblAlert.Text = "You successfully booked a reservation!";

                }
                catch (Exception ex)
                {
                    lblAlert.Text = "Error: " + ex.Message;
                }
            }



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}