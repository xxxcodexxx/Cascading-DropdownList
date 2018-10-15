using System.Collections.Generic;
using System.ComponentModel;

namespace CascadingDropdownList.Models
{
    public class CascadingViewmodel
    {
        [DisplayName("Country")]
        public int CountryID { get; set; }
        [DisplayName("City")]
        public int CityID { get; set; }
        [DisplayName("District")]
        public int DistrictID { get; set; }
        public List<Countries> Countries { get; set; }
        public List<Cities> Cities { get; set; }
        public List<Districts> Districts { get; set; }
    }
}