using System.Collections.Generic;
using System.Windows.Controls;

namespace docrafERP.Views
{
    public class InventoryTreeViewModel 
    {
        public string SelectedInventoryName { get; set; }

        public InventoryTreeItemModel ParentItem { get; set; }

   

     


        int programNumber = 0;

        private string programNumberText;

        public string ProgramNumberText
        {
            get {
                ProgramNumberText = "4 inventory and " + programNumber + " programs";
                return programNumberText; }
            set { programNumberText = value; }
        }

      




        public InventoryTreeViewModel()
        {





            ParentItem = new InventoryTreeItemModel { InventoryName = "0 item invetory name" };
            //first item start here ///

         

            var testItem = new InventoryTreeItemModel { InventoryName = "Inventory for Consumption" };
             

            ParentItem.Children.Add(testItem);


            ParentItem.Children.Add(new InventoryTreeItemModel { InventoryName = "Inventory for Distribution" });    
            ParentItem.Children.Add(new InventoryTreeItemModel { InventoryName = "Inventory for Manufacturing" });
            ParentItem.Children.Add(new InventoryTreeItemModel { InventoryName = "Inventory for Sale" });

            SelectedInventoryName = "Inventory for Consumption ...";

        }
    }
    public class InventoryTreeItemModel
    {
        public string InventoryName { get; set; }

        // other properties like project manager...
        public List<InventoryTreeItemModel> Children { get; set; }

        public InventoryTreeItemModel()
        {
            Children = new List<InventoryTreeItemModel>();
       
        }


    }
}