using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class log_updates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string updateQuery = "INSERT INTO C_ContactInfo (Email, Phone) VALUES (@Email, @Phone)";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            cmd.ExecuteNonQuery();
                        }

                        string logQuery = "INSERT INTO C_ContactInfoLog (Email, Phone, UpdateDate) VALUES (@Email, @Phone, @UpdateDate)";
                        using (SqlCommand cmd = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        lblNotification.Text = "Yes";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblNotification.Text = "Error updating contact information: " + ex.Message;
                    }
                }
            }
            else
            {
                lblNotification.Text = "Email and Phone are required.";
            }
        }
    }
}