using System;
using MessagingToolkit.Barcode;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.IO;
using MessagingToolkit.QRCode.Codec;
using docrafERP.Models;
using System.Drawing.Printing;

namespace docrafERP.Views
{
    /// <summary>
    /// UCeditAsset.xaml etkileşim mantığı
    /// </summary>
    public partial class UCeditAsset : UserControl
    {
        public Asset EditingAsset { get; set; }
        public bool ComeForAdding { get; set; }
        public List<AssetValueGauge> AssetGauge { get; private set; }
        public List<AssetValueGauge> valuePerYear { get; private set; }
        public List<YearDepreciation> YearsDepreciation { get; private set; }
        Bitmap lastQrimage;
        public UCeditAsset()
        {
            DataContext = this;

            YearsDepreciation = new List<YearDepreciation> { new YearDepreciation { BookedValue= "$960.40" , AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2022" } , new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2023" },new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2022" }, new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2023" }, new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2022" }, new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2023" }, new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2022" }, new YearDepreciation { BookedValue = "$960.40", AccumulatedDepreciation = "$19.60", DepreciationExpense = "$19.60", Year = "2023" } };

            int c = 0;      
            c = Convert.ToInt32(Convert.ToInt32(460)/10+1 / ((1 + Convert.ToInt32(1200))));
            AssetGauge = new List<AssetValueGauge> { new AssetValueGauge(98, "Net Value to Depreciable Cost"), new AssetValueGauge(290, "Asset life left") , new AssetValueGauge(c, "Salvage Value to Brand new price") };
            
            valuePerYear = new List<AssetValueGauge> { new AssetValueGauge(1200, "2022"), new AssetValueGauge(1100, "2023"), new AssetValueGauge(1000, "2024"), new AssetValueGauge(999, "2025"), new AssetValueGauge(850, "2026"), new AssetValueGauge(700, "2027"), new AssetValueGauge(600, "2028"), new AssetValueGauge(500, "2029"), new AssetValueGauge(450, "2030"), new AssetValueGauge(350, "2031"), new AssetValueGauge(200, "2032"), new AssetValueGauge(150, "2033"), new AssetValueGauge(100, "2034"), new AssetValueGauge(50, "2035"), new AssetValueGauge(30, "2036"), new AssetValueGauge(20, "2037"), new AssetValueGauge(2, "2038") };


            EditingAsset = new Asset();
            InitializeComponent();
            GetNewCode();


        }
        
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                if (ComeForAdding)
                {
                    SingletoneHomeView.Instance.homeView.LabelMainBlueTittleOnTop.Content = "Add a new Asset";
                }
                else
                {
                    SingletoneHomeView.Instance.homeView.LabelMainBlueTittleOnTop.Content = "Edit Asset";
                }
                //update data from object            
                // try { AssetImage.Source = EditingAsset.ImagePath } catch { } // for image ...
                TbDevice.Text = EditingAsset.Device;
                TbLocation.Text = EditingAsset.OwnerOrLocation;
                TbDate.Text = EditingAsset.DateReceived;
                TBserial.Text = EditingAsset.SerialNumber;
                TbStatus.Text = EditingAsset.Status;
                TBvendor.Text = EditingAsset.PurchasedVendor;
                TBPrice.Text = EditingAsset.PurchasePrice;
                // for bar code ....
                if (EditingAsset.Barcode != null && EditingAsset.Barcode != string.Empty) 
                {
                    EncryptionKeyTB.Text = EditingAsset.Barcode;
                    UpdateQRImage();
                }
                else
                {
                    GetNewCode();
                }

                //LVAssetDocs // For updating list view of document from path of related doc path in database and filse name on that folder...
            }
        }


        public void GetNewCode()
        {
            EncryptionKeyTB.Text = RandomString(12);
            UpdateQRImage();
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void UpdateQRImage()
        {
            // BarcodeEncoder encoder = new BarcodeEncoder();

            //  lastQrimage = BitmapFromWriteableBitmap(encoder.Encode(BarcodeFormat.Code39,EncryptionKeyTB.Text));

            QRCodeEncoder encoder = new QRCodeEncoder();

            encoder.QRCodeScale = 8;
            lastQrimage = encoder.Encode(EncryptionKeyTB.Text);
            
            QRcodeImage.Source = BitmapToImageSource(lastQrimage);
        }


        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
             
                return bitmapimage;
            }
        }

        private void copyToCLipboardBtn(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(EncryptionKeyTB.Text.ToString());
            MessageBox.Show("Test: Copied to clipboard...");
         
        }


        private void GeneradeRandomBtn(object sender, MouseButtonEventArgs e)
        {
            GetNewCode();
        }

        private void ScanBarconeBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void PrintQRcodeBTn(object sender, MouseButtonEventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = lastQrimage;
            System.Drawing.Point loc = new System.Drawing.Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }

        private void QRwhatsappBtn(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetImage(BitmapToImageSource(lastQrimage));
            MessageBox.Show("Image Coppied to clipboard...");
            try { Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WhatsApp\\WhatsApp.exe"); } catch { MessageBox.Show("Could not open whatsapp on " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WhatsApp\\WhatsApp.exe"); }

        }

        private void QRSaveAspicBtn(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "JPEG|*.jpeg";
            saveFileDialog.FileName = "QRcode";
            System.Windows.Forms.DialogResult dialog = saveFileDialog.ShowDialog();
            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                if (lastQrimage != null)
                {
                    lastQrimage.Save(string.Concat(saveFileDialog.FileName, ".jpeg"), ImageFormat.Png);                 
                }
            }
            else MessageBox.Show("Could not save...");
        }

        private void AddDocBtn(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DeleteDocBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void SavetoAssetBtn(object sender, MouseButtonEventArgs e)
        {
            if(EncryptionKeyTB.Text == "" || TbDevice.Text == "" || TbLocation.Text == "") { MessageBox.Show("Device name, Responsible person /Location, and Barcode fields cannot be empty..."); }
            else
            {
                EditingAsset.Barcode = EncryptionKeyTB.Text;
                EditingAsset.DateReceived = TbDate.Text;
                EditingAsset.Device = TbDevice.Text;
                EditingAsset.OwnerOrLocation = TbLocation.Text;
                EditingAsset.PurchasedVendor = TBvendor.Text;
                EditingAsset.PurchasePrice = TBPrice.Text;
                EditingAsset.Status = TbStatus.Text;
                EditingAsset.SerialNumber = TBserial.Text;
                

                //save asset first...
                if (ComeForAdding)
                {
                    //1.textboxs to the object
                    //2.database
                    //3.MainWindow list 
                    //4.manage asset LV update

                    new DataAccessLayer.DataService().InsertAsset(EditingAsset);
                    SingletoneHomeView.Instance.homeView.Assets.Add(EditingAsset);
                    SingletoneHomeView.Instance.homeView.manageAssetsUC.RefreshAssetsListViewFromViewModel();
                }
                else
                {
                    //for editing ...

                    //1.textboxs to the object
                    //2.database
                    //3.MainWindow list 
                    //4.manage asset LV update

                    new DataAccessLayer.DataService().UpdateAsset(EditingAsset);

              
                    SingletoneHomeView.Instance.homeView.Assets.Remove(SingletoneHomeView.Instance.homeView.Assets.Find(x => x.AssetID == EditingAsset.AssetID));
                    SingletoneHomeView.Instance.homeView.Assets.Add(EditingAsset);

                    SingletoneHomeView.Instance.homeView.manageAssetsUC.RefreshAssetsListViewFromViewModel();
                }

                SingletoneHomeView.Instance.homeView.bringTheUC("Manage Assets");

            }
           
        }

        private void BacktoAssetBtn(object sender, MouseButtonEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.bringTheUC("Manage Assets");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void TypeCodeTB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }
        

        private void TypeCodeTB_KeyDown(object sender, KeyEventArgs e)
        {

            List<string> searchedList = ProductTypeCodes.ProductTypeAccountCodes.FindAll(x=>x.Contains(TypeCodeTB.Text)).ToList();
            if (searchedList != null && searchedList.Count!=0)
            {
                TypeCodeTB.IsDropDownOpen = true;
                TypeCodeTB.ItemsSource = searchedList;
                
            }
            else
            {
                TypeCodeTB.IsDropDownOpen = false;
            }

        }

        private void AssetImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "PNG|*.png|JPEG|*.jpeg";
            openFile.FileName = EditingAsset.Barcode+"AssetImage";
            System.Windows.Forms.DialogResult dialog = openFile.ShowDialog();
            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
               var image= System.Drawing.Image.FromFile(openFile.FileName);
                AssetImage.Source = new BitmapImage(new Uri(openFile.FileName));
                new DataAccessLayer.DataService().InsertImage(image);
            }
            //else MessageBox.Show("Could not Set the image...");
        }
    }
}
