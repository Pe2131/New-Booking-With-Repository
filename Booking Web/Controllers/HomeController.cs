using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booking_Web.Models;
using DAL.Model.Tables;
using DAL.Model;
using Booking_Web.ViewModel;
using AutoMapper;
using System.Globalization;
using Booking_Web.Utility;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Booking_Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        NormalUtility utility = new NormalUtility();
        public IActionResult Index()
        {
            ViewModel_Index model = new ViewModel_Index();
            var cities = db.CityRepository.Get().ToList();
            var countries = db.CountryRepository.Get().ToList().OrderByDescending(a => a.Id);
            model.cities = Mapper.Map<List<ViewModel_City>>(cities);
            model.Countries = Mapper.Map<List<ViewModel_Country>>(countries);
            model.setting = db.SettingRepository.Get().FirstOrDefault();
            model.Blogs = db.WeblogRepositori.Get(null, a => a.OrderByDescending(b => b.id)).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Exception e)
        {
            return View(new ErrorViewModel { ErrorMassage = e.InnerException.ToString(), ErrorTitle = "Error", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// for news letter
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<JsonResult> insertEmail(string Email)
        {
            try
            {
                if (Email != null)
                {

                    var letter = db.NewsLetterRepositori.Get(a => a.Email == Email).SingleOrDefault();
                    if (letter != null)
                    {
                        return Json("your email saved before");
                    }
                    Tbl_NewsLetter tbl_NewsLetter = new Tbl_NewsLetter { Email = Email };
                    db.NewsLetterRepositori.Insert(tbl_NewsLetter);
                    await db.NewsLetterRepositori.Save();
                    return Json("thank you for register your email");
                }
                else
                {
                    return Json("please insert your email");
                }
            }
            catch (Exception)
            {

                return Json("can not be inserted!");
            }
        }
        /// <summary>
        /// search form that show reservation in ajax mode
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="date"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IActionResult ShowReservation(int source, int dest, string date, int count)
        {
            try
            {
                PathWayController pathWayController = new PathWayController();
                var paths = new List<ViewModel_PathWay>();
                if (date != null)
                {
                    DateTime dt = DateTime.ParseExact(date, "MM/dd/yyyy",
                                                       CultureInfo.InvariantCulture);
                    string dat = utility.ConvertDateToStringOnlydate(dt);
                    paths = pathWayController.SearchPathForReserv(source, dest, dat, count);
                }
                else
                {
                    paths = pathWayController.SearchPathForReserv(source, dest, date, count);
                }
                return PartialView("P_ShowPath", paths);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public IActionResult Blog(int id)
        {
            try
            {
                var weblog = db.WeblogRepositori.GetById(id);
                return View("Blog", weblog);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }

        }
        /// <summary>
        /// search reservation for post mode
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="date"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IActionResult Search(int source, int dest, string date, int count, int adult, int child, int child2, int child7, int student, string backdate = null)
        {
            try
            {
                ViewModel_Search model = new ViewModel_Search();
                ViewModel_Routes backWayModel = new ViewModel_Routes();
                RoutesTools routesTools = new RoutesTools();
                if (backdate != null)
                {
                    backWayModel = Mapper.Map<List<ViewModel_Routes>>(routesTools.searchRoutes(dest, source, backdate)).FirstOrDefault();
                    if (backWayModel == null)
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "back way that you select is not exict <br/> if you want continue or back and select another date";
                    }
                    else
                    {
                        ViewBag.backdate = backdate;
                        ViewBag.backwayRoutId = backWayModel.id;
                    }
                }
                model.PathWays = Mapper.Map<List<ViewModel_Routes>>(routesTools.searchRoutes(source, dest, date));
                var countries = db.CountryRepository.Get().ToList().OrderByDescending(a => a.Id);
                model.cities = Mapper.Map<List<ViewModel_City>>(db.CityRepository.Get().ToList());
                model.Countries = Mapper.Map<List<ViewModel_Country>>(countries);
                int RoutesCapacity =
                ViewBag.count = count;
                ViewBag.adult = adult;
                ViewBag.Child = child;
                ViewBag.Child2 = child2;
                ViewBag.Child7 = child7;
                ViewBag.Student = student;
                ViewBag.tripDate = date;
                foreach (var item in model.PathWays)
                {
                    item.Capacity = routesTools.RoutsCapacity(date, item.id);
                }
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

        [HttpGet]
        public IActionResult ContactUs()
        {
            try
            {
                var setting = db.SettingRepository.Get().FirstOrDefault();
                ViewBag.success = TempData["Success"];
                ViewBag.message = TempData["Message"];
                return View(setting);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }

        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(Tbl_Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactRepositori.Insert(model);
                    await db.ContactRepositori.Save();
                    TempData["Success"] = "danger alert-success text-center";
                    TempData["Message"] = "Your comment Succefully sent";
                }
                else
                {
                    string error = ModelState.GetErrors();
                    TempData["Error"] = "danger alert-danger text-center";
                    TempData["Message"] = error;
                }
                return RedirectToAction(nameof(ContactUs), "Home");
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }

        }
        public IActionResult About()
        {
            try
            {
                var setting = db.SettingRepository.Get().FirstOrDefault();
                return View(setting);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }

        }
        public IActionResult Routes()
        {
            try
            {
                ViewModel_Search model = new ViewModel_Search();
                var Routes = db.RoutRepositori.Get(a => a.Status != "Deactive").ToList().GroupBy(a => a.Source_FG).OrderByDescending(a => a.Count()).SelectMany(a => a).ToList();  //for sort by count of source_Fg
                var countries = db.CountryRepository.Get().ToList().OrderByDescending(a => a.Id);
                model.cities = Mapper.Map<List<ViewModel_City>>(db.CityRepository.Get().ToList());
                model.PathWays = Mapper.Map<List<ViewModel_Routes>>(Routes);
                model.Countries = Mapper.Map<List<ViewModel_Country>>(countries);
                ViewBag.phone = db.SettingRepository.Get().FirstOrDefault().Phone;
                ViewBag.Count = model.PathWays.Count();
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
        public IActionResult bookForm(int id, int count, int adult, int child = 0, int child2 = 0, int child7 = 0, int student = 0, string tripDate = "", string backdate = "", int backwayRoutId = 0)
        {
            try
            {
                ViewBag.phone = db.SettingRepository.Get().FirstOrDefault().Phone;
                var route = db.RoutRepositori.GetById(id);
                var DestinationCity = db.CityRepository.GetById(route.Destination_FG);
                ViewModel_BookDetail model = new ViewModel_BookDetail();
                model.DestImage = DestinationCity.Image;
                model.Id = route.id;
                model.Price = route.Price.ToString();
                model.Start = string.Join(",",
                                                from g in route.DepartureDays.Split(new char[] { ',' })
                                                select Enum.GetName(typeof(DayOfWeek), Convert.ToInt32(g)));
                model.End = string.Join(",",
                                                from g in route.ArriveDays.Split(new char[] { ',' })
                                                select Enum.GetName(typeof(DayOfWeek), Convert.ToInt32(g)));
                model.StartTime = route.DepartureTime;
                model.EndTime = route.ArriveTime;
                model.DestName = DestinationCity.name;
                model.SourceName = db.CityRepository.GetById(route.Source_FG).name;
                ViewBag.count = count;
                ViewBag.adult = adult;
                ViewBag.Child = child;
                ViewBag.Child2 = child2;
                ViewBag.Child7 = child7;
                ViewBag.Student = student;
                ViewBag.tripDate = tripDate;
                ViewBag.RoutId = id;
                ViewBag.backdate = backdate;
                ViewBag.backwayRoutId = backwayRoutId;
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

        public IActionResult Prepay(ViewModel_Prepay model, string backdate = "", int backwayRoutId = 0)
        {
            try
            {
                RoutesTools routesTools = new RoutesTools();
                if (backdate != "" && backwayRoutId != 0)
                {
                    if (!routesTools.CnfirmReservDatTime(backwayRoutId, backdate))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "date is worng please correct it";
                        return View(model);
                    }
                    if (model.sumcount > routesTools.RoutsCapacity(backdate, backwayRoutId))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "there is no seat exict in back route!! <br/> if you continue reserv one way ticket";
                        return View(model);
                    }
                }
                if (!routesTools.CnfirmReservDatTime(model.RoutId, model.tripDate))
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = "date is worng please correct it";
                    return View(model);
                }
                if (model.sumcount > routesTools.RoutsCapacity(model.tripDate, model.RoutId))
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = "there is no seat exict!!";
                    return View(model);
                }
                if (model.sumcount == model.adultcount + model.childcount + model.child2count + model.child7count + model.studentCount)
                {
                    if (model.adult != null)
                    {
                        ViewBag.AdultName = utility.StringArrayToString(model.adult);
                    }
                    if (model.child != null)
                    {
                        ViewBag.Childname = utility.StringArrayToString(model.child);
                    }
                    if (model.Child2 != null)
                    {
                        ViewBag.Child2name = utility.StringArrayToString(model.Child2);
                    }
                    if (model.child7 != null)
                    {
                        ViewBag.Child7name = utility.StringArrayToString(model.child7);
                    }
                    if (model.student != null)
                    {
                        ViewBag.student = utility.StringArrayToString(model.student);
                    }
                    ViewBag.backdate = backdate;
                    ViewBag.backwayRoutId = backwayRoutId;
                    if (backdate != "" && backwayRoutId != 0)
                    {
                        model.sumprice = routesTools.calculatPrice(model.sumcount, model.adultcount, model.childcount, model.child2count, model.child7count, model.studentCount, true, model.RoutId);
                    }
                    else
                    {
                        model.sumprice = routesTools.calculatPrice(model.sumcount, model.adultcount, model.childcount, model.child2count, model.child7count, model.studentCount, false, model.RoutId);
                    }
                    return View(model);
                }
                else
                {
                    TempData["message"] = "count of passenger didnt equal names";
                    return RedirectToAction(nameof(bookForm), new { id = model.RoutId, count = model.sumcount, adult = model.adultcount, child = model.childcount, child2 = model.Child2, child7 = model.child7count, student = model.studentCount });
                }
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public IActionResult Terms()
        {
            return View();
        }
        public IActionResult PersonalData()
        {
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public IActionResult Pay(ViewModel_Prepay model)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
    }
}
