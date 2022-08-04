using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docrafERP.Models
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // SM ,AM , DIR, EMP ...
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int PersonelPicID { get; set; }
       // public string Location { get; set; }



    }
}
