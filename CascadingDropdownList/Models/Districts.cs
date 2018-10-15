using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingDropdownList.Models
{
    public class Districts
    {
        public int DistrictID { get; set; }
        public string NameOfDistrict { get; set; }
        public int OrderNumber { get; set; }
        public int CityID { get; set; }
        public override string ToString()
        {
            return NameOfDistrict;
        }
    }
}