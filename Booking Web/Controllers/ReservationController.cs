using System;
using System.Collections.Generic;
using System.Globalization;
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
using static Booking_Web.Utility.NormalUtility;

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
        public async Task<IActionResult> AddReservation(ViewModel_Prepay model, string adult, string child, string child2, string child7, string student, string backdate = "", int backwayRoutId = 0)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    RoutesTools routesTools = new RoutesTools();
                    Tbl_NewReseve reseve = new Tbl_NewReseve();
                    List<Tbl_NewReseve> resevesList = new List<Tbl_NewReseve>();
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
                    reseve.Status = ReservationStause.agentReserv.ToString();
                    resevesList.Add(reseve);
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
                    if (backdate != "" && backwayRoutId != 0)
                    {
                        Tbl_NewReseve backreseve = new Tbl_NewReseve();
                        backreseve.AdultName = adult;
                        backreseve.Adult = model.adultcount;
                        backreseve.ChildupTo2 = model.childcount;
                        backreseve.ChildupTo2Name = child;
                        backreseve.Childup2To7 = model.child7count;
                        backreseve.Childup2To7Names = child2;
                        backreseve.Childup7To12 = model.child7count;
                        backreseve.Childup7To12Names = child7;
                        backreseve.StudentOrRetirs = model.studentCount;
                        backreseve.studentOrRetirsName = student;
                        backreseve.SumCount = model.sumcount;
                        backreseve.SumPrice = model.sumprice;
                        backreseve.AgentId = Db.UserRepository.Get(a => a.Email == User.Identity.Name).SingleOrDefault().Id;
                        backreseve.Email = model.Email;
                        backreseve.Fullname = model.Fullname;
                        backreseve.Mobile = model.Mobile;
                        backreseve.ReservedDate = DateTime.Now;
                        backreseve.RouteId = backwayRoutId;
                        backreseve.TripdDate = utility.ConvertStaringToDate(backdate, "dd/MM/yyyy");
                        backreseve.Status = ReservationStause.agentReserv.ToString();
                        resevesList.Add(backreseve);
                        int CheckbackReservCount = routesTools.CheckReservCount(backdate, backwayRoutId);
                        if (CheckbackReservCount != 0)
                        {
                            var Reservcount = Db.ReservCountRepositori.GetById(CheckbackReservCount);
                            Reservcount.count = Reservcount.count + model.sumcount;
                            Db.ReservCountRepositori.Update(Reservcount);
                        }
                        else
                        {
                            Tbl_ReservCount reservCount = new Tbl_ReservCount();
                            reservCount.count = model.sumcount;
                            reservCount.ReservDate = utility.ConvertStaringToDate(backdate, "dd/MM/yyyy");
                            reservCount.RoutId_FG = backwayRoutId;
                            Db.ReservCountRepositori.Insert(reservCount);
                        }

                    }
                    Db.NewReservRepositori.InsertRange(resevesList);
                    await Db.NewReservRepositori.Save();
                    TempData["Style"] = "alert alert-success text-center";
                    TempData["Message"] = "reserve process successfully done";
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
                var result = Db.NewReservRepositori.Get(a => a.AgentId == userid & a.Status != ReservationStause.Deleted.ToString(), a => a.OrderByDescending(b => b.Id), "Tbl_Users,Tbl_Routes").OrderByDescending(a => a.Id).ToList();
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
        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var reserv = Db.NewReservRepositori.GetById(id);
                RoutesTools routesTools = new RoutesTools();
                if (reserv.Status != ReservationStause.Deleted.ToString())
                {
                    CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    string date = reserv.TripdDate.ToString("dd/MM/yyyy");
                    var CheckReservCount = routesTools.CheckReservCount(date, reserv.RouteId);
                    if (CheckReservCount != 0)
                    {
                        var Reservcount = Db.ReservCountRepositori.GetById(CheckReservCount);
                        Reservcount.count = Reservcount.count - reserv.SumCount;
                        Db.ReservCountRepositori.Update(Reservcount);
                    }
                    reserv.Status = ReservationStause.Deleted.ToString();
                    Db.NewReservRepositori.Update(reserv);
                    await Db.NewReservRepositori.Save();
                    return Json(1);
                }
                return Json(1);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        public IActionResult SearchRoutes(int source, int dest, string date, int count, int adult, int child, int child2, int child7, int student, string backdate = null)
        {
            try
            {
                List<ViewModel_Routes> model = new List<ViewModel_Routes>();
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

        public IActionResult bookForm(int id, int count, int adult, int child = 0, int child2 = 0, int child7 = 0, int student = 0, string tripDate = "", string backdate = "", int backwayRoutId = 0)
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
        public IActionResult confirmation(ViewModel_Prepay model, string backdate = "", int backwayRoutId = 0)
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
        public IActionResult Accounting()
        {
            return View();
        }
    }
}