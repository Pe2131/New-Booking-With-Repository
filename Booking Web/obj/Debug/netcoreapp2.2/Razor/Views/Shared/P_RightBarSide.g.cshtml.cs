#pragma checksum "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Shared\P_RightBarSide.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cf91368ca8263658eb989f483e5fd109fe6061e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_P_RightBarSide), @"mvc.1.0.view", @"/Views/Shared/P_RightBarSide.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/P_RightBarSide.cshtml", typeof(AspNetCore.Views_Shared_P_RightBarSide))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web;

#line default
#line hidden
#line 2 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.Models;

#line default
#line hidden
#line 3 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.ViewModel;

#line default
#line hidden
#line 4 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.Controllers;

#line default
#line hidden
#line 5 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using DAL.Model.Tables;

#line default
#line hidden
#line 6 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using DAL.Model;

#line default
#line hidden
#line 7 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cf91368ca8263658eb989f483e5fd109fe6061e", @"/Views/Shared/P_RightBarSide.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a72621c7038edef7c99fec268d0495bc0c20dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_P_RightBarSide : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 386, true);
            WriteLiteral(@"<aside id=""rightsidebar"" class=""right-sidebar"">
    <ul class=""nav nav-tabs tab-nav-right"" role=""tablist"">
        <li role=""presentation"">
            <a href=""#skins"" data-toggle=""tab"" class=""active"">SKINS</a>
        </li>
        <li role=""presentation"">
            <a href=""#settings"" data-toggle=""tab"">SETTINGS</a>
        </li>
    </ul>
    <div class=""tab-content"">
");
            EndContext();
            BeginContext(6901, 2883, true);
            WriteLiteral(@"        <div role=""tabpanel"" class=""tab-pane stretchRight"" id=""settings"">
            <div class=""demo-settings"">
                <p>GENERAL SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
                        <span>Report Panel Usage</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"" checked>
                                <span class=""lever switch-col-green""></span>
                            </label>
                        </div>
                    </li>
                    <li>
                        <span>Email Redirect</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"">
                                <span class=""lever switch-col-blue""></span>
                            </label>
                        </div>
                    </li>
                </ul>
  ");
            WriteLiteral(@"              <p>SYSTEM SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
                        <span>Notifications</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"" checked>
                                <span class=""lever switch-col-purple""></span>
                            </label>
                        </div>
                    </li>
                    <li>
                        <span>Auto Updates</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"" checked>
                                <span class=""lever switch-col-cyan""></span>
                            </label>
                        </div>
                    </li>
                </ul>
                <p>ACCOUNT SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
         ");
            WriteLiteral(@"               <span>Offline</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"" checked>
                                <span class=""lever switch-col-red""></span>
                            </label>
                        </div>
                    </li>
                    <li>
                        <span>Location Permission</span>
                        <div class=""switch"">
                            <label>
                                <input type=""checkbox"">
                                <span class=""lever switch-col-lime""></span>
                            </label>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</aside>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
