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
    public class PersonelTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PersoneltempSM { get; set; }     
        public DataTemplate PersoneltempAM { get; set; }
        public DataTemplate PersoneltempManager { get; set; }
        public DataTemplate PersoneltempDirector { get; set; }
        public DataTemplate PersoneltempEmployee { get; set; }
       


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (frameworkElement != null)
            {
                if (((Personel)item).Role.ToString().ToLower().Equals("supply manager"))
                {
                    PersoneltempSM = frameworkElement.FindResource("SMPersonelTemplate") as DataTemplate;
                    return PersoneltempSM;
                }
                else if (((Personel)item).Role.ToString().ToLower().Equals("accounting manager"))
                {
                    PersoneltempAM = frameworkElement.FindResource("AMPersonelTemplate") as DataTemplate;
                    return PersoneltempAM;
                }
                else if (((Personel)item).Role.ToString().ToLower().Equals("manager"))
                {
                    PersoneltempManager = frameworkElement.FindResource("ManagerPersonelTemplate") as DataTemplate;
                    return PersoneltempManager;
                }
                else if (((Personel)item).Role.ToString().ToLower().Equals("director"))
                {
                    PersoneltempDirector = frameworkElement.FindResource("DirectorPersonelTemplate") as DataTemplate;
                    return PersoneltempDirector;
                }
                else
                { //emplo...
                    PersoneltempEmployee = frameworkElement.FindResource("employeePersonelTemplate") as DataTemplate;
                    return PersoneltempEmployee;
                }

            }
            else return null;
        }
    }
}
