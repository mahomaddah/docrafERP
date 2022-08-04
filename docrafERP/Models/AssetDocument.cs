using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Models
{
    public class AssetDocument
    {
        public int AssetDocumentID { get; set; }
        public int FileID { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public int AssetID { get; set; }
        public string DocumentType { get; set; }
        public int AdminID { get; set; }
        public bool IsImage { get; set; }

    }
}
