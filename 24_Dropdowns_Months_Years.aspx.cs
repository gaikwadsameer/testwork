using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Dropdowns_Months_Years : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateYearDropdown();
                PopulateMonthDropdown();
            }
        }

        private void PopulateYearDropdown()
        {
            int currentYear = DateTime.Now.Year;

            for (int year = currentYear; year >= currentYear - 10; year--)
            {
                ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }
        }

        private void PopulateMonthDropdown()
        {
            // Get current month
            int currentMonth = DateTime.Now.Month;

            for (int month = 1; month <= 12; month++)
            {
                string monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                ddlMonth.Items.Add(new ListItem(monthName, month.ToString()));
            }

            // Set the selected month to the current month
            ddlMonth.SelectedValue = currentMonth.ToString();
        }

    }
}