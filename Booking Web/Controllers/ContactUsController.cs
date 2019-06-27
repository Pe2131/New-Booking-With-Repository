using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking_Web.Models;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    public class ContactUsController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        public IActionResult Index()
        {
            try
            {
                var model = db.ContactRepositori.Get().OrderByDescending(a => a.id).ToList();
                return View(model);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                db.ContactRepositori.Delete(id);
                await db.ContactRepositori.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }

    }
}