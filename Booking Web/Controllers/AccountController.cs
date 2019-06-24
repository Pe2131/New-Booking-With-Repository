using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Booking_Web.InterFaces;
using Booking_Web.Models;
using Booking_Web.Utility;
using Booking_Web.ViewModel;
using DAL.Model;
using DAL.Model.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        private readonly ApplicationDbContext DbInjection;
        private readonly UserManager<Tbl_Users> userManager;
        private readonly SignInManager<Tbl_Users> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private IHostingEnvironment hostingEnvironment;
        private readonly IEmailService emailSender;
        WorkWithFile WorkWithFile;
        ErrorViewModel ErrorModel = new ErrorViewModel();  // for send error data to view error
        public AccountController(UserManager<Tbl_Users> _userManager, SignInManager<Tbl_Users> _signInManager, IHostingEnvironment _hostingEnvironment, RoleManager<IdentityRole> _roleManager, IEmailService _emailsender, ApplicationDbContext database)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            hostingEnvironment = _hostingEnvironment;
            emailSender = _emailsender;
            DbInjection = database;
            WorkWithFile = new WorkWithFile(_hostingEnvironment);
        }
        public async Task<IActionResult> Index()

        {
            try
            {
                ViewBag.index = 1;     // for show index 
                if (User.Identity.IsAuthenticated)
                {
                    var user = await userManager.FindByEmailAsync(User.Identity.Name);
                    var UserRole = await userManager.GetRolesAsync(user);
                    if (UserRole.Contains("Admin"))
                    {
                        ViewBag.TotalPath = db.PathWayRepository.Get(a => a.Status != "Deactive").Count();
                        ViewBag.TotalCountry = db.CountryRepository.Get().Count();
                        ViewBag.TotalCity = db.CityRepository.Get().Count();
                        var Agents = await userManager.GetUsersInRoleAsync("Agent");
                        ViewBag.TotalAgent = Agents.Count();
                        var Users = await userManager.GetUsersInRoleAsync("User");
                        ViewBag.TotalUser = Users.Count();
                        ViewBag.Newsletter = db.NewsLetterRepositori.Get().Count();
                        return View("AdimnHome");
                    }
                    else
                    {
                        if (!await userCheck())
                        {
                            ViewBag.index = 0;    // for show register form 
                            return View();
                        }
                        else
                        {
                            ViewModel_User model_User = new ViewModel_User();
                            model_User.Address = user.Address;
                            model_User.City = user.City;
                            model_User.Country = user.Country;
                            model_User.Email = user.Email;
                            model_User.FullName = user.FullName;
                            model_User.Sex = user.Sex;
                            model_User.Mobile = user.Mobile;
                            model_User.RoleNames = await userManager.GetRolesAsync(user);
                            return View(model_User);
                        }
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public async Task<IActionResult> UserInfo()
        {
            try
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                ViewModel_User model_User = new ViewModel_User();
                model_User.Address = user.Address;
                model_User.City = user.City;
                model_User.Country = user.Country;
                model_User.Email = user.Email;
                model_User.FullName = user.FullName;
                model_User.Sex = user.Sex;
                model_User.Mobile = user.Mobile;
                model_User.RoleNames = await userManager.GetRolesAsync(user);
                return View(model_User);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/Login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Login")]
        public async Task<IActionResult> Login(ViewModel_Login model, string returnUrl = null)
        {
            try
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    var user = signInManager.UserManager.Users.Where(a => a.Email == model.Email).FirstOrDefault();
                    var CheckConfirmEmail = signInManager.UserManager.Users.Where(c => c.Email == model.Email).FirstOrDefault();
                    if (result.Succeeded)
                    {
                        if (CheckConfirmEmail.EmailConfirmed == true)
                        {
                            var role = await userManager.GetRolesAsync(user);
                            if (role.Contains("Admin"))
                            {
                                return RedirectToAction(nameof(Index));
                            }
                            if (role.Contains("Agent"))
                            {
                                return RedirectToAction("Index", "Reservation");
                            }
                            return RedirectToLocal(returnUrl);
                        }
                        else
                        {
                            if (returnUrl != null)
                            {
                                RedirectToLocal(returnUrl);
                            }
                            ModelState.AddModelError(string.Empty, "this Account isnt Enable");
                            return View(model);
                        }
                    }
                    if (result.IsLockedOut)
                    {
                        if (returnUrl != null)
                        {
                            RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError(string.Empty, "Your Account is locked");
                        // return View(model);
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        if (returnUrl != null)
                        {
                            RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError(string.Empty, "username or password is invalid");
                        //return View(model);
                        return RedirectToAction("index", "Home");
                    }
                }
                else
                {
                    if (returnUrl != null)
                    {
                        RedirectToLocal(returnUrl);
                    }
                    ModelState.AddModelError(string.Empty, ModelState.GetErrors());
                    return View("login");
                }
            }
            catch (Exception e)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.ErrorTitle = "error";
                error.ErrorMassage = e.InnerException.ToString();
                return View("Error", error);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewModel_Register model, string returnUrl = null)
        {
            try
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var user = new Tbl_Users { Email = model.Email, UserName = model.Email };
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //await CreateRole("User");   // for checking user role is Exict or not
                        var result1 = await userManager.AddToRoleAsync(user, "User");
                        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                        await emailSender.SendEmailAsync(model.Email, "Confirm Account",
                           $"Pleas Enter the link: <a href='{callbackUrl}'>Link</a>");
                        TempData["Message"] = "Registration was Successfull" + Environment.NewLine + "(if doesnt exict in your mail check your Spam)";
                        return View("Login", model);
                    }

                    AddErrors(result);
                }
                return View("Login", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            try
            {
                if (userId == null || code == null)
                {
                    ErrorModel.ErrorTitle = "Error";
                    ErrorModel.ErrorMassage = "Your Link is invalid";
                    return View("Error", ErrorModel);
                }
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ErrorModel.ErrorTitle = "Error";
                    ErrorModel.ErrorMassage = "this user isnt exict";
                    return View("Error", ErrorModel);
                }
                var result = await userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                {
                    TempData["Message"] = "your Account successfully enabeled";
                    return View("login");
                }
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = "there is a problem in enabling your account";
                return View("Error", ErrorModel);
            }
            catch (Exception e)
            {
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = e.InnerException.ToString();
                return View("Error", ErrorModel);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string Email)
        {

            try
            {
                var user = await userManager.FindByNameAsync(Email);
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    ModelState.AddModelError(string.Empty, "this account isnt exist" + Environment.NewLine + "or your account isnt enable");
                    return View();
                }

                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                new { UserId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await emailSender.SendEmailAsync(Email, "Password Recovery",
                        "please enter the link: <a href=\"" + callbackUrl + "\">link</a>");
                TempData["Message"] = "Recovery Link was sent";
                return View();
            }
            catch (Exception e)
            {
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = e.Message;
                return View("Error", ErrorModel);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword(ViewModel_ChangePass model)
        {
            ViewBag.userid = model.UserId;
            ViewBag.code = model.code;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string password, ViewModel_ChangePass model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var token = model.code;
                    var result = await userManager.ResetPasswordAsync(user, token, password);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "password is changed";
                        return View("Login");
                    }
                    else
                    {
                        AddErrors(result);
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username is invalid!");
                    return View();
                }
            }
            else
            {

                ModelState.AddModelError(string.Empty, ModelState.GetErrors());
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
            }
            // return RedirectToAction(nameof(Login));
            return RedirectToAction("index", "Home");
        }
        //  [Authorize(Roles = "admin")]
        public async Task<IActionResult> getUsers() //get all user with their Roles
        {
            var userRoles = new List<ViewModel_User>();
            //var userStore = new UserStore<Tbl_Users>(Db);
            var q = db.UserRepository.Get();
            //Get all the usernames
            foreach (var user in q)
            {
                var r = new ViewModel_User
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Country = user.Country,
                    City = user.City,
                    Id = user.Id,
                    Mobile = user.Mobile,
                    image = user.Image

                };
                userRoles.Add(r);

                //Get all the Roles for our users
                foreach (var user1 in userRoles)
                {
                    user1.RoleNames = await userManager.GetRolesAsync(db.UserRepository.Get(a => a.UserName.Equals(user1.Email)).SingleOrDefault());
                }
            }
            var model = userRoles.Where(a => a.RoleNames.ToList().Contains("User")).ToList();
            return View(model);
        }
        public async Task<IActionResult> getAgents() //get all Agents with their Roles
        {
            var userRoles = new List<ViewModel_Agents>();
            //var userStore = new UserStore<Tbl_Users>(Db);
            var q = db.UserRepository.Get();
            //Get all the usernames
            foreach (var user in q)
            {
                var r = new ViewModel_Agents
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Country = user.Country,
                    City = user.City,
                    Id = user.Id,
                    Mobile = user.Mobile,
                    image = user.Image

                };
                userRoles.Add(r);

                //Get all the Roles for our users
                foreach (var user1 in userRoles)
                {
                    user1.RoleNames = await userManager.GetRolesAsync(db.UserRepository.Get(a => a.UserName.Equals(user1.Email)).SingleOrDefault());
                }
            }

            var model = userRoles.Where(a => a.RoleNames.ToList().Contains("Agent")).ToList();
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public void AddErrors(IdentityResult result) // for add identity Error to Model State
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        public async Task CreateRole(string Role)
        {
            try
            {
                bool isRoleExict = await roleManager.RoleExistsAsync(Role);
                if (!isRoleExict)
                {
                    var role = new IdentityRole();
                    role.Name = Role;
                    var result = await roleManager.CreateAsync(role);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IActionResult> GetUserDetail(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                ViewModel_User model = new ViewModel_User
                {
                    Email = user.Email,
                    Address = user.Address,
                    Country = user.Country,
                    City = user.City,
                    FullName = user.FullName,
                    Sex = user.Sex,
                    Mobile = user.Mobile,
                    Id = user.Id,
                    image = user.Image,
                    RoleNames = await userManager.GetRolesAsync(user)


                };
                return PartialView("P_GetUserDetail", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> GetUserRoles(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                ViewModel_User model = new ViewModel_User
                {
                    Email = user.Email,
                    Address = user.Address,
                    Country = user.Country,
                    City = user.City,
                    FullName = user.FullName,
                    Sex = user.Sex,
                    Mobile = user.Mobile,
                    Id = user.Id,
                    image = user.Image,
                    RoleNames = await userManager.GetRolesAsync(user)
                };
                string roles = "";
                foreach (var item in model.RoleNames)
                {
                    roles += item + ",";
                }
                ViewBag.ExictRoles = roleManager.Roles.ToList();
                ViewBag.UsersRoles = roles;
                return PartialView("P_GetUserRoles", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> SubmitInfo(ViewModel_User model, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                if (Image != null && !string.IsNullOrEmpty(Image.FileName) && Image.Length > 0)
                {
                    if (Image.ContentType.ToLower() != "image/jpg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/png")
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "this file not supprot!";
                        return Redirect(nameof(Index));
                    }
                    string uploads = Path.Combine(hostingEnvironment.WebRootPath, "Files\\Images\\Users\\");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Image.FileName.ToLower();
                    string path = Path.Combine(Path.Combine(uploads, fileName));
                    Image.OpenReadStream().ResizeImage(200, 200, path, Utilty.ImageComperssion.Normal);
                }
                if (user != null)
                {
                    user.City = model.City;
                    user.Address = model.Address;
                    user.Country = model.Country;
                    user.FullName = model.FullName;
                    user.Mobile = model.Mobile;
                    user.Sex = model.Sex;
                    user.Image = fileName;
                    db.UserRepository.Update(user);
                    await db.UserRepository.Save();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = ModelState.GetErrors();
                return RedirectToAction(nameof(Index));

            }
        }
        public IActionResult Setting()
        {
            try
            {
                var model = db.SettingRepository.Get().FirstOrDefault();
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Style"] = "alert alert-warning text-center";
                TempData["Message"] = e.InnerException;
                return View(); ;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SetSetting(Tbl_Setting model, IFormFile logo, IFormFile PanelLogo, IFormFile Image1, IFormFile Image2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var setting = db.SettingRepository.Get().FirstOrDefault();
                    if (WorkWithFile.CheckImage(logo) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(logo, "Files\\Images\\", 210, 82);
                        model.Logo = FileName;
                    }
                    else
                    {
                        model.Logo = setting.Logo;
                    }
                    if (WorkWithFile.CheckImage(PanelLogo) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(PanelLogo, "Files\\Images\\", 100, 100);
                        model.PanelLogo = FileName;
                    }
                    else
                    {
                        model.PanelLogo = setting.PanelLogo;

                    }
                    if (WorkWithFile.CheckImage(Image1) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(Image1, "Files\\Images\\", 600, 450);
                        model.AboutImag1 = FileName;
                    }
                    else
                    {
                        model.AboutImag1 = setting.AboutImag1;

                    }
                    if (WorkWithFile.CheckImage(Image2) == null)
                    {
                        string FileName = WorkWithFile.ImageUpoad(Image2, "Files\\Images\\", 600, 450);
                        model.AboutImag2 = FileName;
                    }
                    else
                    {
                        model.AboutImag2 = setting.AboutImag2;

                    }
                    db.SettingRepository.Detach(setting);
                    setting = model;
                    db.SettingRepository.Update(setting);
                    await db.SettingRepository.Save();
                    TempData["Style"] = "alert alert-success text-center";
                    TempData["Message"] = "upadte succefully";
                    return View("Setting", model);
                }
                else
                {
                    TempData["Style"] = "alert alert-danger text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View("Setting", model);
                }
            }
            catch (Exception e)
            {

                TempData["Style"] = "alert alert-success text-center";
                TempData["Message"] = e.Message;
                return View("Setting", model);
            }
        }
        public IActionResult GetNewsletterMail()
        {
            try
            {
                var model = db.NewsLetterRepositori.Get(null, a => a.OrderByDescending(b => b.Id)).ToList();
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
        public async Task<JsonResult> addOrRemoveRoles(string id, string roles)
        {
            try
            {
                if (roles != null)
                {
                    var user = await userManager.FindByIdAsync(id);
                    var currentRoles = await userManager.GetRolesAsync(user);
                    await userManager.RemoveFromRolesAsync(user, currentRoles);
                    List<string> ListAddroles = roles.StringToList();
                    await userManager.AddToRolesAsync(user, ListAddroles);
                    await db.UserRepository.Save();
                    return Json(1);
                }
                else
                {
                    return Json(0);
                }

            }
            catch (Exception)
            {

                return Json(0);
            }
        }
        public async Task<bool> userCheck()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            if (user.FullName == null || user.Mobile == null || user.Country == null || user.City == null || user.Address == null)
            {
                return false;
            }
            return true;
        }
        public JsonResult CheckMobileExist(string Mobile)
        {
            string currentUser = User.Identity.Name;
            System.Threading.Thread.Sleep(200);
            var searchData = db.UserRepository.Get(c => c.Mobile == Mobile && c.UserName != currentUser).SingleOrDefault();
            if (searchData != null)
            {
                return Json(1); // شماره موبایل از قبل وجود دارد
            }
            else
            {
                return Json(0); // وجود ندارد
            }
        }
        public async Task<List<string>> GetRole(string UserName)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(UserName);
                var roles = await userManager.GetRolesAsync(user);
                return roles.ToList();
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        public async Task<string> GetUserId(string UserName)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(UserName);
                return user.Id;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        public async Task<string> GetUserFullName(string UserName)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(UserName);
                return user.FullName;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        [HttpPost]
        public IActionResult SendMultiEmail(string selected)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(ViewModel_Agents model, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (await userManager.FindByEmailAsync(model.Email) == null)
                    {
                        string fileName = null;
                        var user = new Tbl_Users();
                        if (Image != null && !string.IsNullOrEmpty(Image.FileName) && Image.Length > 0)
                        {
                            if (Image.ContentType.ToLower() != "image/jpg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/png")
                            {
                                TempData["Style"] = "alert alert-warning text-center";
                                TempData["Message"] = "this file not support!";
                                return Redirect(nameof(Index));
                            }
                            string uploads = Path.Combine(hostingEnvironment.WebRootPath, "Files\\Images\\Users\\");
                            fileName = Guid.NewGuid().ToString().Replace("-", "") + Image.FileName.ToLower();
                            string path = Path.Combine(Path.Combine(uploads, fileName));
                            Image.OpenReadStream().ResizeImage(200, 200, path, Utilty.ImageComperssion.Normal);
                        }
                        user.City = model.City;
                        user.Address = model.Address;
                        user.Country = model.Country;
                        user.FullName = model.FullName;
                        user.Mobile = model.Mobile;
                        user.Sex = model.Sex;
                        user.Image = fileName;
                        user.Email = model.Email;
                        user.EmailConfirmed = true;
                        user.UserName = model.Email;
                        var result = await userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            var result1 = await userManager.AddToRoleAsync(user, "Agent");
                            TempData["Style"] = "alert alert-success text-center";
                            TempData["Message"] = "succefully saved";
                            return View(model);
                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = "there is problem to save!";
                            return View(model);

                        }
                    }
                    else
                    {
                        TempData["Style"] = "alert alert-warning text-center";
                        TempData["Message"] = "this User Email Exist in Database";
                        return View(model);
                    }
                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View(model);

                }
            }
            catch (Exception e)
            {
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = e.Message;
                return View("Error", ErrorModel);
            }

        }
        [HttpGet]
        public async Task<IActionResult> EditAgent(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                var model = Mapper.Map<ViewModel_Agents>(user);
                return View(model);
            }
            catch (Exception e)
            {
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = e.Message;
                return View("Error", ErrorModel);
            }

        }
        [HttpPost]
        public async Task<IActionResult> EditAgent(ViewModel_Agents model, IFormFile Image, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(id);
                    if (Image != null && !string.IsNullOrEmpty(Image.FileName) && Image.Length > 0)
                    {
                        if (Image.ContentType.ToLower() != "image/jpg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/jpeg" && Image.ContentType.ToLower() != "image/png")
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = "this file not support!";
                            return Redirect(nameof(Index));
                        }
                        string uploads = Path.Combine(hostingEnvironment.WebRootPath, "Files\\Images\\Users\\");
                        string fileName = Guid.NewGuid().ToString().Replace("-", "") + Image.FileName.ToLower();
                        string path = Path.Combine(Path.Combine(uploads, fileName));
                        Image.OpenReadStream().ResizeImage(200, 200, path, Utilty.ImageComperssion.Normal);
                        user.Image = fileName;
                    }
                    user.City = model.City;
                    user.Address = model.Address;
                    user.Country = model.Country;
                    user.FullName = model.FullName;
                    user.Mobile = model.Mobile;
                    user.Sex = model.Sex;
                    user.Email = model.Email;
                    user.EmailConfirmed = true;
                    user.UserName = model.Email;
                    var result = await userManager.UpdateAsync(user);
                    if (model.Password != null)
                    {

                        // Generate the reset token (this would generally be sent out as a query parameter as part of a 'reset' link in an email)
                        string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                        // Use the reset token to verify the provenance of the reset request and reset the password.
                        IdentityResult updatePassResult = await userManager.ResetPasswordAsync(user, resetToken, model.Password);
                        if (result.Succeeded && updatePassResult.Succeeded)
                        {
                            var result1 = await userManager.AddToRoleAsync(user, "Agent");
                            TempData["Style"] = "alert alert-success text-center";
                            TempData["Message"] = "succefully saved";
                            return View(model);
                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = "there is problem to save!";
                            return View(model);

                        }
                    }
                    else
                    {


                        if (result.Succeeded)
                        {
                            var result1 = await userManager.AddToRoleAsync(user, "Agent");
                            TempData["Style"] = "alert alert-success text-center";
                            TempData["Message"] = "succefully saved";
                            return View(model);
                        }
                        else
                        {
                            TempData["Style"] = "alert alert-warning text-center";
                            TempData["Message"] = "there is problem to save!";
                            return View(model);

                        }
                    }

                }
                else
                {
                    TempData["Style"] = "alert alert-warning text-center";
                    TempData["Message"] = ModelState.GetErrors();
                    return View(model);

                }
            }
            catch (Exception e)
            {
                ErrorModel.ErrorTitle = "Error";
                ErrorModel.ErrorMassage = e.Message;
                return View("Error", ErrorModel);
            }

        }
        /// <summary>
        /// for test
        /// </summary>
        /// <returns></returns>
        public IActionResult ApiSetting()
        {
            return View();
        }
    }
}