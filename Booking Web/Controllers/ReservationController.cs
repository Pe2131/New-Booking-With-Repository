using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking_Web.Models;
using Booking_Web.Utility;
using Booking_Web.ViewModel;
using DAL.Model;
using DAL.Model.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    public class ReservationController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        NormalUtility utility = new NormalUtility();
        private readonly AccountController accountController;
        public ReservationController(UserManager<Tbl_Users> _userManager, AccountController account)
        {
            accountController = account;
        }
        public IActionResult Index()
        {
            ViewModel_Search Model = new ViewModel_Search();
            var Routes = Db.RoutRepositori.Get(a => a.Status != "Deactive", orderby: a => a.OrderByDescending(b => b.id));
            Model.PathWays = Mapper.Map<List<ViewModel_Routes>>(Routes);
            var cities = Db.CityRepository.Get().ToList();
            Model.cities = Mapper.Map<List<ViewModel_City>>(cities);
            var countries = Db.CountryRepository.Get().ToList().OrderByDescending(a => a.Id);
            Model.Countries = Mapper.Map<List<ViewModel_Country>>(countries);
            return View(Model);
        }
        public IActionResult ReservForm(int id)
        {
            //try
            //{
            //    var path = Db.PathWayRepository.Get(a => a.id == id).SingleOrDefault();
            //    var pathmodel = Mapper.Map<ViewModel_PathWay>(path);
            //    ViewModel_Reserve model = new ViewModel_Reserve();
            //    model.PathId = id;
            //    model.DestName = pathmodel.GetDestinationName;
            //    model.SourceName = pathmodel.GetSourceName;
            //    model.PathDate = pathmodel.StartDate.ToString();
            //    model.PriceForAdult = pathmodel.PriceForAdultUro;
            //    model.PriceForBaby = pathmodel.PriceForBabyUro;
            //    model.Adult = 0;
            //    model.Baby = 0;
            //    return PartialView("P_ReservForm", model);
            //}
            //catch (Exception e)
            //{
            //    ErrorViewModel error = new ErrorViewModel();
            //    error.ErrorTitle = "Error";
            //    error.ErrorMassage = e.InnerException.ToString();
            //    return View("Error", error);
            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation(ViewModel_Prepay model, string adult, string child, string child2, string child7, string student)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    RoutesTools routesTools = new RoutesTools();
                    Tbl_NewReseve reseve = new Tbl_NewReseve();
                    reseve.AdultName = adult;
                    reseve.Adult = model.adultcount;
                    reseve.ChildupTo2 = model.childcount;
                    reseve.ChildupTo2Name = child;
                    reseve.Childup2To7 = model.child7count;
                    reseve.Childup2To7Names = child2;
                    reseve.Childup7To12 = model.child7count;
                    reseve.Childup7To12Names = child7;
                    reseve.StudentOrRetirs = model.studentCount;
                    reseve.studentOrRetirsName = student;
                    reseve.SumCount = model.sumcount;
                    reseve.SumPrice = model.sumprice;
                    reseve.AgentId = Db.UserRepository.Get(a => a.Email == User.Identity.Name).SingleOrDefault().Id;
                    reseve.Email = model.Email;
                    reseve.Fullname = model.Fullname;
                    reseve.Mobile = model.Mobile;
                    reseve.ReservedDate = DateTime.Now;
                    reseve.RouteId = model.RoutId;
                    reseve.TripdDate = utility.ConvertStaringToDate(model.tripDate, "dd/MM/yyyy");
                    reseve.Status = "1";
                    Db.NewReservRepositori.Insert(reseve);
                    int CheckReservCount = routesTools.CheckReservCount(model.tripDate, model.RoutId);
                    if (CheckReservCount != 0)
                    {
                        var Reservcount = Db.ReservCountRepositori.GetById(CheckReservCount);
                        Reservcount.count = Reservcount.count + model.sumcount;
                        Db.ReservCountRepositori.Update(Reservcount);
                    }
                    else
                    {
                        Tbl_ReservCount reservCount = new Tbl_ReservCount();
                        reservCount.count = model.sumcount;
                        reservCount.ReservDate = utility.ConvertStaringToDate(model.tripDate, "dd/MM/yyyy");
                        reservCount.RoutId_FG = model.RoutId;
                        Db.ReservCountRepositori.Insert(reservCount);
                    }
                    await Db.NewReservRepositori.Save();
                    TempData["Style"] = "alert alert-success text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View();
                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.InnerException.ToString();
                return View("Error", error);
            }
        }
        public async Task<IActionResult> ManageReservs()
        {
            var Userroles = await accountController.GetRole(User.Identity.Name);
            string userid = await accountController.GetUserId(User.Identity.Name);
            var Routes = Db.RoutRepositori.Get(null, orderby: a => a.OrderByDescending(b => b.id));
            var RouteModel = Mapper.Map<List<ViewModel_Routes>>(Routes);
            if (Userroles.Contains("Admin"))
            {
                var result = Db.NewReservRepositori.Get(null, null, "Tbl_Users,Tbl_Routes").OrderByDescending(a => a.Id).ToList();
                var model = Mapper.Map<List<ViewModel_Reserv>>(result);
                foreach (var item in model)
                {
                    item.SourceName = RouteModel.Where(a => a.id == item.RouteId).SingleOrDefault().GetSourceName;
                    item.DestName = RouteModel.Where(a => a.id == item.RouteId).SingleOrDefault().GetDestinationName;
                }
                return View(model);
            }
            else
            {
                var result = Db.NewReservRepositori.Get(a => a.AgentId == userid & a.Status != "Deleted", a => a.OrderByDescending(b => b.Id), "Tbl_Users,Tbl_Routes").OrderByDescending(a => a.Id).ToList();
                var model = Mapper.Map<List<ViewModel_Reserv>>(result);
                foreach (var item in model)
                {
                    item.SourceName = RouteModel.Where(a => a.id == item.RouteId).SingleOrDefault().GetSourceName;
                    item.DestName = RouteModel.Where(a => a.id == item.RouteId).SingleOrDefault().GetDestinationName;
                }
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult EditReserv(int id)
        {
            //try
            //{
            //    var reserv = Db.ReservRepositori.Get(a => a.Id == id, null, "Tbl_Users,Tbl_PathWay").SingleOrDefault();
            //    var path = Db.PathWayRepository.Get(a => a.id == reserv.PathId).SingleOrDefault();
            //    var model = Mapper.Map<ViewModel_Reserve>(reserv);
            //    var pathmodel = Mapper.Map<ViewModel_PathWay>(path);
            //    model.PriceForAdult = pathmodel.PriceForAdultUro;
            //    model.PriceForBaby = pathmodel.PriceForBabyUro;
            //    model.SourceName = pathmodel.GetSourceName;
            //    model.DestName = pathmodel.GetDestinationName;
            //    model.PathDate = pathmodel.StartDate.ToString();
            //    return PartialView("P_EditReserv", model);
            //}
            //catch (Exception e)
            //{
            //    ErrorViewModel error = new ErrorViewModel();
            //    error.ErrorTitle = "Error";
            //    error.ErrorMassage = e.InnerException.ToString();
            //    return View("Error", error);
            //}
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> EditReserv()
        //{
        //    //try
        //    //{
        //    //    if (ModelState.IsValid)
        //    //    {
        //    //        model.ReservedDate = DateTime.Now;
        //    //        var reserv = Db.ReservRepositori.GetById(model.Id);
        //    //        var path = Db.PathWayRepository.Get(a => a.id == model.PathId).SingleOrDefault();
        //    //        if (model.SumCount > reserv.SumCount)
        //    //        {
        //    //            int diffrence = model.SumCount - reserv.SumCount;
        //    //            path.Capacity = path.Capacity - diffrence;
        //    //        }
        //    //        else if (model.SumCount < reserv.SumCount)
        //    //        {
        //    //            int diffrence = reserv.SumCount - model.SumCount;
        //    //            path.Capacity = path.Capacity + diffrence;
        //    //        }
        //    //        if (path.Capacity >= 0)
        //    //        {
        //    //            reserv.Adult = model.Adult;
        //    //            reserv.Baby = model.Baby;
        //    //            reserv.Fullname = model.Fullname;
        //    //            reserv.SumCount = model.SumCount;
        //    //            reserv.SumPrice = model.SumPrice;
        //    //            reserv.ReservedDate = model.ReservedDate;
        //    //            Db.ReservRepositori.Update(reserv);
        //    //            Db.PathWayRepository.Update(path);
        //    //            await Db.ReservRepositori.Save();
        //    //            TempData["Style"] = "alert alert-success text-center";
        //    //            TempData["Message"] = "Saved";
        //    //            return RedirectToAction(nameof(ManageReservs));
        //    //        }
        //    //        else
        //    //        {
        //    //            TempData["Style"] = "alert alert-warning text-center";
        //    //            TempData["Message"] = "This path capacity not  matched";
        //    //            return RedirectToAction(nameof(ManageReservs));
        //    //        }

        //    //    }
        //    //    else
        //    //    {
        //    //        TempData["Style"] = "alert alert-warning text-center";
        //    //        TempData["Message"] = ModelState.GetErrors();
        //    //        return RedirectToAction(nameof(ManageReservs));
        //    //    }
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    ErrorViewModel error = new ErrorViewModel();
        //    //    error.ErrorTitle = "Error";
        //    //    error.ErrorMassage = e.Message;
        //    //    return View("Error", error);
        //    //}
        //    return View();
        //}
        //public async Task<JsonResult> Delete(int id)
        //{
        //    //try
        //    //{
        //    //    var reserv = Db.ReservRepositori.GetById(id);
        //    //    if (reserv.Status != "Deleted")
        //    //    {
        //    //        var path = Db.PathWayRepository.GetById(reserv.PathId);
        //    //        path.Capacity = path.Capacity + reserv.SumCount;
        //    //        reserv.Status = "Deleted";
        //    //        Db.PathWayRepository.Update(path);
        //    //        Db.ReservRepositori.Update(reserv);
        //    //        await Db.ReservRepositori.Save();
        //    //        return Json(1);
        //    //    }
        //    //    return Json(1);
        //    //}
        //    //catch (Exception e)
        //    //{

        //    //    throw e.InnerException;
        //    //}
        //    return Json(1);
        //}
        public IActionResult SearchRoutes(int source, int dest, string date, int count, int adult, int child, int child2, int child7, int student)
        {
            try
            {
                List<ViewModel_Routes> model = new List<ViewModel_Routes>();
                RoutesTools routesTools = new RoutesTools();
                model = Mapper.Map<List<ViewModel_Routes>>(routesTools.searchRoutes(source, dest, date));
                int RoutesCapacity =
                ViewBag.count = count;
                ViewBag.adult = adult;
                ViewBag.Child = child;
                ViewBag.Child2 = child2;
                ViewBag.Child7 = child7;
                ViewBag.Student = student;
                ViewBag.tripDate = date;
                foreach (var item in model)
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

        public IActionResult bookForm(int id, int count, int adult, int child = 0, int child2 = 0, int child7 = 0, int student = 0, string tripDate = "")
        {
            try
            {
                ViewBag.phone = Db.SettingRepository.Get().FirstOrDefault().Phone;
                var route = Db.RoutRepositori.GetById(id);
                var DestinationCity = Db.CityRepository.GetById(route.Destination_FG);
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
                model.SourceName = Db.CityRepository.GetById(route.Source_FG).name;
                ViewBag.count = count;
                ViewBag.adult = adult;
                ViewBag.Child = child;
                ViewBag.Child2 = child2;
                ViewBag.Child7 = child7;
                ViewBag.Student = student;
                ViewBag.tripDate = tripDate;
                ViewBag.RoutId = id;
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
        public IActionResult confirmation(ViewModel_Prepay model)
        {
            try
            {
                RoutesTools routesTools = new RoutesTools();
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

                    model.sumprice = routesTools.calculatPrice(model.sumcount, model.adultcount, model.childcount, model.child2count, model.child7count, model.studentCount, false, model.RoutId);
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
        public IActionResult Accounting()
        {
            return View();
        }
    }
}