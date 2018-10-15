using CascadingDropdownList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdownList.Controllers
{
    public class CascadingController : Controller
    {
        // GET: Cascading
        private static List<Countries> _countries { get; set; }
        private static List<Cities> _cities { get; set; }
        private static List<Districts> _districts { get; set; }

        public CascadingController()
        {
            InitialDataCities();
            InitialDataDistricts();
            InitialDataCountries();
        }

        public ActionResult Index()
        {
            var model = new CascadingViewmodel
            {
                CountryID = _countries.FirstOrDefault() != null ?
                    _countries.OrderBy(c => c.OrderNumber).FirstOrDefault().CountryID : 0,
                Countries = _countries.OrderBy(c => c.OrderNumber).ToList()
            };

            model.Cities = _cities.Where(c => c.CountryID.Equals(model.CountryID)).OrderBy(c => c.OrderNumber).ToList();
            model.CityID = model.Cities.FirstOrDefault() != null ? model.Cities.FirstOrDefault().CityID : 0;

            model.Districts = _districts.Where(c => c.CityID.Equals(model.CityID)).OrderBy(c => c.OrderNumber).ToList();
            model.DistrictID = model.Districts.FirstOrDefault() != null ? model.Districts.FirstOrDefault().DistrictID : 0;

            return View(model);
        }

        [HttpGet]
        public JsonResult GetCities(int countryID)
        {
            var cities = _cities.Where(c=>c.CountryID.Equals(countryID)).OrderBy(c=>c.OrderNumber).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDistricts(int cityID)
        {
            var districts = _districts.Where(d=>d.CityID.Equals(cityID)).OrderBy(d => d.OrderNumber).ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        public void InitialDataCountries()
        {
            _countries = new List<Countries> {
                new Countries{CountryID = 1, NameOfCountry="Việt Nam", OrderNumber = 1},
                new Countries{CountryID = 2, NameOfCountry="Mỹ", OrderNumber = 2},
                new Countries{CountryID = 3, NameOfCountry="Ấn Độ", OrderNumber = 3},
                new Countries{CountryID = 4, NameOfCountry="Trung Quốc", OrderNumber = 4},
                new Countries{CountryID = 5, NameOfCountry="Canada", OrderNumber = 6},
                new Countries{CountryID = 6, NameOfCountry="Nhật Bản", OrderNumber = 7},
                new Countries{CountryID = 7, NameOfCountry="Hàn Quốc", OrderNumber = 5},
                new Countries{CountryID = 8, NameOfCountry="Đức", OrderNumber = 8},
            };
        }

        public void InitialDataCities()
        {
            _cities = new List<Cities>
            {
                //vietnam
                new Cities{CityID = 1, NameOfCity="Hà Nội", CountryID = 1, OrderNumber = 1},
                new Cities{CityID = 2, NameOfCity="TP Hồ Chí Minh", CountryID = 1, OrderNumber = 2},
                new Cities{CityID = 3, NameOfCity="Nghệ An", CountryID = 1, OrderNumber = 3},
                //my
                new Cities{CityID = 4, NameOfCity="Los Angeles", CountryID = 2, OrderNumber = 3},
                new Cities{CityID = 5, NameOfCity="Las Vegas", CountryID = 2, OrderNumber = 4},
                new Cities{CityID = 6, NameOfCity="Chicago", CountryID = 2, OrderNumber = 2},
                new Cities{CityID = 7, NameOfCity="New York", CountryID = 2, OrderNumber = 1},
                //ando
                new Cities{CityID = 8, NameOfCity="Mumbai", CountryID = 3, OrderNumber = 2},
                new Cities{CityID = 9, NameOfCity="Delhi", CountryID = 3, OrderNumber = 3},
                new Cities{CityID = 10, NameOfCity="Bengaluru", CountryID = 3, OrderNumber = 4},
                //trungquoc
                new Cities{CityID = 11, NameOfCity="Thượng Hải", CountryID = 4, OrderNumber = 1},
                new Cities{CityID = 12, NameOfCity="Bắc Kinh", CountryID = 4, OrderNumber = 1},
                new Cities{CityID = 13, NameOfCity="Vũ Hán", CountryID = 4, OrderNumber = 1},
                //canada
                new Cities{CityID = 14, NameOfCity="Toronto", CountryID = 5, OrderNumber = 1},
                new Cities{CityID = 15, NameOfCity="Ottawa", CountryID = 5, OrderNumber = 1},
                //nhatban
                new Cities{CityID = 16, NameOfCity="Nagasaki", CountryID = 6, OrderNumber = 1},
                new Cities{CityID = 17, NameOfCity="Osaka", CountryID = 6, OrderNumber = 1},
                new Cities{CityID = 18, NameOfCity="Tokyo", CountryID = 6, OrderNumber = 1},
                //hanquoc
                new Cities{CityID = 19, NameOfCity="Busan", CountryID = 7, OrderNumber = 1},
                new Cities{CityID = 20, NameOfCity="Icheon", CountryID = 7, OrderNumber = 1},
                new Cities{CityID = 21, NameOfCity="Seoul", CountryID = 7, OrderNumber = 1},
                //duc
                new Cities{CityID = 22, NameOfCity="Berlin", CountryID = 8, OrderNumber = 1},
                new Cities{CityID = 23, NameOfCity="München", CountryID = 8, OrderNumber = 1},
                new Cities{CityID = 24, NameOfCity="Dortmund", CountryID = 8, OrderNumber = 1},
            };
        }

        public void InitialDataDistricts()
        {
            _districts = new List<Districts>
            {
                //hanoi
                new Districts{DistrictID = 1, NameOfDistrict = "Hai Bà Trưng", CityID = 1, OrderNumber = 2},
                new Districts{DistrictID = 2, NameOfDistrict = "Hoàn Kiếm", CityID = 1, OrderNumber = 1},
                //hcm
                new Districts{DistrictID = 3, NameOfDistrict = "Quận 1", CityID = 2, OrderNumber = 1},
                new Districts{DistrictID = 4, NameOfDistrict = "Quận 2", CityID = 2, OrderNumber = 1},
                //nghean
                new Districts{DistrictID = 5, NameOfDistrict = "Vinh", CityID = 3, OrderNumber = 1},
                //losangeles
                new Districts{DistrictID = 6, NameOfDistrict = "Hollywood", CityID = 4, OrderNumber = 1},
                new Districts{DistrictID = 7, NameOfDistrict = "Los Angeles Times", CityID = 4, OrderNumber = 1}
            };
        }
    }
}