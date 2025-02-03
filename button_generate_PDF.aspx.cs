using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Image = iTextSharp.text.Image;

namespace WebApplication1
{
    public partial class button_generate_PDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePDF();
        }

        private void GeneratePDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=WatermarkedPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                string imagePath = Server.MapPath("images/A40.png");
                Image watermark = Image.GetInstance(imagePath);
                watermark.SetAbsolutePosition(0, 0);
                watermark.ScaleAbsolute(PageSize.A4.Width, PageSize.A4.Height);
                document.Add(watermark);

                Paragraph paragraph = new Paragraph("This is the page content with watermark background");
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph);

                document.Close();
                writer.Close();

                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }
    }
}