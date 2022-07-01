using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Models
{
    public class Supply
    {
        public int SupplyID { get; set; }
        public int PurchaseRequetID { get; set; }
        public string DocumentsFolderPath { get; set; }
        public string ImagePath { get; set; }
        public string RemarksJson { get; set; }

        public string Name { get; set; }
        public string PurchasePrice { get; set; }
        public string Quantity { get; set; }
        public string LotNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string PurchasedVendor { get; set; }
        public string Barcode { get; set; }
     // public string OwnerOrLocation { get; set; }
        public string StockStatus { get; set; }
        public Supply()
        {
            StockStatus = "Ready to use";
            ImagePath = @"/UIassets/image 11.png";
        }
 
    }
}
