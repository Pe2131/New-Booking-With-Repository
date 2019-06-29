using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking_Web.Models;
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
        private readonly AccountController accountController;
        public ReservationController(UserManager<Tbl_Users> _userManager, AccountController account)
        {
            accountController = account;
        }
        public IActionResult Index()
        {
            PathWayController pathWay = new PathWayController();
            pathWay.CheckActivePass();
            var pathways = Db.PathWayRepository.Get(a => a.Status != "Deactive" & a.Capacity > 0, orderby: a => a.OrderByDescending(b => b.id));
            var Model = Mapper.Map<List<ViewModel_PathWay>>(pathways);
            ViewBag.cities = Db.CityRepository.Get().ToList();
            return View(Model);
        }
        public IActionResult ReservForm(int id)
        {
            try
            {
                var path = Db.PathWayRepository.Get(a => a.id == id).SingleOrDefault();
                var pathmodel = Mapper.Map<ViewModel_PathWay>(path);
                ViewModel_Reserve model = new ViewModel_Reserve();
                model.PathId = id;
                model.DestName = pathmodel.GetDestinationName;
                model.SourceName = pathmodel.GetSourceName;
                model.PathDate = pathmodel.StartDate.ToString();
                model.PriceForAdult = pathmodel.PriceForAdultUro;
                model.PriceForBaby = pathmodel.PriceForBabyUro;
                model.Adult = 0;
                model.Baby = 0;
                return PartialView("P_ReservForm", model);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.InnerException.ToString();
                return View("Error", error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation(ViewModel_Reserve model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ReservedDate = DateTime.Now;
                    string userid = await accountController.GetUserId(User.Identity.Name);
                    PathWayController pathWayController = new PathWayController();
                    pathWayController.CheckActivePass();
                    var path = Db.PathWayRepository.Get(a => a.id == model.PathId).SingleOrDefault();
                    path.Capacity = path.Capacity - model.SumCount;
                    if (path.Capacity >= 0 && path.Status != "Deactive")
                    {
                        Tbl_Reserve reserv = new Tbl_Reserve
                        {
                            Adult = model.Adult,
                            Baby = model.Baby,
                            Fullname = model.Fullname,
                            AgentId = userid,
                            PathId = model.PathId,
                            Status = "reserved",
                            SumCount = model.SumCount,
                            SumPrice = model.SumPrice,
                            ReservedDate = model.ReservedDate
                        };
                        Db.ReservRepositori.Insert(reserv);
                        Db.PathWayRepository.Update(path);
                        await Db.ReservRepositori.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "This path maybe was Deactived";
                        return RedirectToAction(nameof(Index));
                    }

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
            var pathways = Db.PathWayRepository.Get(null, orderby: a => a.OrderByDescending(b => b.id));
            var pathModel = Mapper.Map<List<ViewModel_PathWay>>(pathways);
            if (Userroles.Contains("Admin"))
            {
                var result = Db.ReservRepositori.Get(null, null, "Tbl_Users,Tbl_PathWay").OrderByDescending(a => a.Id).ToList();
                var model = Mapper.Map<List<ViewModel_Reserve>>(result);
                foreach (var item in model)
                {
                    item.SourceName = pathModel.Where(a => a.id == item.PathId).SingleOrDefault().GetSourceName;
                    item.DestName= pathModel.Where(a => a.id == item.PathId).SingleOrDefault().GetDestinationName;
                }
                return View(model);
            }
            else
            {
                var result = Db.ReservRepositori.Get(a => a.AgentId == userid & a.Status!="Deleted", a => a.OrderByDescending(b => b.Id), "Tbl_Users,Tbl_PathWay").OrderByDescending(a => a.Id).ToList();
                var model = Mapper.Map<List<ViewModel_Reserve>>(result);
                foreach (var item in model)
                {
                    item.SourceName = pathModel.Where(a => a.id == item.PathId).SingleOrDefault().GetSourceName;
                    item.DestName = pathModel.Where(a => a.id == item.PathId).SingleOrDefault().GetDestinationName;
                }
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult EditReserv(int id)
        {
            try
            {
                var reserv = Db.ReservRepositori.Get(a => a.Id == id, null, "Tbl_Users,Tbl_PathWay").SingleOrDefault();
                var path = Db.PathWayRepository.Get(a => a.id == reserv.PathId).SingleOrDefault();
                var model = Mapper.Map<ViewModel_Reserve>(reserv);
                var pathmodel = Mapper.Map<ViewModel_PathWay>(path);
                model.PriceForAdult = pathmodel.PriceForAdultUro;
                model.PriceForBaby = pathmodel.PriceForBabyUro;
                model.SourceName = pathmodel.GetSourceName;
                model.DestName = pathmodel.GetDestinationName;
                model.PathDate = pathmodel.StartDate.ToString();
                return PartialView("P_EditReserv", model);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.InnerException.ToString();
                return View("Error", error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditReserv(ViewModel_Reserve model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ReservedDate = DateTime.Now;
                    var reserv = Db.ReservRepositori.GetById(model.Id);
                    var path = Db.PathWayRepository.Get(a => a.id == model.PathId).SingleOrDefault();
                    if (model.SumCount > reserv.SumCount)
                    {
                        int diffrence = model.SumCount - reserv.SumCount;
                        path.Capacity = path.Capacity - diffrence;
                    }
                    else if (model.SumCount < reserv.SumCount)
                    {
                        int diffrence = reserv.SumCount - model.SumCount;
                        path.Capacity = path.Capacity + diffrence;
                    }
                    if (path.Capacity >= 0)
                    {
                        reserv.Adult = model.Adult;
                        reserv.Baby = model.Baby;
                        reserv.Fullname = model.Fullname;
                        reserv.SumCount = model.SumCount;
                        reserv.SumPrice = model.SumPrice;
                        reserv.ReservedDate = model.ReservedDate;
                        Db.ReservRepositori.Update(reserv);
                        Db.PathWayRepository.Update(path);
                        await Db.ReservRepositori.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return RedirectToAction(nameof(ManageReservs));
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "This path capacity not  matched";
                        return RedirectToAction(nameof(ManageReservs));
                    }

                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return RedirectToAction(nameof(ManageReservs));
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
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var reserv = Db.ReservRepositori.GetById(id);
                if (reserv.Status != "Deleted")
                {
                    var path = Db.PathWayRepository.GetById(reserv.PathId);
                    path.Capacity = path.Capacity + reserv.SumCount;
                    reserv.Status = "Deleted";
                    Db.PathWayRepository.Update(path);
                    Db.ReservRepositori.Update(reserv);
                    await Db.ReservRepositori.Save();
                    return Json(1);
                }
                return Json(1);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        public IActionResult Accounting()
        {
            return View();
        }
    }
}