using ClassLibrary1;
using System;
using System.Collections;
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
            if (txtReservationName.Text == "" || txtReservationDate.Text == "" || txtReservationTime.Text == "" || txtContactPhone.Text == "" || txtTotalGuests.Text == "")
            {
                lblAlert.Text = "Please fill out everything on this form";
            }
            else
            {
                Reservation newReservation = new Reservation(restaurantName, txtReservationName.Text, txtReservationDate.Text, txtReservationTime.Text, txtContactPhone.Text, txtTotalGuests.Text);
                // Set the SQLCommand object's properties for executing a Stored Procedure
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateReservations";     // identify the name of the stored procedure to execute

                objCommand.Parameters.AddWithValue("@restaurant_input", newReservation.Restaurant.ToString());
                objCommand.Parameters.AddWithValue("@name_input", newReservation.Name.ToString());
                objCommand.Parameters.AddWithValue("@date_input", newReservation.Date.ToString());
                objCommand.Parameters.AddWithValue("@time_input", newReservation.Time.ToString());
                objCommand.Parameters.AddWithValue("@contactPhone_input", newReservation.ContactPhone.ToString());
                objCommand.Parameters.AddWithValue("@totalGuests_input", newReservation.TotalGuests.ToString());
                objDB.DoUpdateUsingCmdObj(objCommand);
                lblAlert.Text = "You successfully booked a reservation!";

                txtReservationName.Text = "";
                txtReservationDate.Text = "";
                txtReservationTime.Text = "";
                txtContactPhone.Text = "";
                txtTotalGuests.Text = "";

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}