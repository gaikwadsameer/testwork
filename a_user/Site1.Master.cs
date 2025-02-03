using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.a_user
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string empcode;
        string strsql;
        string strSql;
        SqlCommand cmd;
        SqlDataReader rdr;

        SqlDataAdapter DA;
        DataTable DT;
        SqlConnection connc;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        DataSet ds;
        SqlDataAdapter da;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Tax.Visible = false;
            //try
            //{
            //    if (Session["username"] != null)
            //    {
            //        // lbl_empcode.Text = "Welcome : "+ Session["empcode"].ToString();
            //        empcode = Session["username"].ToString();
            //        DisPhoto();
            //        Empdetails();
            //        Check_Authorization();
            //    }
            //    else
            //    {
            //        Session.Clear();
            //        Session.Abandon();
            //        Response.Redirect("frm_login1.aspx");
            //    }
            //}
            //catch (Exception)
            //{
            //    Session.Clear();
            //    Session.Abandon();
            //    Response.Redirect("frm_login2.aspx");
            //}
        }
        public void DisPhoto()   // FUNCTION FOR DISPLAY PHOTO
        {

        }
        public void Empdetails()
        {
            //try
            //{
            //    if (conn.State == ConnectionState.Closed)
            //    {
            //        conn.Open();
            //    }
            //    strsql = "select userID,username, password FROM Users_r WHERE username=?";
            //    cmd = new SqlCommand(strsql, conn);
            //    cmd.Parameters.AddWithValue("username", empcode.Trim());
            //    dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        lbl_empcode.Text = dr["username"].ToString().Trim() + ", " + dr["password"].ToString().Trim();

            //    }
            //    else
            //    {
            //        lbl_empcode.Text = "";
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        public void Check_Authorization()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //hyper_frm_paycodewise_Report.Visible = false;
            //hyper_Tax_modification_authority.Visible = false;
            //hyper_frm_paycodewise_Report1.Visible = false;
            //Tax.Visible = false;

            //strsql = "select a.username, a.password,B.roleID,b.RoleName from users_r A RIGHT JOIN Roles B ON A.RoleID = B.RoleID where a.username='z'"; 
            //cmd = new SqlCommand(strsql, conn);
            //dr = cmd.ExecuteReader();

            //while (dr.Read() == true)
            //{

            //    if (dr["rolename"].ToString().Trim() == "frm_paycodewise_Report")
            //    {
            //        //hyper_frm_paycodewise_Report.Visible = true;
            //    }
            //    else if (dr["rolename"].ToString().Trim() == "Tax_modification_authority")
            //    {
            //        //hyper_Tax_modification_authority.Visible = true;
            //    }
            //    else if (dr["rolename"].ToString().Trim() == "Tax_modification_authority")
            //    {
            //        //hyper_frm_paycodewise_Report1.Visible = true;
            //    }
            //    else if (dr["rolename"].ToString().Trim() == "Tax")
            //    {
            //        Tax.Visible = true;
            //    }
            //}
        }
    }
}