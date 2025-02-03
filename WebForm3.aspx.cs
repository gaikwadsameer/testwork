using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection conn = new SqlConnection("ConnectionString"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT u.Username, r.RoleName FROM A_Users u JOIN A_Roles r ON u.RoleID = r.RoleID WHERE u.Username = @Username AND u.Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["Username"] = reader["Username"].ToString();
                    Session["Role"] = reader["RoleName"].ToString();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                }
            }
        }
    }
}