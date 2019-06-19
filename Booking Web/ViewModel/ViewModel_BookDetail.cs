using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_BookDetail
    {
        public int Id { get; set; }
        public string SourceName { get; set; }
        public string DestName { get; set; }
        public string DestImage { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Price { get; set; }
    }
}
