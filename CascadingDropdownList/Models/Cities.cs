using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingDropdownList.Models
{
    public class Cities
    {
        public int CityID { get; set; }
        public string NameOfCity { get; set; }
        public int OrderNumber { get; set; }
        public int CountryID { get; set; }
        public override string ToString()
        {
            return NameOfCity;
        }
    }
}