<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="121_div_hide.aspx.cs" Inherits="WebApplication1.div_hide" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hide Div Example</title>
    <script type="text/javascript">
        function hideDiv() {
            var div = document.getElementById('myDiv');
            if (div) {
                div.style.display = 'none';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myDiv">
            This is the div to be hidden.
        </div>
        <asp:Button ID="btnHideDiv" runat="server" Text="Hide Div" OnClientClick="hideDiv(); return false;" />
    </form>
</body>
</html>

