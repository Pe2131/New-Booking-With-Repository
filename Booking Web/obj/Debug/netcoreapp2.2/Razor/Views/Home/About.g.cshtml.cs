#pragma checksum "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dc9ade54c611f27929051adbab61c68a71c0e06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
#line 1 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web;

#line default
#line hidden
#line 2 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.Models;

#line default
#line hidden
#line 3 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.ViewModel;

#line default
#line hidden
#line 4 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using Booking_Web.Controllers;

#line default
#line hidden
#line 5 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using DAL.Model.Tables;

#line default
#line hidden
#line 6 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\_ViewImports.cshtml"
using DAL.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dc9ade54c611f27929051adbab61c68a71c0e06", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859d9f985447f725ce1e67f22f294f3091cbff49", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tbl_Setting>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(109, 142, true);
            WriteLiteral("\r\n    <div class=\"page-wrapper zero\">\r\n\r\n        <section>\r\n\r\n            <div class=\"container\">\r\n\r\n                <div class=\"image mb-50\">");
            EndContext();
            BeginContext(251, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dc9ade54c611f27929051adbab61c68a71c0e064429", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 261, "~/Files/Images/", 261, 15, true);
#line 13 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\About.cshtml"
AddHtmlAttributeValue("", 276, Model.AboutImag1, 276, 17, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(307, 246, true);
            WriteLiteral("</div>\r\n\r\n                <div class=\"row gap-30 gap-lg-40\">\r\n\r\n                    <div class=\"col-12 col-lg-8\">\r\n\r\n                        <div class=\"col-inner\">\r\n\r\n                            <h3>About Us</h3>\r\n                            <p>");
            EndContext();
            BeginContext(554, 17, false);
#line 22 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\About.cshtml"
                          Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(571, 221, true);
            WriteLiteral("</p>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                    <div class=\"col-12 col-lg-4\">\r\n\r\n                        <div class=\"col-inner\">\r\n\r\n                            <div class=\"image\">");
            EndContext();
            BeginContext(792, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dc9ade54c611f27929051adbab61c68a71c0e066939", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 802, "~/Files/Images/", 802, 15, true);
#line 31 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\About.cshtml"
AddHtmlAttributeValue("", 817, Model.AboutImag2, 817, 17, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(848, 205, true);
            WriteLiteral("</div>\r\n\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n\r\n                <div class=\"mb-50\"></div>\r\n\r\n            </div>\r\n\r\n        </section>\r\n\r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tbl_Setting> Html { get; private set; }
    }
}
#pragma warning restore 1591
