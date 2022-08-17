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
    /// UCPersonnel.xaml etkileşim mantığı
    /// </summary>
    public partial class UCPersonnel : UserControl
    {
        public Personel ManipulatingPerson { get; set; }
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
            try 
            {
                ManipulatingPerson = new Personel { Role = "employee", Name = "new employee", MobileNumber = "", Email = "" };
                Personels.Add(ManipulatingPerson);

                LVpersonels.ItemsSource = Personels;
                ICollectionView view = CollectionViewSource.GetDefaultView(LVpersonels.ItemsSource);
                view.Refresh();
                
            }
            catch
            {

            }
          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (ManipulatingPerson != null)
                {

             
                var item = SingletoneHomeView.Instance.homeView.Personels.Find(y => ((y.Name.Equals(ManipulatingPerson.Name)) || (y.PersonelID == ManipulatingPerson.PersonelID)));
                if (item != null) 
                {
                    SingletoneHomeView.Instance.homeView.Personels.Remove(item);
                    Personels.Clear();
                    SingletoneHomeView.Instance.homeView.Personels.Add(ManipulatingPerson);
                        Personels = SingletoneHomeView.Instance.homeView.Personels;
                //  new DataAccessLayer.DataService().InsertPerson(ManipulatingPerson);
                    LVpersonels.ItemsSource = Personels;
                    ICollectionView view = CollectionViewSource.GetDefaultView(LVpersonels.ItemsSource);
                    view.Refresh();
                }
                }


            } catch { }
          


        }

        private void LVpersonels_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(LVpersonels.SelectedIndex.ToString()+"noting");
            
        }
    }
}
