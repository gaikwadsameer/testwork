using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HyperLink_visible : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=test;Trusted_Connection=True;"; // Replace with your actual connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT UserID, UserName, RoleID FROM Users_r", conn); // Adjust query as per your schema
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                da.Fill(dt);

                GridViewUsers.DataSource = dt;
                GridViewUsers.DataBind();
            }
        }

        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                bool isActive = Convert.ToBoolean(rowView["RoleID"]);

                // Example: Disable link if user is not active
                HyperLink HyperLinkAction = (HyperLink)e.Row.FindControl("HyperLinkAction");
                if (!isActive)
                {
                    HyperLinkAction.Enabled = false;
                    HyperLinkAction.Style["color"] = "gray"; // Optionally change link color or style
                }
            }
        }
    }
}