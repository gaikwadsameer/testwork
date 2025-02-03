using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Web;
using System.Web.UI.WebControls;

//using static System.Net.WebRequestMethods;

namespace WebApplication1
{
    public partial class _2XL1_compression : System.Web.UI.Page
    {

        private string processedFilePath = HttpContext.Current.Server.MapPath("~/Processed/ProcessedData.xlsx");

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                try
                {
                    // Save uploaded files to temporary directory
                    string file1Path = SaveUploadedFile(FileUpload1);
                    string file2Path = SaveUploadedFile(FileUpload2);

                    // Process and compress Excel files
                    ProcessAndCompressFiles(file1Path, file2Path, processedFilePath);

                    // Show download link
                    StatusLabel.Text = "Files processed successfully!";
                    DownloadLink.Visible = true;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Please upload both files.";
            }
        }

        private string SaveUploadedFile(System.Web.UI.WebControls.FileUpload fileUpload)
        {
            string uploadPath = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            string filePath = Path.Combine(uploadPath, fileUpload.FileName);
            fileUpload.SaveAs(filePath);
            return filePath;
        }

        private void ProcessAndCompressFiles(string file1Path, string file2Path, string outputPath)
        {
            using (var package1 = new ExcelPackage(new FileInfo(file1Path)))
            using (var package2 = new ExcelPackage(new FileInfo(file2Path)))
            {
                var worksheet1 = package1.Workbook.Worksheets[0];
                var worksheet2 = package2.Workbook.Worksheets[0];

                // Merge data from two Excel files into a new Excel file
                using (var packageOutput = new ExcelPackage())
                {
                    var outputWorksheet = packageOutput.Workbook.Worksheets.Add("MergedData");

                    // Copy data from first Excel file
                    CopyWorksheetData(worksheet1, outputWorksheet, 1);

                    // Append data from second Excel file (below first file)
                    int lastRow = worksheet1.Dimension.End.Row + 1;
                    CopyWorksheetData(worksheet2, outputWorksheet, lastRow);

                    // Save the output file
                    if (!Directory.Exists(Path.GetDirectoryName(outputPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    }
                    packageOutput.SaveAs(new FileInfo(outputPath));
                }
            }
        }

        private void CopyWorksheetData(ExcelWorksheet source, ExcelWorksheet destination, int startRow)
        {
            for (int row = 1; row <= source.Dimension.End.Row; row++)
            {
                for (int col = 1; col <= source.Dimension.End.Column; col++)
                {
                    destination.Cells[startRow + row - 1, col].Value = source.Cells[row, col].Value;
                }
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            string filePath = processedFilePath;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ProcessedData.xlsx");
            Response.TransmitFile(filePath);
            Response.End();
        }

    }
}
