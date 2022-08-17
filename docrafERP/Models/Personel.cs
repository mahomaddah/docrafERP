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

     
        private bool iseditin;

        public bool isEditing
        {
            get { return iseditin; }
            set { iseditin = value; }
        }

        private int typecode;

        public int PersonelTypeCode
        {
            get { typecode = getPersonalTypeIndex();  return typecode; }
            set { typecode = value; }
        }
        public Personel()
        {
            isEditing = false;
        }

        // public string Location { get; set; }

        int getPersonalTypeIndex()
        {
            int i = 1; //employee
            if (Role == "supply manager")
            {
                i = 0;
            }
            else if (Role == "accounting manager")
            {
                i = 2;
            }
            else if (Role == "director")
            {
                i = 3;
            }
            else if (Role == "manager")
            {
                i = 4;
            }
            return i;
        }


    }

}
