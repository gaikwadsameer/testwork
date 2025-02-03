<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02_All_Type_Validator.aspx.cs" Inherits="WebApplication1.All_Type_Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All_Type_Validator</title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please fix the following errors:" CssClass="error" />

            <!-- Phone Number -->
            <asp:TextBox ID="txtPhoneNumber" runat="server" />
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone number is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid phone number format." 
                ValidationExpression="\d{10}" CssClass="error" />

            <br />

            <!-- Email -->
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." 
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="error" />

            <br />

            <!-- PIN Number -->
            <asp:TextBox ID="txtPinNumber" runat="server" />
            <asp:RequiredFieldValidator ID="rfvPinNumber" runat="server" ControlToValidate="txtPinNumber" ErrorMessage="PIN number is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revPinNumber" runat="server" ControlToValidate="txtPinNumber" ErrorMessage="Invalid PIN number format." 
                ValidationExpression="\d{6}" CssClass="error" />

            <br />

            <!-- Salary -->
            <asp:TextBox ID="txtSalary" runat="server" />
            <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="txtSalary" ErrorMessage="Salary is required." CssClass="error" />
            <asp:RangeValidator ID="rvSalary" runat="server" ControlToValidate="txtSalary" ErrorMessage="Salary must be between 1000 and 1000000." 
                MinimumValue="1000" MaximumValue="1000000" Type="Double" CssClass="error" />

            <br />

            <!-- Aadhaar Card Number -->
            <asp:TextBox ID="txtAadhaarCard" runat="server" />
            <asp:RequiredFieldValidator ID="rfvAadhaarCard" runat="server" ControlToValidate="txtAadhaarCard" ErrorMessage="Aadhaar card number is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revAadhaarCard" runat="server" ControlToValidate="txtAadhaarCard" ErrorMessage="Invalid Aadhaar card number format." 
                ValidationExpression="\d{12}" CssClass="error" />

            <br />

            <!-- PAN Card Number -->
            <asp:TextBox ID="txtPANCard" runat="server" />
            <asp:RequiredFieldValidator ID="rfvPANCard" runat="server" ControlToValidate="txtPANCard" ErrorMessage="PAN card number is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revPANCard" runat="server" ControlToValidate="txtPANCard" ErrorMessage="Invalid PAN card number format." 
                ValidationExpression="[A-Z]{5}[0-9]{4}[A-Z]{1}" CssClass="error" />

            <br />

            <!-- Employee Code -->
            <asp:TextBox ID="txtEmpCode" runat="server" />
            <asp:RequiredFieldValidator ID="rfvEmpCode" runat="server" ControlToValidate="txtEmpCode" ErrorMessage="Employee code is required." CssClass="error" />
            <asp:RegularExpressionValidator ID="revEmpCode" runat="server" ControlToValidate="txtEmpCode" ErrorMessage="Invalid employee code format." 
                ValidationExpression="[A-Za-z0-9]{5,10}" CssClass="error" />

            <br />

            <!-- Submit Button -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
