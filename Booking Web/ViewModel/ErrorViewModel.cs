using System;

namespace Booking_Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string  ErrorMassage { get; set; }
        public string ErrorTitle { get; set; }
    }
}