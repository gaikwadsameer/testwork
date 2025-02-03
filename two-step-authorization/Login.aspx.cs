using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class Login : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("ConnectionString");
        public string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Users_type FROM Users_type WHERE Username=@Username ";//AND Password=@Password
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                //cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //Session["Users_type"] = reader["Users_type"];
                    ///bool isFirstAuthorized = (bool)reader["IsFirstAuthorized"];
                    Response.Redirect("foradmin.aspx");
                    //if (!isFirstAuthorized)
                    //    Response.Redirect("foradmin.aspx");// FirstAuth.aspx");
                    //else
                    //    Response.Redirect("foradmin.aspx");//SecondAuth.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid login.";
                }
            }
        }

    }
}