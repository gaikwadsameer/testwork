using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;

namespace WebApplication1
{
    public partial class AUTO_GENERATED_ID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                generatesno();
                TextBox1.Enabled = false;
            }
        }

        private void generatesno()
        {

            String mycon = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select addresse from Table_1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            scon.Close();
            if (ds.Tables[0].Rows.Count < 1)
            {
                TextBox1.Text = "DS001";

            }
            else
            {
                String mycon1 = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
                SqlConnection scon1 = new SqlConnection(mycon1);
                String myquery1 = "select addresse from Table_1";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = myquery1;
                cmd1.Connection = scon1;
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd1;
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                int maxsno = 0;
                var part1 = "0";
                var part2 = "0";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var sno = dr["addresse"].ToString();
                    part1 = sno.Substring(0, 2);
                    part2 = sno.Substring(2, (sno.Length) - 2);

                    if (maxsno < Convert.ToInt16(part2))
                    {
                        maxsno = Convert.ToInt16(part2);
                    }

                }

                maxsno = maxsno + 1;
                var newserial = part1 + maxsno.ToString("000");
                TextBox1.Text = newserial.ToString();
                scon1.Close();
            }
        }

    }
}