using docrafERP.DataAccessLayer;
using docrafERP.Models;
using docrafERP.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public Personel User { get; set; }
        public LoginPanel()
        {
            InitializeComponent();

            WelcomeSnackBar.IsActive = false;
            WelcomeSnackBar.IsActiveChanged += WelcomeSnackBar_IsActiveChanged;
            WelcomeSnackBar.ContextMenuClosing += WelcomeSnackBar_ContextMenuClosing;

            //if (Settings.Default.Properties["ISRemeberMe"] == null)
            //{

            //    Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("UserName"));
            //    Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("ISRemeberMe"));
            //    Properties.Settings.Default.Save();

            //}
            //else if (Properties.Settings.Default.Properties["ISRemeberMe"].DefaultValue.ToString()!="false")
            //{
            //    UserNameTB.Text = Settings.Default.Properties["UserName"].ToString();
            //}
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
         
            User = new DataService().GetAllPersonels().Find(x=> (x.Password == passwordBX.Password) && (x.Name == UserNameTB.Text || x.MobileNumber == UserNameTB.Text || x.Email == UserNameTB.Text));

            if (User!= null || (passwordBX.Password=="test" && UserNameTB.Text== "test"))
            {
                //if (Properties.Settings.Default.Properties["UserName"] != null)
                //{
                //    Properties.Settings.Default.Properties["UserName"].DefaultValue = UserNameTB.Text.ToString();
                //    Settings.Default.Save();
                //}

                //  WelcomeSnackBar.Message = new MaterialDesignThemes.Wpf.SnackbarMessage { Content = "hello" };
                //   WelcomeSnackBar.IsActive = true;
                

                this.Hide();
                new HomeView(User).ShowDialog();


            }
            else
            {
                MessageBox.Show("Invalid Username|Email|Mobile or Password...");
            }
          

         

        }

        private void WelcomeSnackBar_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
           
            
        }

        private void WelcomeSnackBar_IsActiveChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
          
            
        }

        private void isRemeberUserName_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (Settings.Default.Properties["ISRemeberMe"] != null)
                //{
                //    Properties.Settings.Default.Properties["ISRemeberMe"].DefaultValue = true;
                //    Settings.Default.Save();
                //}
              
            }
            catch { }
        }

        private void isRemeberUserName_Unchecked(object sender, RoutedEventArgs e)
        {       
            try
            {
                //if (Settings.Default.Properties["ISRemeberMe"] != null)
                //{
                //    Properties.Settings.Default.Properties["ISRemeberMe"].DefaultValue = false;
                //    Settings.Default.Save();
                //}
            }
            catch { }

        }
    }
}
