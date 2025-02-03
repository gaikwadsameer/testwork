<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="10_sort_sreach_gridview.aspx.cs" Inherits="WebApplication1.sort_sreach_gridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>

        <asp:CheckBoxList ID="chkLocations" runat="server">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
        </asp:CheckBoxList>

        <asp:CheckBoxList ID="chkCategories" runat="server">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
        </asp:CheckBoxList>

        <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
        <asp:GridView ID="gvEmployees" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
