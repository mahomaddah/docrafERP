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
            string returning= Environment.CurrentDirectory + @"\sampleForms\";
            if (SelectedItem.Contains("ICS"))
            {
                returning += "ICS" + ".pdf";
            }
            else if (SelectedItem.Contains("PO"))
            {
                returning += "PO" + ".pdf";
            }
            else if (SelectedItem.Contains("PR"))
            {
                returning += "PR" + ".pdf";
            }
            else if (SelectedItem.Contains("PAR"))
            {
                returning += "PAR" + ".pdf";
            }
            else if (SelectedItem.Contains("IIRUP"))
            {
                returning += "IIRUP" + ".pdf";
            }
            else if (SelectedItem.Contains("RPCPPE"))
            {
                returning += "RPCPPE" + ".pdf";
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
