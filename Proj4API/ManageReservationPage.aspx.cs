using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Proj4API
{
    public partial class ManageReservationPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string currentRepresenative;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }

        private void GetData()
        {
            currentRepresenative = Session["CurrentUser"].ToString();
            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationsForUser";

            objCommand.Parameters.AddWithValue("@repUsername_input", currentRepresenative);

            try
            {
                DataSet ds = objDB.GetDataSet(objCommand);
                // Bind the DataTable to the GridView
                gvManageReservations.DataSource = ds.Tables[0];
                gvManageReservations.DataBind();
                objDB.CloseConnection();


                //objDB.DoUpdateUsingCmdObj(objCommand); // Execute the stored procedure
                //gvManageReservations.DataSource = objDB;
                //gvManageReservations.DataBind();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lblAlert.Text = "Error getting data for the reservation: " + ex.Message;
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void gvManageReservations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string reservationName = gvManageReservations.DataKeys[e.RowIndex].Values["ReservationName"].ToString();

            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservationByName";

            objCommand.Parameters.AddWithValue("@reservation_name", reservationName);

            try
            {
                objDB.DoUpdateUsingCmdObj(objCommand);
                GetData();
                lblAlert.Text = "Reservation deleted successfully";

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lblAlert.Text = "Error deleting the reservation: " + ex.Message;
            }
        }

        protected void gvManageReservations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManageReservations.EditIndex = e.NewEditIndex;
            GetData();
        }

        protected void gvManageReservations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvManageReservations.EditIndex = -1;
            GetData();
        }

        protected void gvManageReservations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string date = (gvManageReservations.Rows[e.RowIndex].FindControl("txtDate") as TextBox).Text;
            string time = (gvManageReservations.Rows[e.RowIndex].FindControl("txtTime") as TextBox).Text;

            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReservationByName";

            objCommand.Parameters.AddWithValue("@reservation_date", date);
            objCommand.Parameters.AddWithValue("@reservation_time", time);

            try
            {
                objDB.DoUpdateUsingCmdObj(objCommand); // Execute the stored procedure
                objDB.CloseConnection();
                gvManageReservations.EditIndex = -1;
                GetData(); // Refresh the data in the GridView
                lblAlert.Text = "Reservation updated successfully";

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lblAlert.Text = "Error updating the reservation: " + ex.Message;
            }



        }
    }
}