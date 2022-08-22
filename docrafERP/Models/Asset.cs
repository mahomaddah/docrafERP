using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using docrafERP.Models;

namespace docrafERP.Models
{
    public class Asset
    {
        public int AssetID { get; set; }
        public int PurchaseRequetID { get; set; }
        public string DocumentsFolderPath { get; set; }
        public string ImagePath { get; set; }
        public string RemarksJson { get; set; }

        public string Device { get; set; }
        public string OwnerOrLocation { get; set; }
        public string Status { get; set; } //Available Unavailable...
        public string SerialNumber { get; set; }
        public string DateReceived { get; set; }
        public string PurchasedVendor { get; set; }
        public string PurchasePrice { get; set; }
        public string Barcode { get; set; }
        public int CustodianID { get; set; }
        public string CustodianName { get; set; }
        public List<AssetMaintenance> AssetMaintenanceLogs { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }

        //private int custodianID;

        //public int CustodianID
        //{
        //    get { return custodianID; }
        //    set { custodianID = value;
        //        try { DataAcc}
        //    }
        //}

        // public Personel Custodian { get; set; }


        public Asset()
        {
            Status = "Available";
            ImagePath = @"/UIassets/image 9.png";
            AssetMaintenanceLogs = new List<AssetMaintenance>();
        }

    }
}
