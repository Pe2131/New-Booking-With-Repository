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
    public class RoutesController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        NormalUtility UtilTools = new NormalUtility();
        public IActionResult Index()
        {
            try

            {
                var pathway = Db.RoutRepositori.Get(a => a.Status != "Deactive", orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_Routes>>(pathway);
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
        public async Task<IActionResult> Create(Tbl_Routes Model)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                if (Model.Source_FG == Model.Destination_FG)
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = "Source and Destination Cant Be equal";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    Db.RoutRepositori.Insert(Model);
                    await Db.RoutRepositori.Save();
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
                var model = Db.RoutRepositori.GetById(id);
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
        public async Task<IActionResult> Edit(Tbl_Routes Model)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                var pathWay = Db.RoutRepositori.GetById(Model.id);
                if (Model.Source_FG == Model.Destination_FG)
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = "Source and Destination Cant Be equal";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    pathWay.Source_FG = Model.Source_FG;
                    pathWay.Destination_FG = Model.Destination_FG;
                    pathWay.DepartureDays = Model.DepartureDays;
                    pathWay.DepartureTime = Model.DepartureTime;
                    pathWay.Price = Model.Price;
                    pathWay.ArriveDays = Model.ArriveDays;
                    pathWay.ArriveTime = Model.ArriveTime;
                    pathWay.DestStation = Model.DestStation;
                    pathWay.SourceStation = Model.SourceStation;
                    pathWay.Status = Model.Status;
                    Db.RoutRepositori.Update(pathWay);
                    await Db.RoutRepositori.Save();
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
                Db.RoutRepositori.Delete(id);
                await Db.RoutRepositori.Save();
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
                var DeactivePath = Db.RoutRepositori.Get(a => a.Status == "Deactive", orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_Routes>>(DeactivePath);
                return PartialView("P_GetDeactivePath", Model);
            }
            catch (Exception e)
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return PartialView("P_GetDeactivePath");
            }
        }
        public async Task<JsonResult> ChangeStatus(int id, string status)
        {
            try
            {
                var path = Db.RoutRepositori.GetById(id);
                path.Status = status;
                Db.RoutRepositori.Update(path);
                await Db.RoutRepositori.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public List<ViewModel_PathWay> SearchPathForReserv(int source, int dest, string date, int count)
        {
            try
            {
                var pathways = Db.RoutRepositori.Get(a => a.Status != "Deactive" & a.Source_FG == source & a.Destination_FG == dest, orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_PathWay>>(pathways);
                return Model.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public PartialViewResult GetDestination(int id)
        {
            try
            {
                var routes = Db.RoutRepositori.Get(a => a.Source_FG == id);
                List<Tbl_City> cities = new List<Tbl_City>();
                foreach (var item in routes)
                {
                    var city = Db.CityRepository.GetById(item.Destination_FG);
                    if (city != null)
                    {
                        cities.Add(city);
                    }
                }
                if (cities == null)
                {
                    return PartialView("P_DestinationCity",null);
                }
                var model = Mapper.Map<List<ViewModel_City>>(cities);
                return PartialView("P_DestinationCity", model);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public JsonResult GetDeparture(int id)
        {
            try
            {
                String departure = Db.RoutRepositori.Get(a => a.Source_FG == id).FirstOrDefault().DepartureDays;
                return Json(departure);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}