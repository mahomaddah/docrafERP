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
using System.Windows.Shapes;

namespace docrafERP.Views
{
    /// <summary>
    /// LoginPanel.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginPanel : Window
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void NavBarMove(object sender, MouseButtonEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new HomeView().ShowDialog();
 

        }
    }
}
