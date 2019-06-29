using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Booking_Web.Models;
using Booking_Web.Utility;
using DAL.Model;
using DAL.Model.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    public class WeblogController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private readonly AccountController accountController;
        UnitOfWork Db = new UnitOfWork();
        WorkWithFile WorkWithFile;
        public WeblogController(IHostingEnvironment env, AccountController _accountController)
        {
            hostingEnvironment = env;
            accountController = _accountController;
            WorkWithFile = new WorkWithFile(hostingEnvironment);
        }
        public IActionResult Index()
        {
            try
            {
                var q = Db.WeblogRepositori.Get(null, a => a.OrderByDescending(b => b.id), "Tbl_Users");
                return View(q);
            }

            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }


        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWebLog(Tbl_Weblog model, IFormFile ImageUpload)
        {
            try
            {

                model.Date = DateTime.Now;
                model.UserId_Fk = await accountController.GetUserId(User.Identity.Name);
                model.Authore = await accountController.GetUserFullName(User.Identity.Name);
                if (ModelState.IsValid)
                {
                    if (WorkWithFile.CheckImage(ImageUpload) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(ImageUpload, "Files\\Images\\Weblog\\", 800, 500);
                        WorkWithFile.ImageUpoad(ImageUpload, "Files\\Images\\ThumbNail\\", 200, 200);
                        model.image = FileName;
                        Db.WeblogRepositori.Insert(model);
                        await Db.WeblogRepositori.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return View("Create", model);
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = WorkWithFile.CheckImage(ImageUpload);
                        return View("Create", model);
                    }
                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View("Create", model);
                }
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {

                var q = Db.WeblogRepositori.GetById(id);
                return View(q);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(Tbl_Weblog model, IFormFile ImageUpload)
        {
            try
            {
                model.UserId_Fk = await accountController.GetUserId(User.Identity.Name);
                model.Authore = await accountController.GetUserFullName(User.Identity.Name);
                var q = Db.WeblogRepositori.GetById(model.id);
                string oldimage = q.image;
                string image = "";
                model.Authore = q.Authore;
                model.UserId_Fk = q.UserId_Fk;
                if (ModelState.IsValid)
                {
                    if (!WorkWithFile.CheckImageIsnull(ImageUpload))
                    {
                        if (WorkWithFile.CheckImage(ImageUpload) == null)
                        {
                            string FileName = WorkWithFile.ImageUpoad(ImageUpload, "Files\\Images\\Weblog\\", 800, 500);
                            WorkWithFile.ImageUpoad(ImageUpload, "Files\\Images\\ThumbNail\\", 200, 200);
                            image = FileName;
                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = WorkWithFile.CheckImage(ImageUpload);
                            return View("Create", model);
                        }
                    }
                    q.Title = model.Title;
                    q.KeyWords = model.KeyWords;
                    q.image = image != "" ? image : oldimage;
                    q.Description = model.Description;
                    Db.WeblogRepositori.Update(q);
                    await Db.WeblogRepositori.Save();
                    TempData["Style"] = "alert alert-success text-center";
                    TempData["Message"] = "Edited";
                    return RedirectToAction(nameof(Edit), model);
                }

                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View("Edit", model);
                }
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "error";
                error.ErrorMassage = e.Message;
                return View("Error", error);
            }
        }
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var weblog = Db.WeblogRepositori.GetById(id);
                Db.WeblogRepositori.Delete(id);
                WorkWithFile.DeleteImage("/Files/Images/Weblog/" + weblog.image);
                WorkWithFile.DeleteImage("/Files/Images/ThumbNail/" + weblog.image);
                await Db.WeblogRepositori.Save();
                TempData["Style"] = "alert alert-success text-center";
                TempData["Message"] = "Deleted";
                return Json(1);
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "error";
                error.ErrorMassage = e.Message;
                return Json(0);
            }
        }
    }
}