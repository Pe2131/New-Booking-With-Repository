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
                var Route = Db.RoutRepositori.Get(a => a.Status != "Deactive", orderby: a => a.OrderByDescending(b => b.id));
                var Model = Mapper.Map<List<ViewModel_Routes>>(Route);
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
        public async Task<IActionResult> Create(Tbl_Routes Model, ViewModel_Price price)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                Model.Price = Convert.ToDecimal(price.price11, CultureInfo.InvariantCulture);
                Model.twoWayPrice = Convert.ToDecimal(price.price22, CultureInfo.InvariantCulture);
                Model.Price2 = Convert.ToDecimal(price.price33, CultureInfo.InvariantCulture);
                Model.twoWayPrice2 = Convert.ToDecimal(price.price44, CultureInfo.InvariantCulture);
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
        public async Task<IActionResult> Edit(Tbl_Routes Model, ViewModel_Price price)
        {
            try
            {
                ViewBag.cities = Db.CityRepository.Get(orderby: a => a.OrderByDescending(b => b.Id));
                Model.Price = Convert.ToDecimal(price.price11, CultureInfo.InvariantCulture);
                Model.twoWayPrice = Convert.ToDecimal(price.price22, CultureInfo.InvariantCulture);
                Model.Price2 = Convert.ToDecimal(price.price33, CultureInfo.InvariantCulture);
                Model.twoWayPrice2 = Convert.ToDecimal(price.price44, CultureInfo.InvariantCulture);
                var Route = Db.RoutRepositori.GetById(Model.id);
                if (Model.Source_FG == Model.Destination_FG)
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = "Source and Destination Cant Be equal";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    Route.Source_FG = Model.Source_FG;
                    Route.Destination_FG = Model.Destination_FG;
                    Route.DepartureDays = Model.DepartureDays;
                    Route.DepartureTime = Model.DepartureTime;
                    Route.Price = Model.Price;
                    Route.twoWayPrice = Model.twoWayPrice;
                    Route.Price2 = Model.Price2;
                    Route.twoWayPrice2 = Model.twoWayPrice2;
                    Route.ArriveDays = Model.ArriveDays;
                    Route.ArriveTime = Model.ArriveTime;
                    Route.DestStation = Model.DestStation;
                    Route.SourceStation = Model.SourceStation;
                    Route.Status = Model.Status;
                    Db.RoutRepositori.Update(Route);
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
        public PartialViewResult GetDestination(int id)
        {
            try
            {
                var routes = Db.RoutRepositori.Get(a => a.Source_FG == id);
                List<Tbl_City> cities = new List<Tbl_City>();
                List<Tbl_Country> countries = new List<Tbl_Country>();
                foreach (var item in routes)
                {
                    var city = Db.CityRepository.Get(a => a.Id == item.Destination_FG, null, "Tbl_Country").SingleOrDefault();
                    if (city != null)
                    {
                        cities.Add(city);
                        countries.Add(city.Tbl_Country);
                    }
                }
                if (cities == null)
                {
                    return PartialView("P_DestinationCity", null);
                }
                ViewBag.Countries = Mapper.Map<List<ViewModel_Country>>(countries.Distinct());
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