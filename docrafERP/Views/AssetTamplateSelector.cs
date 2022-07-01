using docrafERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace docrafERP.Views
{
    public class AssetTamplateSelector : DataTemplateSelector
    {
        public DataTemplate AssetAvailableTemp { get; set; }
        public DataTemplate AssetUnAvailableTemp { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (frameworkElement != null)
            {
                if (((Asset)item).Status.ToString().ToLower().Equals("available"))
                {
                    AssetAvailableTemp = frameworkElement.FindResource("AssetAvailableTemplate") as DataTemplate;
                    return AssetAvailableTemp;
                }
                else
                {
                    AssetUnAvailableTemp = frameworkElement.FindResource("AssetUnAvailableTemplate") as DataTemplate;
                    return AssetUnAvailableTemp;
                }
            }
            else return null;
        }
    }
}
