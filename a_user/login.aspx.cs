using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Data.Sql;
using System.Globalization;
using System.Web.Configuration;

namespace WebApplication1.a_user
{
    public partial class login : System.Web.UI.Page
    {
        string empcode;
        string password;

        SqlCommand cmd;
        SqlDataReader rdr;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        DataSet ds;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlTransaction trans;
        public string Total;
        string strsql;
        string strSql;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Get_Credentials()    // SELECT STATMENT -- (TO GET CREDENTIALS)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
              
                strsql = "SELECT A.username,A.password FROM Users_r A INNER JOIN Roles B ON A.RoleID = B.RoleID WHERE A.username = '" + txtempcode.Text.Trim() + "'";

                cmd = new SqlCommand(strsql, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    empcode = (dr["username"].ToString().Trim());
                    password = (dr["password"].ToString().Trim());
                }
                else
                {
                    password = "";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)   // BUTTON LOGIN CLICK EVENT 
        {
            
            if (txtempcode.Text.Trim() == "" && txtpassword.Text.Trim() == "")      // ENSURES / CHECK USER ENTERED USERID AND PASS
            {
                Lbl_error.Text = "Please enter the empcode and password";
            }
            else
            {
                Get_Credentials();  // CALL FUNCTION FOR USER CREDENTIALS

                if (txtempcode.Text.Trim() != empcode)
                {
                    //Lbl_error.Text = "Please Enter correct empcode";
                    Lbl_error.Text = "You are not authorized kindly contact Accounts IT Team";
                    txtempcode.Focus();
                }
                else if (txtpassword.Text.Trim() != password)
                {
                    Lbl_error.Text = "Please Enter correct password";
                    txtpassword.Focus();
                }
                else
                {
                    // IF USERID AND PASSWORD IS CORRECT REDIRECT TO OUR HOME PAGE

                    Session["username"] = txtempcode.Text.Trim();
                    Response.Redirect("home.aspx");
                }
            }

        }

    }
}