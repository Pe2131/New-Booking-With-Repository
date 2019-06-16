using System;
using System.Collections.Generic;
using System.IO;
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
    public class CountryController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        private IHostingEnvironment _hostingEnvironment;
        WorkWithFile WorkWithFile;
        public CountryController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            WorkWithFile = new WorkWithFile(_hostingEnvironment);
        }
        public IActionResult Index()
        {
            try
            {
                var Countries = Db.CountryRepository.Get().OrderByDescending(a => a.Id);
                var model = Mapper.Map<List<ViewModel_Country>>(Countries);
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tbl_Country Model, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (WorkWithFile.CheckImage(Image) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(Image, "Files\\Images\\Countries\\", 300, 300);
                        Model.Image = FileName;
                        Db.CountryRepository.Insert(Model);
                        await Db.CountryRepository.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "save successfull";
                        return RedirectToAction(nameof(Index));
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
        public  IActionResult Edit(int id)
        {
            try
            {
                var Model = Db.CountryRepository.GetById(id);
                return View(Model);
            }
            catch (Exception e)
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tbl_Country Model, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var country = Db.CountryRepository.GetById(Model.Id);
                    if (Image != null)
                    {
                        if (WorkWithFile.CheckImage(Image) == null)
                        {
                            WorkWithFile.DeleteImage("/Files/Images/Countries/" + Model.Image);
                            string FileName = WorkWithFile.ImageUpoad(Image, "Files\\Images\\Countries\\", 300, 300);
                            country.Image = FileName;
                          
                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = WorkWithFile.CheckImage(Image);
                            return View();
                        }
                    }
                    country.Name = Model.Name;
                    country.Code = Model.Code;
                    Db.CountryRepository.Update(country);
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
                var Cities = Db.CityRepository.Get(a => a.Country_FG == id).ToList();
                if (Cities.Any())
                {
                    foreach (var item in Cities)
                    {
                        Db.CityRepository.Delete(item);
                    }
                }
                var country = Db.CountryRepository.GetById(id);
                WorkWithFile.DeleteImage("/Files/Images/Countries/" + country.Image);
                Db.CountryRepository.Delete(id);
                await Db.CountryRepository.Save();
                return Json(1);
            }
            catch (Exception )
            {
                return Json(0);
            }
        }
    }
}