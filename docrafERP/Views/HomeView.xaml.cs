using docrafERP.DataAccessLayer;
using docrafERP.Views;
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
using docrafERP.Models;

    /// HomeView.xaml etkileşim mantığı
namespace docrafERP
{
    /// <summary>
    /// </summary>
    public partial class HomeView : Window
    {
        public List<Asset> Assets { get; set; }
        public List<Supply> Supplies { get; set; }
        public List<PurchaseRequest> PurchaseRequests { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<AssetDocument> AssetDocuments { get; set; }

        public void GetData()
        {
            DataService dataService = new DataService();

            Assets = dataService.GetAllAssets();
            Supplies = dataService.GetAllSupplies();
            PurchaseRequests = dataService.GetAllPurchaseRequests();
            AssetDocuments= dataService.GetAllAssetDocuments();
            Images= dataService.GetAllImages();
        }

        public HomeView()
        {
            InitializeComponent();
            SingletoneHomeView.Instance.homeView = this;
            GetData();
        }

        

        #region WindowBasicButtons:

        public void NavBarMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ProfileClicked(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Do you want to log out from the application?", "Sign out?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Hide();
                new LoginPanel().ShowDialog();

            }
        }
        #endregion

        #region Dashboard Buttons:

        public void bringTheUC(string UCname)
        {
            //hide all (7 UC for now )

            editAssetUC.Visibility = Visibility.Hidden;
            editSupplyUC.Visibility = Visibility.Hidden;

            manageAssetsUC.Visibility = Visibility.Hidden;
            manageSuppliesUC.Visibility = Visibility.Hidden;
            settingsUC.Visibility = Visibility.Hidden;
            purchaseRequestsUC.Visibility = Visibility.Hidden;
            issueDocumentsUC.Visibility = Visibility.Hidden;

            //visible clicked one ( in dashboard one onley (5 UC for now ))

            LabelMainBlueTittleOnTop.Content = UCname;
            switch (UCname)
            {
                case "Manage Assets": { manageAssetsUC.Visibility = Visibility.Visible; break; }
                case "Manage Supplies": { manageSuppliesUC.Visibility = Visibility.Visible; break; }
                case "Settings": { settingsUC.Visibility = Visibility.Visible; break; }
                case "Purchase Requests Panel": { purchaseRequestsUC.Visibility = Visibility.Visible; break; }
                case "Issue Documents": { issueDocumentsUC.Visibility = Visibility.Visible; break; }
                case "Edit Asset": { editAssetUC.Visibility = Visibility.Visible; break; }
                case "Edit Supply": { editSupplyUC.Visibility = Visibility.Visible; break; }

            }
        }

        private void ManageAssetsClicked(object sender, MouseButtonEventArgs e)
        {
            bringTheUC("Manage Assets");
        }

        private void ManageSuppliesClicked(object sender, MouseButtonEventArgs e)
        {
            bringTheUC("Manage Supplies");
        }

        private void purchaseRequestsClicked(object sender, MouseButtonEventArgs e)
        {
            bringTheUC("Purchase Requests Panel");
        }

        private void issueDocumentsClicked(object sender, MouseButtonEventArgs e)
        {
            bringTheUC("Issue Documents");
        }

        private void settingsPanelClicked(object sender, MouseButtonEventArgs e)
        {
            bringTheUC("Settings");
        }


        #endregion

     
    }
}
