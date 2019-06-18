using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Booking_Web.Controllers;
using Booking_Web.InterFaces;
using Booking_Web.Services;
using Booking_Web.ViewModel;
using DAL.Model;
using DAL.Model.Tables;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Booking_Web.Models;
using System.Globalization;

namespace Booking_Web
{
    public class Startup
    {

        IConfigurationRoot configurationRoot;
        private IHostingEnvironment _hostingEnvironment;
        public Startup(IHostingEnvironment env)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json").Build();
            _hostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath="Resources"); // this is Multi Language setting
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            });
            services.AddIdentity<Tbl_Users, IdentityRole>()
              .AddRoleManager<RoleManager<IdentityRole>>()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<ApplicationDbContext>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // identity Configuration cookie    
            services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                //options.Cookie.Name = "OstadHamekare";
                /*options.Cookie.HttpOnly = true;*/
                //options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.LoginPath = "/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                //options.SlidingExpiration = true;
            });
            services.AddTransient<IEmailService, AuthMessageServices>(); // Dependecy injection For Email Service
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    options => { options.ResourcesPath = "Resources"; })
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(ShareResource));
                    });
            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
            var compositeProvider = new CompositeFileProvider(physicalProvider, embeddedProvider);
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddSingleton<IFileProvider>(embeddedProvider);
            services.AddSingleton<IFileProvider>(compositeProvider);
            // elmah اضافه کردن سرویس های مربوط به 
            services.AddElmah(options =>
            {
                // دسترسی پیدا کنید elamh مسیری که توسط آن میتوانید به  
                // می باشد ~/elmah این مسیر به صورت پیشفرض     
                options.Path = "/myElmah";

                // به گونه ای که ما آن را پیاده سازی می کنیم elmah محدود کردن دسترسی به 
                options.CheckPermissionAction = CheckPermissionAction;
            });
            Mapper.Initialize(map =>
            {
                map.CreateMap<Tbl_Country, ViewModel_Country>();
                map.CreateMap<Tbl_City, ViewModel_City>();
                map.CreateMap<Tbl_PathWay, ViewModel_PathWay>();
                map.CreateMap<Tbl_Reserve, ViewModel_Reserve>();
                map.CreateMap<Tbl_Users, ViewModel_Agents>();
            });  // this line Use AutoMapper for map Model to View Model

            services.AddTransient<AccountController>();
            services.AddTransient<CityController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            // this is Multi Language setting
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("fa-IR"),
                new CultureInfo("en-US")
            };
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            };
            app.UseRequestLocalization(options);
            // elmah مربوط به  middleware تعریف میان افزار یا 
            // بایستی زیر authentication قرار بگیره تا موقع check permission  به مشکل نخوریم
            app.UseElmah();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
        /// <summary>
        /// elmah متد مربوط به محدود کردن دسترسی به  
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool CheckPermissionAction(HttpContext httpContext)
        {
            // می باشد؟ elamh کاربری جاری سیستم دارای نقش ادمین برای دسترسی به  
            if (httpContext.User.Identity.IsAuthenticated == true)
            {
                if (httpContext.User.IsInRole("admin"))
                {
                    return true;
                }
            }
            return false;
            // در این قسمت ما تنها برای نمایش آزمایشی میگوییم که دسترسی دارند
            //return true;
        }
    }
}
