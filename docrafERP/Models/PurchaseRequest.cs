using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Models
{
    public class PurchaseRequest
    {
        public int PurchaseRequetID { get; set; }
        public string ProductName { get; set; }
        public string IssuedDate { get; set; }
        public string PRdocumentPath { get; set; }
        public bool IsApproved { get; set; }

        public PurchaseRequest()
        {
            IsApproved = true;
        }
    }
}
