using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Models
{
    public class DataLog
    {
        public int UserID { get; internal set; }
        public int RecordID { get; internal set; }
        public string TableName { get; internal set; }
        public string CRUDtype { get; internal set; }
    }
}
