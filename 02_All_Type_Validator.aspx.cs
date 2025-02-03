
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class All_Type_Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Process the form data
                string phoneNumber = txtPhoneNumber.Text;
                string email = txtEmail.Text;
                string pinNumber = txtPinNumber.Text;
                string salary = txtSalary.Text;
                string aadhaarCard = txtAadhaarCard.Text;
                string panCard = txtPANCard.Text;
                string empCode = txtEmpCode.Text;

                // Example: Save to database or perform some action

                
                
            }
        }
    }
}