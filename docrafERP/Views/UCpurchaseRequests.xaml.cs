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
    /// UCpurchaseRequests.xaml etkileşim mantığı
    /// </summary>
    public partial class UCpurchaseRequests : UserControl
    {
        public void RefreshAssetsListViewFromList()
        {

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
    }
}
