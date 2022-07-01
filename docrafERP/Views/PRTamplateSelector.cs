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
    public class PRTamplateSelector : DataTemplateSelector
    {
        public DataTemplate PRapproveTemplate { get; set; }
        public DataTemplate PRDeniedTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (frameworkElement != null)
            {
                if (((PurchaseRequest)item).IsApproved)
                {
                    PRapproveTemplate = frameworkElement.FindResource("PRapproveTemplate") as DataTemplate;
                    return PRapproveTemplate;
                }
                else
                {
                    PRDeniedTemplate = frameworkElement.FindResource("PRDeniedTemplate") as DataTemplate;
                    return PRDeniedTemplate;
                }
            }
            else return null;
        }
    }

}
