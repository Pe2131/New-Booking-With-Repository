using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking_Web.Utility;
using Booking_Web.ViewModel;
using DAL.Model;
using DAL.Model.Tables;
using Microsoft.AspNetCore.Mvc;


namespace Booking_Web.Controllers
{
    public class DiscountController : Controller
    {
        UnitOfWork Db = new UnitOfWork();
        NormalUtility UtilTools = new NormalUtility();
        public IActionResult Index()
        {
            var Discounts = Db.DisCountRepository.Get().OrderByDescending(a=>a.Id);
            var model = Mapper.Map<List<ViewModel_Discounts>>(Discounts);
            return View(model);
        }
        public IActionResult Create()
        {
            try
            {
                ViewBag.paths = Mapper.Map<List<ViewModel_PathWay>>(Db.PathWayRepository.Get());
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
        public async Task<IActionResult> Create(Tbl_Discount Model, string Start, string End, string Money, bool TypeOfDiscount,string[] Pathways)
        {
            try
            {
                ViewBag.paths = Mapper.Map<List<ViewModel_PathWay>>(Db.PathWayRepository.Get());
                if (ConfirmModel(Start, End) == null)
                {
                    Model.StartTime = UtilTools.ConvertStringToDate(Start);  // for convert string date format to dateTime
                    Model.EndTime = UtilTools.ConvertStringToDate(End); // for convert string date format to dateTime
                   if(!Model.StartTime.ConfirmDate(Model.EndTime))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "entered date is invalid";
                        return View();
                    }
                    Model = SetDiscountType(Model, TypeOfDiscount, Money); // this method correct descount mode 
                    Model.PathWays = UtilTools.StaringArrayToString(Pathways);
                    Model.IsSpecific = (Model.PathWays != null) ? true : false;
                    if (ModelState.IsValid)
                    {
                        Db.DisCountRepository.Insert(Model);
                        await Db.DisCountRepository.Save();
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
                var Discount = Db.DisCountRepository.GetById(id);
                ViewBag.Start = UtilTools.ConvertDateToString(Discount.StartTime);
                ViewBag.End = UtilTools.ConvertDateToString(Discount.EndTime);
                ViewBag.paths = Mapper.Map<List<ViewModel_PathWay>>(Db.PathWayRepository.Get());
                ViewBag.Selected = UtilTools.StringToarrayStarin(Discount.PathWays);
                return View(Discount);
            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View();
            }
          
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tbl_Discount Model, string Start, string End, string Money, bool TypeOfDiscount, string[] Pathways)
        {
            try
            {
                var Discount = Db.DisCountRepository.GetById(Model.Id);
                ViewBag.Start = Start;
                ViewBag.End = End;
                ViewBag.paths = Mapper.Map<List<ViewModel_PathWay>>(Db.PathWayRepository.Get());
                ViewBag.Selected = UtilTools.StringToarrayStarin(Discount.PathWays);
                if (ConfirmModel(Start, End) == null)
                {
                    Model.StartTime = UtilTools.ConvertStringToDate(Start);  // for convert string date format to dateTime
                    Model.EndTime = UtilTools.ConvertStringToDate(End); // for convert string date format to dateTime
                    if (!Model.StartTime.ConfirmDate(Model.EndTime))
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "entered date is invalid";
                        return View(Model);
                    }
                    Model = SetDiscountType(Model, TypeOfDiscount, Money); // this method correct descount mode 
                    Discount.StartTime = Model.StartTime;
                    Discount.EndTime = Model.EndTime;
                    Discount.Percent = Model.Percent;
                    Discount.Title = Model.Title;
                    Discount.Count = Model.Count;
                    Discount.Price = Model.Price;
                    Discount.Type = Model.Type;
                    Discount.PathWays =UtilTools.StaringArrayToString(Pathways);
                    Discount.IsSpecific = (Discount.PathWays != null) ? true : false;
                    if (ModelState.IsValid)
                    {
                        Db.DisCountRepository.Update(Discount);
                        await Db.DisCountRepository.Save();
                        TempData["Style"] = "alert alert-success text-center";
                        TempData["Message"] = "Saved";
                        return RedirectToAction(nameof(Index));
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
                Db.DisCountRepository.Delete(id);
                await Db.DisCountRepository.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }

        /// <summary>
        /// this 2 method in order that modelstateis valid cant recognize All Date Format and i use bool for type that int kind 
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
        public Tbl_Discount SetDiscountType(Tbl_Discount Model,bool TypeOfDisvount,string Money)
        {
            if (TypeOfDisvount) //percent mode
            {
                Model.Type = 1;
                Model.Price = 0;
            }

            else
            {
                Model.Type = 0;
                Model.Percent = 0;
                if (Money != null)
                {
                    Model.Price = Convert.ToDecimal(Money);
                }
                else
                {
                    Model.Price = 0;
                }

            }
            return Model;
        }

    }
}