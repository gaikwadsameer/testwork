﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="WebApplication1.two_step_authorization.UserEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
