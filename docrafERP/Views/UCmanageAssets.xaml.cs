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
    /// UCmanageAssets.xaml etkileşim mantığı
    /// </summary>
    public partial class UCmanageAssets : UserControl
    {
        public UCmanageAssets()
        {
            InitializeComponent();
        }

        private void AssetDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVassets.SelectedIndex != -1)
                LVassets.Items.Remove(LVassets.SelectedItem);
        }

        private void AssetEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVassets.SelectedIndex == -1)
            {
                MessageBox.Show("Please select and item first....");
            }
            else
            {
                SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
            }
        }

        private void AssetAddBtn_Click(object sender, RoutedEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
        }

        private void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (LVassets.SelectedIndex != -1)
                SingletoneHomeView.Instance.homeView.bringTheUC("Edit Asset");
        }
    }
}
