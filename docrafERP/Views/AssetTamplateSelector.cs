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

        public DataTemplate AssetTempRequested { get; set; }

        public DataTemplate AssetTempAccountingApproved { get; set; }
        public DataTemplate AssetTempDirectorApproved { get; set; }
        public DataTemplate AssetTempOrdered { get; set; }
        public DataTemplate AssetTempAcceptingbySupplyManager { get; set; }
        public DataTemplate AssetTempInStorage { get; set; }
        public DataTemplate AssetTempOutForRepair { get; set; }


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
                else if (((Asset)item).Status.ToString().ToLower().Equals("requested"))
                {
                    AssetTempRequested = frameworkElement.FindResource("AssetTempRequested") as DataTemplate;
                    return AssetTempRequested;
                }
                else if (((Asset)item).Status.ToString().ToLower().Equals("accounting approved"))
                {
                    AssetTempAccountingApproved = frameworkElement.FindResource("AssetTempAccountingApproved") as DataTemplate;
                    return AssetTempAccountingApproved;
                }
                else if (((Asset)item).Status.ToString().ToLower().Equals("director approved"))
                {
                    AssetTempDirectorApproved = frameworkElement.FindResource("AssetTempDirectorApproved") as DataTemplate;
                    return AssetTempDirectorApproved;
                }
                else if (((Asset)item).Status.ToString().ToLower().Equals("ordered"))
                {
                    AssetTempOrdered = frameworkElement.FindResource("AssetTempOrdered") as DataTemplate;
                    return AssetTempOrdered;
                }
                else if (((Asset)item).Status.ToString().ToLower().Equals("accepting by supply manager"))
                {
                    AssetTempAcceptingbySupplyManager = frameworkElement.FindResource("AssetTempAcceptingbySupplyManager") as DataTemplate;
                    return AssetTempAcceptingbySupplyManager;
                }
                else if (((Asset)item).Status.ToString().ToLower().Equals("out for repair"))
                {
                    AssetTempOutForRepair = frameworkElement.FindResource("AssetTempOutForRepair") as DataTemplate;
                    return AssetTempOutForRepair;
                }
                else if (((Asset)item).Status.ToString().Equals("In Storage"))
                {
                    AssetTempInStorage = frameworkElement.FindResource("AssetTempInStorage") as DataTemplate;
                    return AssetTempInStorage;
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
