using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Utilities;

namespace Proj4API
{
    public partial class RegisterForm : System.Web.UI.UserControl
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        ArrayList accountList = new ArrayList();




        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            User newUser = new User(txtName.Text, txtPhone.Text, txtUsername.Text, ddlAccountType.SelectedValue);
            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateUsers";     // identify the name of the stored procedure to execute

            objCommand.Parameters.AddWithValue("@name_input", newUser.Name.ToString());
            objCommand.Parameters.AddWithValue("@phone_input", newUser.Phone.ToString());
            objCommand.Parameters.AddWithValue("@user_input", newUser.Username.ToString());
            objCommand.Parameters.AddWithValue("@type_input", newUser.Type.ToString());
            objDB.DoUpdateUsingCmdObj(objCommand);

            //adding new user to a list and assign it to a session to retrieve the info later 
            accountList.Add(newUser);
            Session["NewAccount"] = accountList;

            //Storing the current username in a session
            Session["CurrentUser"] = newUser.Username;
            Session["CurrentUserType"] = newUser.Type;
            Response.Redirect("HomePage.aspx");



            txtName.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            ddlAccountType.SelectedIndex = 0;




        }
    }
}