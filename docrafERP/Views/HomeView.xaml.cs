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

    /// HomeView.xaml etkileşim mantığı
namespace docrafERP
{
    /// <summary>
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();          
        }

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

        #region Dashboard Buttons:

        private void ManageAssetsClicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void ManageSuppliesClicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void purchaseRequestsClicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void issueDocumentsClicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void settingsPanelClicked(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        private void ProfileClicked(object sender, MouseButtonEventArgs e)
        {
          var result=  MessageBox.Show("Do you want to log out from the application?", "Sign out?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Hide();
                new LoginPanel().ShowDialog();
             
            }
        }

    }
}
