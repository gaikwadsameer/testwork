<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="button_generate_PDF.aspx.cs" Inherits="WebApplication1.button_generate_PDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Watermark Background</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background-image: url('/images/watermark.png'); 
            background-repeat: no-repeat;
            background-size: cover;
            opacity: 0.3; 
        }
        .content {
            text-align: center;
            margin-top: 100px;
            font-size: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div class="content">
        <h1>This is the page content with watermark background12345678</h1>
        <p>Click the button below to download this page as PDF0987654321.</p>
        <form action="DownloadPDF" method="post">
            <button type="submit">Download as PDF</button>
        </form>
    </div>
</body>
</html>
