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

namespace docrafERP.Views
{
    /// <summary>
    /// UCeditSupply.xaml etkileşim mantığı
    /// </summary>
    public partial class UCeditSupply : UserControl
    {
        public UCeditSupply()
        {
            InitializeComponent();
        }

        private void copyToCLipboardBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void ScanBarconeBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void GeneradeRandomBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void QRSaveAspicBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void QRwhatsappBtn(object sender, MouseButtonEventArgs e)
        {

        }

        private void PrintQRcodeBTn(object sender, MouseButtonEventArgs e)
        {

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
            //save first 
            SingletoneHomeView.Instance.homeView.bringTheUC("Manage Supplies");
        }
    }
}
