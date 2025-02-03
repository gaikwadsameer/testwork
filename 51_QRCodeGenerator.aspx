<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="51_QRCodeGenerator.aspx.cs" Inherits="WebApplication1._51_QRCodeGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QR Code Generator and Scanner</title>

</head>
<body>
    <form id="form1" runat="server">


        <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Username"></asp:TextBox>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate QR Code" OnClick="btnGenerate_Click" />
        <asp:Image ID="imgQRCode" runat="server" Width="200px" Height="200px" />

        <br />

     <%--   <!-- Username input with autocomplete -->
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Username" autocomplete="off" list="usernameList"></asp:TextBox>
        <datalist id="usernameList">
            <!-- Options will be dynamically populated by C# code-behind -->
        </datalist>--%>

        <!-- Button to redirect to the new URL -->
        <asp:Button ID="btnRedirect" runat="server" Text="Go to Profile" OnClick="btnRedirect_Click" />

        <!-- Username input with autocomplete -->
        <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Username" autocomplete="off" oninput="autoRedirect()" />
        <datalist id="usernameList">
            <!-- Options populated by C# code-behind -->
        </datalist>

        <ul id="usernameSuggestions" style="list-style-type:none; padding: 0; margin: 0;"></ul>

        <!-- Script to handle automatic redirection -->
        <script type="text/javascript">
            function autoRedirect() {
                var username = document.getElementById('<%= txtUsername.ClientID %>').value.trim();

                // Redirect only if a username is entered
                if (username) {
                    // Encode the username for URL safety
                    var encodedUsername = encodeURIComponent(username);

                    // Construct the redirect URL with the username
                    var redirectUrl = "https://www.c-sharpcorner.com/profile?username=" + encodedUsername;

                    // Redirect to the constructed URL
                    window.location.href = redirectUrl;
                }
            }
        </script>


    </form>

    <script type="text/javascript">
        document.getElementById('<%= btnRedirect.ClientID %>').onclick = function () {
            var username = document.getElementById('<%= txtUsername.ClientID %>').value.trim();
            if (username === "") {
                alert("Please enter a username.");
                return false; // Prevents the postback if username is empty
            }
            return true; // Allows postback for valid input
        };
    </script>

    <script type="text/javascript">
        // Function to populate the textbox with the clicked username
        function populateUsername(username) {
            document.getElementById('<%= txtUsername.ClientID %>').value = username;
        }
</script>
</body>
</html>
