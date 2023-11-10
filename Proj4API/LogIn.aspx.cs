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
    public partial class LogIn : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            String strSQL = "";

            //binding data to control boxes
            if (!IsPostBack)
            {
                strSQL = "SELECT * FROM Account";
                rblAccountType.DataSource = objDB.GetDataSet(strSQL);
                rblAccountType.DataTextField = "Type";
                rblAccountType.DataBind();

            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FindUsers";
            objCommand.Parameters.AddWithValue("@username_input", txtUser.Text);
            objCommand.Parameters.AddWithValue("@type_input", rblAccountType.SelectedItem.Text);
            ds = objDB.GetDataSet(objCommand);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string currentUsername = txtUser.Text;
                string currentUserType = rblAccountType.SelectedItem.Text;
                Session["CurrentUser"] = currentUsername;
                Session["CurrentUserType"] = currentUserType;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblAlert.Text = "ERROR: Your account does not exist, Please enter a different Username!";
                txtUser.Text = "";
            }

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}