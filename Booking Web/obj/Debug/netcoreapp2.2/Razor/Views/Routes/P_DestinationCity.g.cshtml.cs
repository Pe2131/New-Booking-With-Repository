#pragma checksum "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe6c2afcd3b731f9a5f71daf33e0d4e7a5735635"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Routes_P_DestinationCity), @"mvc.1.0.view", @"/Views/Routes/P_DestinationCity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Routes/P_DestinationCity.cshtml", typeof(AspNetCore.Views_Routes_P_DestinationCity))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe6c2afcd3b731f9a5f71daf33e0d4e7a5735635", @"/Views/Routes/P_DestinationCity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a72621c7038edef7c99fec268d0495bc0c20dad", @"/Views/_ViewImports.cshtml")]
    public class Views_Routes_P_DestinationCity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ViewModel_City>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
 if (Model.Any())
{
    

#line default
#line hidden
#line 4 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(92, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(100, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe6c2afcd3b731f9a5f71daf33e0d4e7a57356354544", async() => {
                BeginContext(126, 9, false);
#line 6 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
                            Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 6 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(144, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
    }

#line default
#line hidden
#line 7 "E:\c#project\asp\Work\BookingNew\BookingNew With Repository\Booking Web\Views\Routes\P_DestinationCity.cshtml"
     
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ViewModel_City>> Html { get; private set; }
    }
}
#pragma warning restore 1591
