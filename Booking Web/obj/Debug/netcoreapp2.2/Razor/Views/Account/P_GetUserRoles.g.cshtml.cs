#pragma checksum "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d91bcdde298b2afdcd6f348c88bdfe8b7e6ecb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_P_GetUserRoles), @"mvc.1.0.view", @"/Views/Account/P_GetUserRoles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/P_GetUserRoles.cshtml", typeof(AspNetCore.Views_Account_P_GetUserRoles))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d91bcdde298b2afdcd6f348c88bdfe8b7e6ecb2", @"/Views/Account/P_GetUserRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a72621c7038edef7c99fec268d0495bc0c20dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_P_GetUserRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel_User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/form.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/form.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(23, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0d91bcdde298b2afdcd6f348c88bdfe8b7e6ecb25143", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(79, 34, true);
            WriteLiteral("\r\n<input id=\"userId\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 113, "\"", 130, 1);
#line 3 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
WriteAttributeValue("", 121, Model.Id, 121, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(131, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 4 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
 if (ViewBag.ExictRoles != null)
{

#line default
#line hidden
            BeginContext(173, 79, true);
            WriteLiteral("    <h6>Available Roles that you can set for user</h6>\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 8 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
         foreach (var item in ViewBag.ExictRoles)
        {

#line default
#line hidden
            BeginContext(314, 54, true);
            WriteLiteral("            <span class=\"label bg-light-green m-b-10\">");
            EndContext();
            BeginContext(369, 4, false);
#line 10 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
                                                 Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(373, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 11 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
        }

#line default
#line hidden
            BeginContext(393, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 14 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
}

#line default
#line hidden
            BeginContext(410, 354, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
        <div class=""card"">
            <div class=""body"">
                <div class=""form-group demo-tagsinput-area"">
                    <div class=""form-line"">
                        <input type=""text"" class=""form-control"" name=""roles"" id=""roles"" data-role=""tagsinput""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 764, "\"", 791, 1);
#line 21 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Account\P_GetUserRoles.cshtml"
WriteAttributeValue("", 772, ViewBag.UsersRoles, 772, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(792, 111, true);
            WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(903, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d91bcdde298b2afdcd6f348c88bdfe8b7e6ecb29451", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModel_User> Html { get; private set; }
    }
}
#pragma warning restore 1591
