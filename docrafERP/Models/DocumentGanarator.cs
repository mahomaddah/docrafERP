using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.VisualBasic.Tools.Applications.Runtime;


namespace docrafERP.Models
{
    public class DocumentGanarator
    {
        public void GenradeRIS(List<Supply> supplies , Personel ConsumingPerson , Personel SM )
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook sheet = excel.Workbooks.Open(@"C:\Users\asus\Desktop\SuppliesConsuming\Appendix 63 - Requisition and Issue Slip - RIS.xlsx");
            Excel.Worksheet worksheet = excel.ActiveSheet as Excel.Worksheet;

            // get data
            Excel.Range userRange = worksheet.UsedRange;
            //  int CountRecords = userRange.Rows.Count; 


            //set data
            int quantityToUse = 30;

            //Stock Number
            worksheet.Cells[12 , 1] =  supplies.First().Barcode;
            //Unit
            worksheet.Cells[12, 2] = 1;
            //Name Item
            worksheet.Cells[12, 3] = supplies.First().Name;
            //Qnt
            worksheet.Cells[12, 4] = quantityToUse;

            worksheet.Cells[12, 5] = "X";

            worksheet.Cells[12, 7] = quantityToUse;

            //Requested...
            //Person name
            worksheet.Cells[33, 3] = ConsumingPerson.Name;
            //Date
            worksheet.Cells[35, 3] = DateTime.Now.ToString();

            //Issued by
            //SM name
            worksheet.Cells[33, 6] = SM.Name;
            //Date
            worksheet.Cells[35, 6] = DateTime.Now.ToString();

            //Received by:
            //Person name
            worksheet.Cells[33, 8] = ConsumingPerson.Name;
            //Date
            worksheet.Cells[35, 8] = DateTime.Now.ToString();

            //1,3 olmali doh logo...

            // worksheet.Shapes.AddPicture(@"C:\Users\asus\Desktop\SuppliesConsuming\logoDoh.png",Microsoft.Office.Core.MsoTriState.msoFalse,Microsoft.Office.Core.MsoTriState.msoTrue , 1, 3, 1, -1);

            //where to save (temp) as pdf
            string pdfPath = @"C:\Users\asus\Desktop\SuppliesConsuming\RISFilled.pdf";

            if (System.IO.File.Exists(pdfPath))
            {
                System.IO.File.Delete(pdfPath);
            }

            sheet.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF , pdfPath );

            //for copying new excel...
            // sheet.Close(true, @"C:\Users\asus\Desktop\SuppliesConsuming\RISFilled.xlsx", Type.Missing);

            if (System.IO.File.Exists(pdfPath))
            {
                System.Diagnostics.Process.Start(pdfPath);
            }

            sheet.Close(false ,Type.Missing, Type.Missing);
            excel.Quit();
            //delete the temp file after converted to pdf....
        
            
        }
        
    }
}
