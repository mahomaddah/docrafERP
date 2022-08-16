using docrafERP.Models;
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
using System.Drawing.Imaging;
using System.IO;
using MessagingToolkit.QRCode.Codec;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Drawing;



namespace docrafERP.Views
{
    /// <summary>
    /// UCeditSupply.xaml etkileşim mantığı
    /// </summary>
    public partial class UCeditSupply : UserControl
    {
        public Supply EditingSupply { get; set; }
        public bool ComeForAdding { get; set; }

        Bitmap lastQrimage;

        public UCeditSupply()
        {
            EditingSupply = new Supply();
            InitializeComponent();
            GetNewCode();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                if (ComeForAdding)
                {
                    SingletoneHomeView.Instance.homeView.LabelMainBlueTittleOnTop.Content = "Add a new Supply";
                }
                else
                {
                    SingletoneHomeView.Instance.homeView.LabelMainBlueTittleOnTop.Content = "Edit Supply";
                }
                //update data from object            
                // try { AssetImage.Source = EditingAsset.ImagePath } catch { } // for image ...
                TbName.Text = EditingSupply.Name;
                TbQty.Text = EditingSupply.Quantity;
                TbDate.Text = EditingSupply.ExpirationDate;
                TbLotNum.Text = EditingSupply.LotNumber;
                
                TbVendor.Text = EditingSupply.PurchasedVendor;
                TbPrice.Text = EditingSupply.PurchasePrice;
                // for bar code ....
                if (EditingSupply.Barcode != null && EditingSupply.Barcode != string.Empty)
                {
                    EncryptionKeyTB.Text = EditingSupply.Barcode;
                    UpdateQRImage();
                }
                else
                {
                    GetNewCode();
                }
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
            MessageBox.Show("Copied to clipboard...");
        }

        private void ScanBarconeBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void GeneradeRandomBtn(object sender, MouseButtonEventArgs e)
        {
            GetNewCode();
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

        private void QRwhatsappBtn(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetImage(BitmapToImageSource(lastQrimage));
            MessageBox.Show("Image Coppied to clipboard...");
            try { Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WhatsApp\\WhatsApp.exe"); } catch { MessageBox.Show("Could not open whatsapp on " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WhatsApp\\WhatsApp.exe"); }

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

        private void AddDocBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteDocBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void BacktoSupBtn(object sender, MouseButtonEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.bringTheUC("Manage Supplies");
        }

        private void SavetoSupBtn(object sender, MouseButtonEventArgs e)
        {
            if (EncryptionKeyTB.Text == "" || TbName.Text == "" || TbQty.Text == "") { MessageBox.Show("Supply name, Quantity, and Barcode fields cannot be empty..."); }
            else
            {
                EditingSupply.Barcode = EncryptionKeyTB.Text;
                EditingSupply.ExpirationDate = TbDate.Text;
                EditingSupply.Name = TbName.Text;
                EditingSupply.Quantity = TbQty.Text;
                EditingSupply.PurchasedVendor = TbVendor.Text;
                EditingSupply.PurchasePrice = TbPrice.Text;
                EditingSupply.LotNumber = TbLotNum.Text;


                //save asset first...
                if (ComeForAdding)
                {
                    //1.textboxs to the object
                    //2.database
                    //3.MainWindow list 
                    //4.manage asset LV update

                    new DataAccessLayer.DataService().InsertSupply(EditingSupply);
                    SingletoneHomeView.Instance.homeView.Supplies.Add(EditingSupply);
                    SingletoneHomeView.Instance.homeView.manageSuppliesUC.RefreshAssetsListViewFromViewModel();
                }
                else
                {
                    //for editing ...

                    //1.textboxs to the object
                    //2.database
                    //3.MainWindow list 
                    //4.manage asset LV update

                    new DataAccessLayer.DataService().UpdateSupply(EditingSupply);


                    SingletoneHomeView.Instance.homeView.Supplies.Remove(SingletoneHomeView.Instance.homeView.Supplies.Find(x => x.SupplyID == EditingSupply.SupplyID));
                    SingletoneHomeView.Instance.homeView.Supplies.Add(EditingSupply);

                    SingletoneHomeView.Instance.homeView.manageSuppliesUC.RefreshAssetsListViewFromViewModel();
                }
            }
                //save first 
                SingletoneHomeView.Instance.homeView.bringTheUC("Manage Supplies");
        }

      
    }
}
