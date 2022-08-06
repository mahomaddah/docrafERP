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
        public void RefreshAssetsListViewFromList()
        {

            LVsupplies.ItemsSource = SingletoneHomeView.Instance.homeView.Supplies;
            ICollectionView view = CollectionViewSource.GetDefaultView(LVsupplies.ItemsSource);
            view.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAssetsListViewFromList();
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
                    RefreshAssetsListViewFromList();
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
  
            if (InventoryTree.SelectedItem!=null)
                InventoryTree.Items.Remove((TreeViewItem)InventoryTree.SelectedItem);
        }
    }
}
