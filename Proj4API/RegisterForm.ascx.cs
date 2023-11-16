using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Script.Serialization;
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


            //User newUser = new User(txtName.Text, txtPhone.Text, txtUsername.Text, ddlAccountType.SelectedValue);
            //// Set the SQLCommand object's properties for executing a Stored Procedure
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "CreateUsers";     // identify the name of the stored procedure to execute

            //objCommand.Parameters.AddWithValue("@name_input", newUser.Name.ToString());
            //objCommand.Parameters.AddWithValue("@phone_input", newUser.Phone.ToString());
            //objCommand.Parameters.AddWithValue("@user_input", newUser.Username.ToString());
            //objCommand.Parameters.AddWithValue("@type_input", newUser.Type.ToString());
            //objDB.DoUpdateUsingCmdObj(objCommand);

            ////adding new user to a list and assign it to a session to retrieve the info later 
            //accountList.Add(newUser);
            //Session["NewAccount"] = accountList;

            ////Storing the current username in a session
            //Session["CurrentUser"] = newUser.Username;
            //Session["CurrentUserType"] = newUser.Type;
            //Response.Redirect("HomePage.aspx");

            if (txtName.Text == ""  || txtPhone.Text == "" || txtUsername.Text =="" || txtPassword.Text == "")
            {
                lblAlert.Text = "Please fill out all of the above";
            }
            else
            {
                User newUser = new User(txtName.Text, txtPhone.Text, txtUsername.Text, txtPassword.Text, ddlAccountType.SelectedValue);

                newUser.Name = txtName.Text;
                newUser.Phone = txtPhone.Text;
                newUser.Username = txtUsername.Text;
                newUser.Password = txtPassword.Text;
                newUser.Type = ddlAccountType.SelectedValue;


                // Serialize a Customer object into a JSON string.
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonUser = js.Serialize(newUser);
                try
                {
                    // Send the Customer object to the Web API that will be used to store a new customer record in the database.
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/AddUser/");

                    request.Method = "POST";
                    request.ContentLength = jsonUser.Length;
                    request.ContentType = "application/json";
                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonUser);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    //Storing the current username in a session
                    Session["CurrentUser"] = newUser.Username;
                    Session["CurrentUserType"] = newUser.Type;
                    Response.Redirect("HomePage.aspx");

                }
                catch (Exception ex)
                {
                    lblAlert.Text = "Error: " + ex.Message;
                }
            }
        }        
    }
}