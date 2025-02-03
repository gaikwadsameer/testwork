using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class sort_sreach_gridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initial setup can be done here
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string fromDate = txtFromDate.Text;
            string toDate = txtToDate.Text;
         
            string locations = string.Join("','", chkLocations.Items.Cast<ListItem>()
                                   .Where(li => li.Selected)
                                   .Select(li => li.Value));
            string categories = string.Join("','", chkCategories.Items.Cast<ListItem>()
                                        .Where(li => li.Selected)
                                        .Select(li => li.Value));

            // Ensure that selected items are not empty to avoid SQL syntax errors
            if (string.IsNullOrEmpty(locations))
            {
                locations = "''"; // To handle cases where no location is selected
            }
            if (string.IsNullOrEmpty(categories))
            {
                categories = "''"; // To handle cases where no category is selected
            }

            // Build the SQL query
            string query = "SELECT EmployeeName, JoinDate, Locations, Category FROM EmployeesLoctCate WHERE JoinDate BETWEEN @FromDate AND @ToDate " +
                "AND Locations IN ('" + locations + @"') AND Category IN ('" + categories + @"') ORDER BY JoinDate";



            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
                da.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();

                // Display the total count
                //lblTotalCount.Text = "Total Employees: " + dt.Rows.Count;
            }
        }
    }
}