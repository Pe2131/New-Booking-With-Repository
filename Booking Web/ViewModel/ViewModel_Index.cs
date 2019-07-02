using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Index
    {
        public Tbl_Setting setting { get; set; }
        public List<ViewModel_City> cities { get; set; }
        public List<Tbl_Weblog> Blogs { get; set; }
        public List<ViewModel_Country> Countries { get; set; }
    }
}
