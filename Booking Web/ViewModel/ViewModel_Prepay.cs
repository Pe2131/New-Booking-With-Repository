using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Prepay
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string[] adult { get; set; }
        public string[] child { get; set; }
        public string[] Child2 { get; set; }
        public string[] child7 { get; set; }
        public string[] student { get; set; }
        public string AgentId { get; set; }
        public int RoutId { get; set; }
        public int adultcount { get; set; }
        public int childcount { get; set; }
        public int child2count { get; set; }
        public int child7count { get; set; }
        public int studentCount { get; set; }
        public int sumcount { get; set; }
        public decimal sumprice { get; set; }
        public string tripDate { get; set; }
    }
}
