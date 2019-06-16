using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Discounts
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int Count { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Type { get; set; }
        public int percent { get; set; }
        public decimal Price { get; set; }
    }
}
