using docrafERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// UCmanageSupplies.xaml etkileşim mantığı
    /// </summary>
    public partial class UCmanageSupplies : UserControl
    {

        public List<Supply> SuppliesForListview { get; set; }
        public List<string> SearchBarSuggestions { get; set; }
        public List<string> Projects { get; set; }

        public void RefreshAssetsListViewFromViewModel()
        {
            DataContext = this;
            Projects = new List<string>();
            // SingletoneHomeView.Instance.homeView.Supplies.ForEach(x => Projects.Add(x.project));
            SuppliesForListview = SingletoneHomeView.Instance.homeView.Supplies.ToList();
            LVsupplies.ItemsSource = SuppliesForListview;
            
        }

        public void refreshAssetsListViewFromList()
        {

            LVsupplies.ItemsSource = SingletoneHomeView.Instance.homeView.Supplies;
            ICollectionView view = CollectionViewSource.GetDefaultView(LVsupplies.ItemsSource);
            view.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAssetsListViewFromViewModel();
        }


        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        public UCmanageSupplies()
        {
            InitializeComponent();
        }

        private void SupplyDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVsupplies.SelectedIndex != -1)
            {
                var dialog = MessageBox.Show("Are you sure to delete the item ?", "Delete?", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    var temp = ((Supply)LVsupplies.SelectedItem);
                    SingletoneHomeView.Instance.homeView.Supplies.Remove(temp);
                    //database ... 
                    new DataAccessLayer.DataService().DeleteSupply(temp);
                    // reload list view
                    RefreshAssetsListViewFromViewModel();
                }
            }
        }

        private void SupplyEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVsupplies.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first....");
            }
            else
            {
                EditSupplie();
            }
        }

        private void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (LVsupplies.SelectedIndex != -1)
            {
                EditSupplie();
            }
        }

        private void EditSupplie()
        {
            var temp = ((Supply)LVsupplies.SelectedItem);
            SingletoneHomeView.Instance.homeView.editSupplyUC.EditingSupply = temp;
            SingletoneHomeView.Instance.homeView.editSupplyUC.ComeForAdding = false;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");
        }

        private void SupplyAddBtn_Click(object sender, RoutedEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.editSupplyUC.EditingSupply = new Supply();
            SingletoneHomeView.Instance.homeView.editSupplyUC.ComeForAdding = true;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");
        }

        private void AddNewTreeItem(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InventoryTree.SelectedItem!=null)
                ((TreeViewItem)InventoryTree.SelectedItem).Items.Add("new node");
            }
            catch
            {

            }
           
        }

        private void DeleteTreeItem(object sender, RoutedEventArgs e)
        {
            try {
                if (InventoryTree.SelectedItem != null)
                    InventoryTree.Items.Remove((TreeViewItem)InventoryTree.SelectedItem);
            } catch { MessageBox.Show("Onley Director can delete a program..."); }
       
        }

        private void SearchBarTB_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void SearchBarTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SearchBarTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void SupplyPirntBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            List<string> HeadersToSkip = new List<string> { "StockStatus" , "ImagePath" , "SupplyID" , "RemarksJson" , "PurchaseRequetID" , "DocumentsFolderPath" ,"" };

            if (HeadersToSkip.Contains( e.Column.Header.ToString()))
            {
                e.Cancel = true;
            }
        }
    }
}
