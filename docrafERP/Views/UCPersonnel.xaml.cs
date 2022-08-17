using docrafERP.Models;
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
        public List<Personel> Personels { get; set; }
        public UCPersonnel()
        {
            DataContext = this;

            Personels = new List<Personel>();
            this.IsVisibleChanged += UCPersonnel_IsVisibleChanged;
            InitializeComponent();
            
        }

        private void UCPersonnel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          

            

            if(Visibility == Visibility.Visible)
            {
                
                Personels = SingletoneHomeView.Instance.homeView.Personels.ToList();
                if(Personels.Count!=0)
                LVpersonels.ItemsSource = Personels;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Personels.Remove(((Personel)LVpersonels.SelectedItem));
                if (Personels.Count != 0)
                    LVpersonels.ItemsSource = Personels;
            }
            catch { }
        }

    

        private void Add_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
