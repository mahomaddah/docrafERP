using docrafERP.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// UCpurchaseRequests.xaml etkileşim mantığı
    /// </summary>
    public partial class UCpurchaseRequests : UserControl
    {
        public void RefreshAssetsListViewFromList()
        {
            //Asset Status :  + Requested 

            //PR Status: 0 , Requested , Accounting Approved , Director Approved ( PO linked ) ,Ordered, Accepting by SM, Available 

            PurchaseRequestsLV.ItemsSource = SingletoneHomeView.Instance.homeView.PurchaseRequests;
            ICollectionView view = CollectionViewSource.GetDefaultView(PurchaseRequestsLV.ItemsSource);
            view.Refresh();
        }
        public UCpurchaseRequests()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAssetsListViewFromList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PurchaseRequestsLV.SelectedIndex != -1)
            {
                var dialog = MessageBox.Show("Are you sure to delete the item ?", "Delete?", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    var temp = ((Models.PurchaseRequest)PurchaseRequestsLV.SelectedItem);
                    SingletoneHomeView.Instance.homeView.PurchaseRequests.Remove(temp);
                    //database ... 
                    new DataAccessLayer.DataService().DeletePurchaseRequest(temp);
                    // reload list view
                    RefreshAssetsListViewFromList();
                }
            }
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewAssetPR(object sender, RoutedEventArgs e)
        {
            //assets edit panel    
            SingletoneHomeView.Instance.homeView.editAssetUC.EditingAsset = new Asset { Status = "Requested" };
            SingletoneHomeView.Instance.homeView.editAssetUC.ComeForAdding = true;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
            var PR = new PurchaseRequest { IsApproved = false, IssuedDate = DateTime.Now.ToString(), ProductName = SingletoneHomeView.Instance.homeView.CurrentUser.Name };
            new DataAccessLayer.DataService().InsertPurchaseRequest(PR);
            SingletoneHomeView.Instance.homeView.PurchaseRequests.Add(PR);
            RefreshAssetsListViewFromList();
        }

        private void NewSuppPR(object sender, RoutedEventArgs e)
        {
            //supply edit panel

            SingletoneHomeView.Instance.homeView.editSupplyUC.EditingSupply = new Supply { StockStatus = "Requested" };
            SingletoneHomeView.Instance.homeView.editSupplyUC.ComeForAdding = true;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");

            var PR = new PurchaseRequest { IsApproved = false, IssuedDate = DateTime.Now.ToString(), ProductName = SingletoneHomeView.Instance.homeView.CurrentUser.Name };
            new DataAccessLayer.DataService().InsertPurchaseRequest(PR);
            SingletoneHomeView.Instance.homeView.PurchaseRequests.Add(PR);
            RefreshAssetsListViewFromList();
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {

            //    var dialog = MessageBox.Show("Do you want to Request new Assets or supplies? \nnote: Yes: Assets \nNo: Supplies", "New Request?", MessageBoxButton.YesNoCancel);
            //if (dialog == MessageBoxResult.Yes)
            //{
            //    //assets edit panel    
            //    SingletoneHomeView.Instance.homeView.editAssetUC.EditingAsset = new Asset { Status = "Requested" };
            //    SingletoneHomeView.Instance.homeView.editAssetUC.ComeForAdding = true;
            //    SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
            //    var PR = new PurchaseRequest { IsApproved = false, IssuedDate = DateTime.Now.ToString(), ProductName = SingletoneHomeView.Instance.homeView.CurrentUser.Name };
            //    new DataAccessLayer.DataService().InsertPurchaseRequest(PR);
            //    SingletoneHomeView.Instance.homeView.PurchaseRequests.Add(PR);
            //    RefreshAssetsListViewFromList();
            //}
            //else if (dialog == MessageBoxResult.No)
            //{
            //    //supply edit panel

            //    SingletoneHomeView.Instance.homeView.editSupplyUC.EditingSupply = new Supply { StockStatus = "Requested" };
            //    SingletoneHomeView.Instance.homeView.editSupplyUC.ComeForAdding = true;
            //    SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");

            //    var PR = new PurchaseRequest { IsApproved = false, IssuedDate = DateTime.Now.ToString(), ProductName = SingletoneHomeView.Instance.homeView.CurrentUser.Name };
            //    new DataAccessLayer.DataService().InsertPurchaseRequest(PR);
            //    SingletoneHomeView.Instance.homeView.PurchaseRequests.Add(PR);
            //    RefreshAssetsListViewFromList();

            //}

        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            string pofile = Environment.CurrentDirectory + @"\sampleForms\PR.pdf";

            printDoc(pofile);
        }

        public void printDoc(string filePath)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = filePath
            };
            p.Start();
        }

        private void SaveAsPDfClick(object sender, RoutedEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + @"\sampleForms\PR.pdf");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

      
    }
}
