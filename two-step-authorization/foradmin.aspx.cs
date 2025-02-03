using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1.two_step_authorization
{
    public partial class foradmin : System.Web.UI.Page
    {
        public string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    //Response.Redirect("Login.aspx");
            //}
            //else
            //{
            LoadData();
            //    //if (Session["Role"].ToString() == "User")
            //    //{
            //    //    BtnAddEntry.Visible = true;
            //    //}
            //}
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "";

                //        if (Session["Users_type"].ToString() == "Admin")
                //        {
                query = "SELECT * FROM DataEntry";
                //        }
                //        else if (Session["Users_type"].ToString() == "User")
                //        {
                //            query = "SELECT * FROM DataEntries WHERE Status IN ('Entry', 'Pending')";
                //        }
                //        else
                //        {
                //            query = "SELECT * FROM DataEntries WHERE Status = 'Verified'";
                //        }

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Verify")
            {
                int entryID = Convert.ToInt32(e.CommandArgument);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE DataEntry SET Status='Verified' WHERE UserID=@UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", entryID);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        protected void BtnAddEntry_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO DataEntry (UserID, DataText, Status) VALUES (@UserID, @DataText, 'Entry')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                //cmd.Parameters.AddWithValue("@DataText", TxtDataEntry.Text);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            //Session.Abandon();
            //Response.Redirect("Login.aspx");
        }
    }
}