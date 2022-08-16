using docrafERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// UCmanageAssets.xaml etkileşim mantığı
    /// </summary>
    public partial class UCmanageAssets : UserControl
    {
        public List<Asset> AssetsForListview { get; set; }
        public List<string> Locations { get; set; }
        public List<string> SearchBarSuggestions { get; set; }

        public void RefreshAssetsListViewFromViewModel()
        {
            DataContext = this;
            Locations = new List<string>();
            SingletoneHomeView.Instance.homeView.Assets.ForEach(x => Locations.Add(x.OwnerOrLocation));
            AssetsForListview = SingletoneHomeView.Instance.homeView.Assets.ToList();
            AssetGridView.ItemsSource = AssetsForListview;
            //refreshLisView(AssetsForListview);
        }

        public void refreshLisView(List<Asset> ItemSource)
        {
            AssetGridView.ItemsSource = ItemSource;
            ICollectionView view = CollectionViewSource.GetDefaultView(AssetGridView.ItemsSource);
            view.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAssetsListViewFromViewModel();
        }

        public UCmanageAssets()
        {
            SearchBarSuggestions = new List<string>();
            InitializeComponent();
        }

        private void AssetDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AssetGridView.SelectedIndex != -1)
            {
                var dialog = MessageBox.Show("Are you sure to delete the item ?","Delete?", MessageBoxButton.YesNo);
                if(dialog== MessageBoxResult.Yes)
                {
                    var tempAsset = ((Asset)AssetGridView.SelectedItem);
                    SingletoneHomeView.Instance.homeView.Assets.Remove(tempAsset);
                    //database ... 
                    new DataAccessLayer.DataService().DeleteAsset(tempAsset);
                    // reload list view
                    RefreshAssetsListViewFromViewModel();
                }
            }
               
        }

        private void AssetEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AssetGridView.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first....");
            }
            else
            {
                EditAsset();
            }
        }

        private void AssetAddBtn_Click(object sender, RoutedEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.editAssetUC.EditingAsset = new Asset();
            SingletoneHomeView.Instance.homeView.editAssetUC.ComeForAdding = true;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
        }

        private void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (AssetGridView.SelectedIndex != -1)
                EditAsset();
        }
        void EditAsset()
        {
            var tempAsset = ((Asset)AssetGridView.SelectedItem);
            SingletoneHomeView.Instance.homeView.editAssetUC.EditingAsset = tempAsset;
            SingletoneHomeView.Instance.homeView.editAssetUC.ComeForAdding = false;
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
        }

        void reloadFromSearchingMode()
        {
            if (SearchSnackBar.IsActive)
            {
                //error is over...
                SearchSnackBar.IsActive = false;
                SearchBarTB.Foreground = new SolidColorBrush(Colors.White);
            }


            if (SearchBarTB.Text == null || SearchBarTB.Text.Length <= 1)
            {
                //not searching

                SearchBarTB.IsDropDownOpen = false;
                AssetGridView.ItemsSource = AssetsForListview;
                AssetGridView.Visibility = Visibility.Visible;

            }
        }

        private void SearchBarTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            reloadFromSearchingMode();

            if (SearchBarTB.Text != null && SearchBarTB.Text.Length != 0 && e.Text != string.Empty)
            {
                
                List<Asset> searchedList = new List<Asset>();

                try
                {
                    //applied combo filters :
                    //applied Property based filters : Serial Number , Asset Name , Location

                    searchedList = SingletoneHomeView.Instance.homeView.Assets.FindAll(y => ( (FilterAssetName.IsSelected) && (y.Device.ToLower().Contains(SearchBarTB.Text.ToLower())) ) || ( (FilterSerialNumber.IsSelected) && (y.Barcode.ToLower().Contains(SearchBarTB.Text.ToLower())) ) || ((FilterPrice.IsSelected) && (y.PurchasePrice.ToLower().Contains(SearchBarTB.Text.ToLower()))) || ((FilterLocation.IsSelected) && (y.OwnerOrLocation.ToLower().Contains(SearchBarTB.Text.ToLower()))));
                }
                catch
                {

                }

                if (searchedList != null && searchedList.Count != 0)
                {
                    AssetGridView.ItemsSource = searchedList;

                    SearchBarSuggestions.Clear();
                   

                    foreach( var asset in searchedList)
                    {
                        if (FilterAssetName.IsSelected)
                        {
                            SearchBarSuggestions.Add(asset.Device);
                        }

                        if (FilterSerialNumber.IsSelected)
                        {
                            SearchBarSuggestions.Add(asset.Barcode);
                        }

                        if (FilterPrice.IsSelected)
                        {
                            SearchBarSuggestions.Add(asset.PurchasePrice);
                        }

                        if (FilterLocation.IsSelected)
                        {
                            SearchBarSuggestions.Add(asset.OwnerOrLocation);
                        }
                    }

                    SearchBarTB.ItemsSource = SearchBarSuggestions;


                    AssetGridView.Visibility = Visibility.Visible;
                    

                }
                else
                {
                    //255,51,51
                    SearchBarTB.Foreground = new SolidColorBrush(Color.FromRgb(255, 7, 174));
                    SearchBarTB.IsDropDownOpen = false;
                    
                    AssetGridView.Visibility = Visibility.Hidden;
                    SearchSnackBar.IsActive = true;
                    //not found searching 

                }
            }

        }

        private void SearchBarTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Back)
            {
                reloadFromSearchingMode();
            }
        }

        private void SearchBarTB_MouseLeave(object sender, MouseEventArgs e)
        {
            if (SearchBarTB.Text == null || SearchBarTB.Text.Length <= 1)
                reloadFromSearchingMode();
        }

        private void PrintAssetBtn_Click(object sender, RoutedEventArgs e)
        {
            
            PrintDialog dialog = new PrintDialog();
          

     
            Visual visual = AssetGridView;
            Visual logo = SingletoneHomeView.Instance.homeView.logoPart;



            //var stak = new StackPanel { };
            //stak.Orientation = Orientation.Vertical;
            //stak.Children.Add(SingletoneHomeView.Instance.homeView.logoPart);
            //stak.Children.Add(AssetGridView);

            //Visual Goal = stak; 


            // System.Windows.Media.Geometry.Combine(, visual, GeometryCombineMode.Union, visualGoal)


            //   VisualCollection visuals = new VisualCollection(AssetGridView);

            //  visuals.Add(SingletoneHomeView.Instance.homeView.logoPart);

            dialog.PrintVisual( visual, "");
          


        }

        private void AssetFilterSLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {      

        }



        private void FilterAccountCodeSelected(object sender, RoutedEventArgs e)
        {
        //    MessageBox.Show("accountCodeSelected...");
        }

        private void FilterAccountCode_Unselected(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("Bye...");
        }



    }

}
