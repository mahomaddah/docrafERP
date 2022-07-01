using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using docrafERP.Models;

namespace docrafERP.Views
{
    public class SupplyTamplateSelector : DataTemplateSelector
    {
        public DataTemplate SupplyReadyToUseTemp { get; set; }
        public DataTemplate SupplyOutOfStockTemp { get; set; }
        public DataTemplate SupplyLowOnStockTemp { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (frameworkElement != null)
            {
                if (((Supply)item).StockStatus.ToString().ToLower().Equals("ready to use"))
                {
                    SupplyReadyToUseTemp = frameworkElement.FindResource("SupplyReadyToUseTemplate") as DataTemplate;
                    return SupplyReadyToUseTemp;
                }
                else if(((Supply)item).StockStatus.ToString().ToLower().Equals("low on stock"))
                {
                    SupplyLowOnStockTemp = frameworkElement.FindResource("SupplyLowOnStockTemplate") as DataTemplate;
                    return SupplyLowOnStockTemp;
                }
                 else
                {
                    SupplyOutOfStockTemp = frameworkElement.FindResource("SupplyOutOfStockTemplate") as DataTemplate;
                    return SupplyOutOfStockTemp;
                }
            }
            else return null;
        }
    }
}
