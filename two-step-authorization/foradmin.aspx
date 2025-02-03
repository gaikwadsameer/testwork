<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="foradmin.aspx.cs" Inherits="WebApplication1.two_step_authorization.foradmin" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" />
                <asp:BoundField DataField="DataText" HeaderText="Data" />
                <asp:BoundField DataField="Status" HeaderText="Status" />

                
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="BtnVerify" runat="server" CommandName="Verify" CommandArgument='<%# Eval("UserID") %>' Text="Verify"  /> <%--Visible='<%# Session["Role"].ToString() == "Admin" %>'--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- Add Entry Section -->
        <%--<asp:TextBox ID="TxtDataEntry" runat="server" Placeholder="Enter data"></asp:TextBox>
        <asp:Button ID="BtnAddEntry" runat="server" Text="Add Entry" OnClick="BtnAddEntry_Click" Visible="false" />
        
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />--%>
    </form>
</body>
</html>
