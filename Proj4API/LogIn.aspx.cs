using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Utilities;
using ClassLibrary1;
using System.Web.Mvc;

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


            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "FindUsers";
            //objCommand.Parameters.AddWithValue("@username_input", txtUser.Text);
            //objCommand.Parameters.AddWithValue("@type_input", rblAccountType.SelectedItem.Text);
            //ds = objDB.GetDataSet(objCommand);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    string currentUsername = txtUser.Text;
            //    string currentUserType = rblAccountType.SelectedItem.Text;
            //    Session["CurrentUser"] = currentUsername;
            //    Session["CurrentUserType"] = currentUserType;
            //    Response.Redirect("HomePage.aspx");
            //}
            //else
            //{
            //    lblAlert.Text = "ERROR: Your account does not exist, Please enter a different Username!";
            //    txtUser.Text = "";
            //}
            // Find a record in the database using the web service method that returns a Customer object
            // Create an HTTP Web Request and get the HTTP Web Response from the server.



            //WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant" + "/GetUserByUserPass/" + txtUser.Text + "/" + txtPassword.Text + "/" + rblAccountType.Text);
            //WebResponse response = request.GetResponse();

            //// Read the data from the Web Response, which requires working with streams.
            //Stream theDataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(theDataStream);
            //String data = reader.ReadToEnd();
            //reader.Close();
            //response.Close();

            //// Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //User user = js.Deserialize<User>(data);
            //if (user != null)
            //{
            //    Session["CurrentUser"] = user.Username;
            //    Session["CurrentUserType"] = user.Type;
            //    Response.Redirect("HomePage.aspx");
            //}
            //else
            //{
            //    lblAlert.Text = "ERROR: Your account does not exist, Please try again!";
            //    txtUser.Text = "";
            //    txtPassword.Text = "";
            //}







            if (txtUser.Text == "" || txtPassword.Text == "" || rblAccountType.SelectedItem == null)
            {
                lblAlert.Text = "Please enter your credentials";
            }
            else
            {
                try
                {
                    // Create a User object to send to the API
                    User loginUser = new User
                    {
                        Username = txtUser.Text,
                        Password = txtPassword.Text,
                        Type = rblAccountType.SelectedItem.ToString()
                    };

                    // Serialize the User object into a JSON string
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonUser = js.Serialize(loginUser);

                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server
                    WebRequest request = WebRequest.Create("http://localhost:5292/api/Restaurant/Login/");
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                    {
                        writer.Write(jsonUser);
                        writer.Flush();
                    }

                    // Get the HTTP Web Response from the server
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams
                    using (Stream theDataStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(theDataStream))
                    {
                        string data = reader.ReadToEnd();

                        // Deserialize the JSON string into a boolean (login result)
                        bool loginResult = js.Deserialize<bool>(data);

                        if (loginResult)
                        {
                            // If login is successful, store the current username in a session
                            Session["CurrentUser"] = loginUser.Username;
                            Session["CurrentUserType"] = loginUser.Type;
                            Response.Redirect("HomePage.aspx");
                        }
                        else
                        {
                            lblAlert.Text = "ERROR: Your account does not exist, Please try again!";
                            txtUser.Text = "";
                            txtPassword.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblAlert.Text = "Error: " + ex.Message;
                }
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