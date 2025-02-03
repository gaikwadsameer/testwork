using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;


namespace WebApplication1
{
    public partial class _51_QRCodeGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the datalist with previous usernames (retrieve from your database or any data source)
                List<string> usernames = GetUsernames();

                foreach (string username in usernames)
                {
                    // Dynamically add options to the datalist for autocomplete
                    Literal option = new Literal
                    {
                        Text = $"<option value='{username}'></option>"
                    };
                    Page.Header.Controls.Add(option); // Adds to <datalist> with ID "usernameList"
                }
            }


            if (!IsPostBack)
            {
                // Retrieve usernames from your database (or any data source)
                List<string> usernames = GetUsernames();

                // Populate the datalist for autocomplete
                foreach (string username in usernames)
                {
                    // Create an option for each username
                    Literal option = new Literal
                    {
                        Text = $"<option value='{username}'></option>"
                    };
                    Page.Header.Controls.Add(option);
                }

                // Populate the clickable URL suggestions
                string suggestionHtml = "";
                foreach (string username in usernames)
                {
                    suggestionHtml += $"<li><a href='javascript:void(0);' onclick='populateUsername(\"{username}\")'>{username}</a></li>";
                }

                // Add the suggestions to the page
                // usernameSuggestions.InnerHtml = suggestionHtml;
            }
        }

        private List<string> GetUsernames()
        {
            // Retrieve usernames from database. Example hardcoded list:
            return new List<string> { "user1", "user2", "user3" };
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (!string.IsNullOrEmpty(username))
            {
                // Sanitize and validate the username as needed
                string url = $"https://stackoverflow.com/{HttpUtility.UrlEncode(username)}";

                // Redirect the user to the new URL
                Response.Redirect(url);
            }
            else
            {
                // Handle empty username case (e.g., show an error message)
            }
        }


        private string GenerateQRCode(string encryptedText)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(encryptedText, QRCodeGenerator.ECCLevel.Q);
                using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        // Convert to base64 to display on frontend
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            string base64Image = Convert.ToBase64String(byteImage);
                            return "data:image/png;base64," + base64Image;
                        }
                    }
                }
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string encryptedUsername = EncryptUsername(username);

            // Generate QR Code from the encrypted username
            string qrCodeImageUrl = GenerateQRCode(encryptedUsername);

            // Display the QR code
            imgQRCode.ImageUrl = qrCodeImageUrl;
        }

        private string EncryptUsername(string username)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(username));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }



    }

   
}