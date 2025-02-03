<%@ Page Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication_githubtest.user.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <asp:Label ID="lbl_empcode" runat="server" Text="" Font-Size="20px"></asp:Label>
    </div>
    <div>
        <center>
            <asp:Label ID="Label7" runat="server" Text="WELCOME" Font-Bold="True"
                Font-Size="17pt" ForeColor="#996633" Visible="False"></asp:Label>
        </center>
        <table align="center" bgcolor="#CCFFCC" class="auto-style10" style="border: medium double #003300; color: #000000; background-color: white;">
            <tr>
                <td align="Center">&nbsp; &nbsp; 
                    <asp:Image ID="Image1" runat="server" Height="500px" ImageUrl="~/Images/TMH.png" Width="500px" />
                    &nbsp; &nbsp; 
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>
