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
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    public class PathWayController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        NormalUtility UtilTools = new NormalUtility();
        public IActionResult Index()
        {
            try

            {
                CheckActivePass();
                var pathways = Db.PathWayRepository.Get(a=>a.Status!="Deactive",orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_PathWay>>(pathways);
                return View(Model);
            }
            catch (Exception e)
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }

        }
        public IActionResult Create()
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                return View();
            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(Tbl_PathWay Model, string Start, string End)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                if (ConfirmModel(Start, End) == null)
                {
                    Model.StartDate = UtilTools.ConvertStringToDate(Start);  // for convert string date format to dateTime
                    Model.ArrivalDate = UtilTools.ConvertStringToDate(End); // for convert string date format to dateTime
                    if (!Model.StartDate.ConfirmDate(Model.ArrivalDate))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "enterd date is invalid";
                        return View();
                    }
                    if (Model.Source_FG == Model.Destination_FG)
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "Source and Destination Cant Be equal";
                        return View();
                    }
                    if (ModelState.IsValid)
                    {
                        Db.PathWayRepository.Insert(Model);
                        await Db.PathWayRepository.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return View();
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = ModelState.GetErrors();
                        return View();
                    }
                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ConfirmModel(Start, End);
                    return View();
                }
            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                var model = Db.PathWayRepository.GetById(id);
                ViewBag.Start = UtilTools.ConvertDateToString(model.StartDate);
                ViewBag.End = UtilTools.ConvertDateToString(model.ArrivalDate);
                return View(model);
            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tbl_PathWay Model, string Start, string End)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                var pathWay = Db.PathWayRepository.GetById(Model.id);
                ViewBag.Start = Start;
                ViewBag.End = End;
                if (ConfirmModel(Start, End) == null)
                {
                    Model.StartDate = UtilTools.ConvertStringToDate(Start);  // for convert string date format to dateTime
                    Model.ArrivalDate = UtilTools.ConvertStringToDate(End); // for convert string date format to dateTime
                    if (!Model.StartDate.ConfirmDate(Model.ArrivalDate))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "start date is bigger than end date";
                        return View(Model);
                    }
                    if (Model.Source_FG == Model.Destination_FG)
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "Source and Destination Cant Be equal";
                        return View(Model);
                    }
                    if (ModelState.IsValid)
                    {
                        pathWay.Source_FG = Model.Source_FG;
                        pathWay.Destination_FG = Model.Destination_FG;
                        pathWay.StartDate = Model.StartDate;
                        pathWay.ArrivalDate = Model.ArrivalDate;
                        pathWay.PriceForAdultDollar = Model.PriceForAdultDollar;
                        pathWay.PriceForAdultUro = Model.PriceForAdultUro;
                        pathWay.PriceForBabyDollar = Model.PriceForBabyDollar;
                        pathWay.PriceForBabyUro = Model.PriceForBabyUro;
                        pathWay.Capacity = Model.Capacity;
                        pathWay.Status = Model.Status;
                        Db.PathWayRepository.Update(pathWay);
                        await Db.PathWayRepository.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return View(Model);
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = ModelState.GetErrors();
                        return View(Model);
                    }
                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ConfirmModel(Start, End);
                    return View(Model);
                }

            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View(Model);
            }
        }
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var factores = Db.FactoreRepository.Get(a => a.PathwayId_FG == id).ToList();
                if (factores.Any())
                {
                    return Json(0);
                }
                Db.PathWayRepository.Delete(id);
                await Db.PathWayRepository.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public IActionResult GetDeactivePath()
        {
            try
            {
                CheckActivePass();
                var DeactivePath = Db.PathWayRepository.Get(a => a.Status == "Deactive", orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_PathWay>>(DeactivePath);
                return PartialView("P_GetDeactivePath",Model);
            }
            catch (Exception e)
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return PartialView("P_GetDeactivePath");
            }
        }
        /// <summary>
        /// this 1 method in order that modelstateis valid cant recognize All Date Format and i use bool for type that int kind 
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public string ConfirmModel(string Start, string End)
        {
            if (string.IsNullOrEmpty(Start))
            {
                return "please enter start date";
            }
            else
            {

            }
            if (string.IsNullOrEmpty(End))
            {
                return "please enter End date";
            }
            else return null;
        }
        public async void CheckActivePass()  // for cheking active pass until this time
        {
            try
            {
                var activePathWay = Db.PathWayRepository.Get(a=>a.Status!="Deactive");
                if (activePathWay.Any())
                {
                    foreach (var item in activePathWay)
                    {
                        if (UtilTools.CompareDate(DateTime.Now, item.StartDate) == 1)
                        {
                            item.Status = "Deactive";
                            Db.PathWayRepository.Update(item);
                        }
                    }
                    await Db.PathWayRepository.Save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<JsonResult> ChangeStatus(int id,string status)
        {
            try
            {
                var path = Db.PathWayRepository.GetById(id);
                path.Status = status;
                Db.PathWayRepository.Update(path);
                await Db.PathWayRepository.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public IActionResult SearchPath(int source,int dest,string date,int count)
        {
            try
            {
                CheckActivePass();
                PathWayController pathWay = new PathWayController();
                pathWay.CheckActivePass();
                var pathways = Db.PathWayRepository.Get(a => a.Status != "Deactive" &a.Source_FG==source &a.Destination_FG==dest & a.Capacity > 0, orderby: a => a.OrderByDescending(b => b.id));
                if (date != null)
                {
                  DateTime dateTime=  UtilTools.ConvertStringToDateOnly(date);
                    pathways = pathways.Where(a => a.StartDate.Date.CompareTo(dateTime.Date) == 0);
                }
                if(count != 0)
                {
                    pathways = pathways.Where(a => a.Capacity >= count);
                }
                var Model = Mapper.Map<List<ViewModel_PathWay>>(pathways);
                return PartialView("P_SearchPath",Model);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "Error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public List<ViewModel_PathWay> SearchPathForReserv(int source, int dest, string date, int count)
        {
            try
            {
                CheckActivePass();
                PathWayController pathWay = new PathWayController();
                pathWay.CheckActivePass();
                var pathways = Db.PathWayRepository.Get(a => a.Status != "Deactive" & a.Source_FG == source & a.Destination_FG == dest & a.Capacity > 0, orderby: a => a.OrderByDescending(b => b.id));
                if (date != null)
                {
                    DateTime dateTime = UtilTools.ConvertStringToDateOnly(date);
                    pathways = pathways.Where(a => a.StartDate.Date.CompareTo(dateTime.Date) == 0);
                }
                if (count != 0)
                {
                    pathways = pathways.Where(a => a.Capacity >= count);
                }
                var Model = Mapper.Map<List<ViewModel_PathWay>>(pathways);
                return Model.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}