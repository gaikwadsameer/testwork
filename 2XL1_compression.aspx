<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2XL1_compression.aspx.cs" Inherits="WebApplication1._2XL1_compression" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Excel File Upload and Download</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">








    ok not use ( only compression )






</head>
<body>
  <form id="form1" runat="server">
        <div>
            <h2>Upload Two Excel Files</h2>

            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Button ID="UploadButton" runat="server" Text="Upload and Process" OnClick="UploadButton_Click" />
            
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br /><br />
            
            <asp:LinkButton ID="DownloadLink" runat="server" Visible="false" OnClick="DownloadFile_Click">Download Processed File</asp:LinkButton>
        </div>
    </form>
</body>
</html>
