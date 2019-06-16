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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string PriceForBaybe { get; set; }
        public string PriceForAdult { get; set; }
    }
}
