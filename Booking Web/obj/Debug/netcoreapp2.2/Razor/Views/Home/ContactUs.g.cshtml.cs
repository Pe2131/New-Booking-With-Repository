#pragma checksum "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30810dedc6f6816af78e62fdc8a9d30f67617afa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ContactUs), @"mvc.1.0.view", @"/Views/Home/ContactUs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ContactUs.cshtml", typeof(AspNetCore.Views_Home_ContactUs))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30810dedc6f6816af78e62fdc8a9d30f67617afa", @"/Views/Home/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859d9f985447f725ce1e67f22f294f3091cbff49", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tbl_Setting>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ContactUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
  
    ViewData["Title"] = "ContactUs";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(112, 265, true);
            WriteLiteral(@"<div class=""page-title-02 bg-primary text-center"">
    <div class=""container"">
        <h2>Contact Us</h2>
        <p class=""font-lg"">Drop us your lovely message.</p>
    </div>
</div>
<div class=""page-wrapper bg-light pv-80"">

    <div class=""container"">
");
            EndContext();
#line 15 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
         if (TempData["Success"] != null)
        {

#line default
#line hidden
            BeginContext(431, 239, true);
            WriteLiteral("            <div class=\"success-box\">\r\n\r\n                <div class=\"icon\">\r\n\r\n                    <span><i class=\"ri ri-check-square\"></i></span>\r\n\r\n                </div>\r\n\r\n                <div class=\"content\">\r\n                    <h4>");
            EndContext();
            BeginContext(671, 19, false);
#line 26 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
                   Write(TempData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(690, 51, true);
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 29 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
        }

#line default
#line hidden
            BeginContext(752, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 30 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
         if (TempData["Error"] != null)
        {

#line default
#line hidden
            BeginContext(804, 151, true);
            WriteLiteral("            <div class=\"alert alert-warning pt-10 pb-10 mb-30\" role=\"alert\">\r\n                <i class=\"fas fa-info-circle mr-5\"></i>\r\n                ");
            EndContext();
            BeginContext(956, 19, false);
#line 34 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
           Write(TempData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(975, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 36 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
        }

#line default
#line hidden
            BeginContext(1008, 211, true);
            WriteLiteral("        <div class=\"row gap-40\">\r\n\r\n            <div class=\"col-12 col-lg-8\">\r\n\r\n                <div class=\"section-title\">\r\n                    <h3>Get in Touch</h3>\r\n                </div>\r\n\r\n                ");
            EndContext();
            BeginContext(1219, 3567, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30810dedc6f6816af78e62fdc8a9d30f67617afa8019", async() => {
                BeginContext(1302, 3477, true);
                WriteLiteral(@"

                    <div class=""contact-successful-messages""></div>

                    <div class=""contact-inner"">

                        <div class=""row gap-20 gap-lg-30 mb-20"">
                            <div class=""col-6"">
                                <div class=""form-group mb-0 has-error has-danger"">
                                    <label for=""form_name"">Full name *</label>
                                    <input id=""form_name"" type=""text"" name=""name"" class=""form-control"" placeholder=""Please enter your full name *"" required=""required"" data-error=""Name is required."">
                                    <div class=""help-block with-errors text-danger""><ul class=""list-unstyled""><li>Name is required.</li></ul></div>
                                </div>
                            </div>
                            <div class=""col-6"">
                                <div class=""form-group mb-0 has-error has-danger"">
                                    <label for=""form_email"">E");
                WriteLiteral(@"mail *</label>
                                    <input id=""form_email"" type=""email"" name=""email"" class=""form-control"" placeholder=""Please enter your email *"" required=""required"" data-error=""Valid email is required."">
                                    <div class=""help-block with-errors text-danger""><ul class=""list-unstyled""><li>Valid email is required.</li></ul></div>
                                </div>
                            </div>
                            <div class=""col-6"">
                                <div class=""form-group mb-0"">
                                    <label for=""form_phone"">Phone</label>
                                    <input id=""form_phone"" type=""tel"" name=""Phone"" class=""form-control"" placeholder=""Please enter your phone"">
                                    <div class=""help-block with-errors text-danger""></div>
                                </div>
                            </div>
                            <div class=""col-6"">
                      ");
                WriteLiteral(@"          <div class=""form-group mb-0 has-error has-danger"">
                                    <label for=""form_subject"">Subject *</label>
                                    <input id=""form_subject"" type=""text"" name=""Subject"" class=""form-control"" placeholder=""Subject is required *"" required=""required"" data-error=""Subject is required."">
                                    <div class=""help-block with-errors text-danger""><ul class=""list-unstyled""><li>Subject is required.</li></ul></div>
                                </div>
                            </div>
                            <div class=""col-12"">
                                <div class=""form-group mb-0"">
                                    <label for=""form_message"">Message *</label>
                                    <textarea id=""form_message"" name=""text"" class=""form-control"" placeholder=""Message for me *"" rows=""6"" required=""required"" data-error=""Please,leave us a message.""></textarea>
                                    <div class=""");
                WriteLiteral(@"help-block with-errors text-danger""></div>
                                </div>
                            </div>
                            <div class=""col-12"">
                                <button type=""submit"" class=""btn btn-primary btn-send disabled"">Send message</button>
                            </div>
                        </div>

                    </div>

                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4786, 486, true);
            WriteLiteral(@"

            </div>

            <div class=""col-12 col-lg-4"">

                <div class=""section-title"">
                    <h3>Contact Details</h3>
                </div>

                <ul class=""contact-list"">

                    <li class=""clearfix"">
                        <div class=""icon-font""><i class=""bx bx-map-pin""></i></div>
                        <div class=""content"">
                            <h6>Location:</h6>
                            <p>");
            EndContext();
            BeginContext(5273, 13, false);
#line 110 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
                          Write(Model.Address);

#line default
#line hidden
            EndContext();
            BeginContext(5286, 325, true);
            WriteLiteral(@"</p>
                        </div>
                    </li>

                    <li class=""clearfix"">
                        <div class=""icon-font""><i class=""bx bx-phone-call""></i></div>
                        <div class=""content"">
                            <h6>Line Phone:</h6>
                            <p>");
            EndContext();
            BeginContext(5612, 11, false);
#line 118 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
                          Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(5623, 332, true);
            WriteLiteral(@"</p>
                        </div>
                    </li>


                    <li class=""clearfix"">
                        <div class=""icon-font""><i class=""bx bx-envelope""></i></div>
                        <div class=""content"">
                            <h6>Email:</h6>
                            <p><a href=""#"">");
            EndContext();
            BeginContext(5956, 11, false);
#line 127 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Home\ContactUs.cshtml"
                                      Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(5967, 162, true);
            WriteLiteral("</a></p>\r\n                        </div>\r\n\r\n                    </li>\r\n\r\n                </ul>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
