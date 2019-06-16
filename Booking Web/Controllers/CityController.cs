using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking_Web.Utility;
using Booking_Web.ViewModel;
using DAL.Model;
using DAL.Model.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    public class CityController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        private IHostingEnvironment _hostingEnvironment;
        WorkWithFile WorkWithFile;
        public CityController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            WorkWithFile = new WorkWithFile(_hostingEnvironment);
        }
        public IActionResult Index()
        {
            try
            {
                var Cities = Db.CityRepository.Get().OrderByDescending(a => a.Id);
                var model = Mapper.Map<List<ViewModel_City>>(Cities);
                return View(model);
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
                ViewBag.countries = Db.CountryRepository.Get();
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
        public async Task<IActionResult> Create(Tbl_City Model, IFormFile Image)
        {
            try
            {
                ViewBag.countries = Db.CountryRepository.Get();
                if (ModelState.IsValid)
                {
                    if (WorkWithFile.CheckImage(Image) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(Image, "Files\\Images\\Citis\\", 800, 500);
                        Model.Image = FileName;
                        Db.CityRepository.Insert(Model);
                        await Db.CountryRepository.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return View();
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = WorkWithFile.CheckImage(Image);
                        return View();
                    }
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
                ViewBag.countries = Db.CountryRepository.Get();
                var model = Db.CityRepository.GetById(id);
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
        public async Task<IActionResult> Edit(Tbl_City Model, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var City = Db.CityRepository.GetById(Model.Id);
                    if (Image != null)
                    {
                        if (WorkWithFile.CheckImage(Image) == null)
                        {
                            WorkWithFile.DeleteImage("/Files/Images/Citis/" + Model.Image);
                            string FileName = WorkWithFile.ImageUpoad(Image, "Files\\Images\\Citis\\", 800, 500);
                            City.Image = FileName;

                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = WorkWithFile.CheckImage(Image);
                            return View();
                        }
                    }
                    City.name = Model.name;
                    City.Country_FG = Model.Country_FG;
                    Db.CityRepository.Update(City);
                    await Db.CountryRepository.Save();
                    TempData["Style"] = "alert alert-success text-center";
                    TempData["Message"] = "Saved";
                    return RedirectToAction(nameof(Index));
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
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var City = Db.CityRepository.GetById(id);
                WorkWithFile.DeleteImage("/Files/Images/Citis/" + City.Image);
                Db.CityRepository.Delete(id);
                await Db.CityRepository.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        [HttpPost]
        public async Task<JsonResult> ShowForSlider(int id, bool setToSLider)
        {
            try
            {
                var City = Db.CityRepository.GetById(id);
                int result = 1;
                if (setToSLider)
                {
                    City.ShowInSlider = true;
                    result = 1;
                }
                else
                {
                    City.ShowInSlider = false;
                    result = 0;
                }
                Db.CityRepository.Update(City);
                await Db.CityRepository.Save();
                return Json(result);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
        public string GetCityName(int id)
        {
            try
            {
                return Db.CityRepository.GetById(id).name;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}