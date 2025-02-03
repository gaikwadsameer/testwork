using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class UserEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            string username = txtname.Text;
            string dataEntry = txtData.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            //using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                string query = "INSERT INTO UserEntries (UserName, DataEntry) VALUES (@UserName, @DataEntry)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@DataEntry", dataEntry);
                //cmd.Parameters.AddWithValue("@CreatedBy", username);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            //lblMessage.Text = "Data submitted successfully!";
            txtname.Text = "";
            txtData.Text = "";
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }
    }
}