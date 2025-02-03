<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="15_gridview_data_not_found.aspx.cs" Inherits="WebApplication1.gridview_data_not_found" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dropdown to GridView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlSelection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSelection_SelectedIndexChanged">
                <asp:ListItem Value="1">Option 1</asp:ListItem>
                <asp:ListItem Value="2">Option 2</asp:ListItem>
                <asp:ListItem Value="3">Option 3</asp:ListItem>
            </asp:DropDownList>

            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="true">
            </asp:GridView>

            <div id="noDataDiv" runat="server" visible="false">
                No data found.
            </div>
        </div>
    </form>
</body>
</html>

