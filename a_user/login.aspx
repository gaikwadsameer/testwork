<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.a_user.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="form-detail">
                <h2>User Login</h2>
                <div class="form-row">
                    <asp:TextBox ID="txtempcode" runat="server" CssClass="inputbox" placeholder="Enter the your Employee Code"></asp:TextBox>
                </div>
                <div class="form-row">
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="inputbox" placeholder="Enter the your employee portal password" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-row-last">
                    <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="button" OnClick="btnlogin_Click" />
                </div>
                <div class="label">
                    <asp:Label ID="Lbl_error" runat="server" Text="" CssClass="labeltext"></asp:Label>
                </div>
                <center>
              
                </center>
            </form>
</body>
</html>
