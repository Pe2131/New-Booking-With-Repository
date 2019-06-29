using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Views.Account
{
    public class PaymentController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}