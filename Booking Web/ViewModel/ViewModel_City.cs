using DAL.Model;
using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
 
    public class ViewModel_City
    {
        UnitOfWork Db = new UnitOfWork();
        public int Id { get; set; }
        public int Country_FG { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool ShowInSlider { get; set; }
        public string CountryName
        { get
            {
                var country = Db.CountryRepository.GetById(Country_FG);
                return country.Name;
            }
        }
    }
}
