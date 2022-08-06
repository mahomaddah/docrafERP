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
    /// UCPersonnel.xaml etkileşim mantığı
    /// </summary>
    public partial class UCPersonnel : UserControl
    {
        public UCPersonnel()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try {
                LVpersonels.Items.Remove(LVpersonels.SelectedItem);
            } catch { }
           
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
