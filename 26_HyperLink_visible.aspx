<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="26_HyperLink_visible.aspx.cs" Inherits="WebApplication1.HyperLink_visible" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Form with Username and Hyperlink</title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewUsers_RowDataBound">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="User ID" />
        <asp:BoundField DataField="UserName" HeaderText="User Name" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLinkAction" runat="server" Text="Edit" NavigateUrl='<%# Eval("UserID", "EditUser.aspx?UserID={0}") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    </form>
</body>
</html>
