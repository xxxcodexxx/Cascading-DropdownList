using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingDropdownList.Models
{
    public class Countries
    {
        public int CountryID { get; set; }
        public string NameOfCountry { get; set; }
        public int OrderNumber { get; set; }
        public override string ToString()
        {
            return NameOfCountry;
        }
    }
}