#pragma checksum "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39e4c04e358a2b8ba91054f9bebdc6be72507a37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Index), @"mvc.1.0.view", @"/Views/Report/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Report/Index.cshtml", typeof(AspNetCore.Views_Report_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39e4c04e358a2b8ba91054f9bebdc6be72507a37", @"/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a72621c7038edef7c99fec268d0495bc0c20dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Report\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(95, 1284, true);
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""block-header"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <ul class=""breadcrumb breadcrumb-style "">
                    <li class=""breadcrumb-item"">
                        <h4 class=""page-title"">Finance</h4>
                    </li>
                    <li class=""breadcrumb-item bcrumb-1"">
                        <a href=""/Report"">
                            <i class=""fas fa-home""></i> Finance
                        </a>
                    </li>
                    <li class=""breadcrumb-item bcrumb-2"">
                        <a href=""javascript:void(0);"">Report</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class=""card"" style=""min-height:450px;"">
        <i class=""fas fa-lock col-dark-gray"" style=""position:relative;text-align:center;margin-top:2%; font-size:185px""></i>
        <h1 style=""position:relative;text-alig");
            WriteLiteral(@"n:center;margin-top:5%;color:darkgray;"">Your Payment Gatway Does Not Active .</h1>
        <h4 style=""position:relative;text-align:center;margin-top:5%;color:darkgray;"">Please Contact Support.</h4>
    </div>
    <!-- Your content goes here  -->
</div>

");
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
