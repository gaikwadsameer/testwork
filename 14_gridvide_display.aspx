<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="14_gridvide_display.aspx.cs" Inherits="WebApplication1.gridvide_display" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grid View Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="RoleID" HeaderText="RoleID" />
                <asp:BoundField DataField="RoleName" HeaderText="RoleName" />
                <asp:ButtonField ButtonType="Button" CommandName="ShowDetails" Text="View Details" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
        </asp:GridView>
    </form>
</body>
</html>

