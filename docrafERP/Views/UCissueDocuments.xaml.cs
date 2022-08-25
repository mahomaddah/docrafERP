using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.ExcelToPdfConverter;
using System.Diagnostics;


namespace docrafERP.Views
{
    /// <summary>
    /// UCissueDocuments.xaml etkileşim mantığı
    /// </summary>
    public partial class UCissueDocuments : UserControl
    {
        public UCissueDocuments()
        {
            InitializeComponent();
        }

        string getSamplePdfPath(string SelectedItem)
        {
            string returning = Environment.CurrentDirectory + @"\sampleForms\";

            if (SelectedItem.Contains("56-RAWO")) 
            {
                returning += "56-RAWO" + ".pdf";
            }
            else if (SelectedItem.Contains("57-SLC"))
            {
                returning += "57-SLC" + ".pdf";
            }
            else if (SelectedItem.Contains("58-SC"))
            {
                returning += "58-SC" + ".pdf";
            }
            else if (SelectedItem.Contains("59-ICS"))
            {
                returning += "59-ICS" + ".pdf";
            }
            else if (SelectedItem.Contains("60-PR"))
            {
                returning += "60-PR" + ".pdf";
            }
            else if (SelectedItem.Contains("61-PO"))
            {
                returning += "61-PO" + ".pdf";
            }
            else if (SelectedItem.Contains("62-IAR"))
            {
                returning += "62-IAR" + ".pdf";
            }
            else if (SelectedItem.Contains("63-RIS"))
            {
                returning += "63-RIS" + ".pdf";
            }
            else if (SelectedItem.Contains("64-RSMI"))
            {
                returning += "64-RSMI" + ".pdf";
            }
            else if (SelectedItem.Contains("65-WMR"))
            {
                returning += "65-WMR" + ".pdf";
            }
            else if (SelectedItem.Contains("66-RPCI"))
            {
                returning += "66-RPCI" + ".pdf";
            }
            else if (SelectedItem.Contains("67-RAAF"))
            {
                returning += "67-RAAF" + ".pdf";
            }
            else if (SelectedItem.Contains("68-IPLC"))
            {
                returning += "68-IPLC" + ".pdf";
            }
            else if (SelectedItem.Contains("69-PC"))
            {
                returning += "69-PC" + ".pdf";
            }
            else if (SelectedItem.Contains("70-PPELC"))
            {
                returning += "70-PPELC" + ".pdf";
            }
            else if (SelectedItem.Contains("71-PAR"))
            {
                returning += "71-PAR" + ".pdf";
            }
            else if (SelectedItem.Contains("72-RHA"))
            {
                returning += "72-RHA" + ".pdf";
            }
            else if (SelectedItem.Contains("72-RHAS"))
            {
                returning += "72-RHAS" + ".pdf";
            }
            else if (SelectedItem.Contains("73-RPCPPE"))
            {
                returning += "73-RPCPPE" + ".pdf";
            }
            else if (SelectedItem.Contains("74-IIRUP"))
            {
                returning += "74-IIRUP" + ".pdf";
            }
            else if (SelectedItem.Contains("75-RLSDDP"))
            {
                returning += "75-RLSDDP" + ".pdf";
            }
            else if (SelectedItem.Contains("76-PTR"))
            {
                returning += "76-PTR" + ".pdf";
            }
            else if (SelectedItem.Contains("77-CIPLC"))
            {
                returning += "77-CIPLC" + ".pdf";
            }
            else if (SelectedItem.Contains("78-BAPC"))
            {
                returning += "78-BAPC" + ".pdf";
            }
            else if (SelectedItem.Contains("79-QRBA"))
            {
                returning += "79-QRBA" + ".pdf";
            }
            else if (SelectedItem.Contains("80-BRS-MDS"))
            {
                returning += "80-BRS-MDS" + ".pdf";
            }       
            return returning;
        }

        private void FormClicked(object sender, MouseButtonEventArgs e)
        {
            if (FormsLV.SelectedIndex != -1)
            {
                Process.Start(getSamplePdfPath(FormsLV.SelectedValue.ToString()));
            }
        }

        private void FormViewClicked(object sender, RoutedEventArgs e)
        {
            if (FormsLV.SelectedIndex != -1)
            {
                Process.Start(getSamplePdfPath(FormsLV.SelectedValue.ToString()));
            }
        }

        public void printDoc(string filePath)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = getSamplePdfPath(filePath)
            };
            p.Start();
        }

        private void FormPrintBtn(object sender, RoutedEventArgs e)
        {
            if (FormsLV.SelectedIndex != -1)
            {
                printDoc(FormsLV.SelectedValue.ToString());
            }
        }

        void excelToPDF(string inputPath , string PdfPath)
        {
            //Paid Lib.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                IWorkbook workbook = application.Workbooks.Open(inputPath, ExcelOpenType.Automatic);
                //Open the Excel document to convert
                ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);
                //Initialize PDF document
                PdfDocument pdfDocument = new PdfDocument();
                //Convert Excel document into PDF document
                pdfDocument = converter.Convert();
                //Save the PDF file
                pdfDocument.Save(PdfPath);
                //This will open the PDF file so, the result will be seen in default PDF viewer
                System.Diagnostics.Process.Start(PdfPath);
            }
        }


    }
}
