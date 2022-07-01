﻿using System;
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
                LVsupplies.Items.Remove(LVsupplies.SelectedItem);
            }
        }

        private void SupplyEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVsupplies.SelectedIndex == -1)
            {
                MessageBox.Show("Please select and item first....");
            }
            else
            {
                SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");
            }
        }

        private void SupplyAddBtn_Click(object sender, RoutedEventArgs e)
        {
            SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");
        }

        private void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (LVsupplies.SelectedIndex != -1)
            {
                SingletoneHomeView.Instance.homeView.bringTheUC("Edit Supply");
            }
        }

    }
}
