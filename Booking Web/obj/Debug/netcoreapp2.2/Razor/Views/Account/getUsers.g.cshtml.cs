#pragma checksum "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_getUsers), @"mvc.1.0.view", @"/Views/Account/getUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/getUsers.cshtml", typeof(AspNetCore.Views_Account_getUsers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa", @"/Views/Account/getUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859d9f985447f725ce1e67f22f294f3091cbff49", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_getUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ViewModel_User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:50px;height:50px; border-radius:50%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Files/Images/Users/User.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/table.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/tables/jquery-datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/form.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
  
    ViewData["Title"] = "getUsers";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(125, 1027, true);
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""block-header"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <ul class=""breadcrumb breadcrumb-style "">
                    <li class=""breadcrumb-item"">
                        <h4 class=""page-title"">Users</h4>
                    </li>
                    <li class=""breadcrumb-item bcrumb-1"">
                        <a href=""/Account/index"">
                            <i class=""fas fa-home""></i> Users
                        </a>
                    </li>
                    <li class=""breadcrumb-item bcrumb-2"">
                        <a href=""javascript:void(0);"">Manage Users</a>
                    </li>
                </ul>
            </div>
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <div class=""row clearfix js-sweetalert"">
                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                        <div class=""card""");
            WriteLiteral(">\r\n");
            EndContext();
#line 28 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                             if (TempData["Style"] != null)
                            {

#line default
#line hidden
            BeginContext(1244, 36, true);
            WriteLiteral("                                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1280, "\"", 1306, 1);
#line 30 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
WriteAttributeValue("", 1288, TempData["Style"], 1288, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1307, 39, true);
            WriteLiteral(">\r\n                                    ");
            EndContext();
            BeginContext(1347, 19, false);
#line 31 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                               Write(TempData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(1366, 42, true);
            WriteLiteral("\r\n                                </div>\r\n");
            EndContext();
#line 33 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                            }

#line default
#line hidden
            BeginContext(1439, 1027, true);
            WriteLiteral(@"                            <div class=""header"">
                                <h2 class=""co-md-6 col-lg-6"">
                                    <strong>Users List</strong>
                                </h2>
                            </div>
                            <div class=""body table-responsive"">
                                <table class=""table table-bordered table-striped table-hover js-basic-example dataTable"" id=""TblUsers"" style=""text-align:center;"">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>FullName</th>
                                            <th>Email</th>
                                            <th>Mobile</th>
                                            <th>Image</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead");
            WriteLiteral(">\r\n");
            EndContext();
#line 51 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                     if (Model.Any())
                                    {
                                        int count = 1;


#line default
#line hidden
            BeginContext(2618, 51, true);
            WriteLiteral("                                        <tbody>\r\n\r\n");
            EndContext();
#line 57 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
            BeginContext(2790, 51, true);
            WriteLiteral("                                                <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2841, "\"", 2856, 2);
#line 59 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
WriteAttributeValue("", 2846, item.Id, 2846, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 2854, "-R", 2854, 2, true);
            EndWriteAttribute();
            BeginContext(2857, 98, true);
            WriteLiteral(" style=\"text-align:center;\">\r\n                                                    <th scope=\"row\">");
            EndContext();
            BeginContext(2957, 7, false);
#line 60 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                                Write(count++);

#line default
#line hidden
            EndContext();
            BeginContext(2965, 63, true);
            WriteLiteral("</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(3029, 13, false);
#line 61 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                   Write(item.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(3042, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(3106, 10, false);
#line 62 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                   Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(3116, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(3180, 11, false);
#line 63 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                   Write(item.Mobile);

#line default
#line hidden
            EndContext();
            BeginContext(3191, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 64 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                     if (item.image != null)
                                                    {

#line default
#line hidden
            BeginContext(3331, 149, true);
            WriteLiteral("                                                        <td style=\"text-align:center;\">\r\n                                                            ");
            EndContext();
            BeginContext(3480, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa12978", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3541, "~/Files/Images/Users/", 3541, 21, true);
#line 67 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
AddHtmlAttributeValue("", 3562, item.image, 3562, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3577, 65, true);
            WriteLiteral("\r\n                                                        </td>\r\n");
            EndContext();
#line 69 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
            BeginContext(3810, 149, true);
            WriteLiteral("                                                        <td style=\"text-align:center;\">\r\n                                                            ");
            EndContext();
            BeginContext(3959, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa15258", async() => {
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
            BeginContext(4053, 65, true);
            WriteLiteral("\r\n                                                        </td>\r\n");
            EndContext();
#line 75 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                                    }

#line default
#line hidden
            BeginContext(4173, 144, true);
            WriteLiteral("                                                    <td>\r\n                                                        <button class=\"btn tblActnBtn\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\'", 4317, "\'", 4349, 3);
            WriteAttributeValue("", 4327, "GetDetails(\"", 4327, 12, true);
#line 77 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
WriteAttributeValue("", 4339, item.Id, 4339, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4347, "\")", 4347, 2, true);
            EndWriteAttribute();
            BeginContext(4350, 241, true);
            WriteLiteral(">\r\n                                                            <i class=\"material-icons\">account_circle</i>\r\n                                                        </button>\r\n\r\n                                                        <button");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4591, "\"", 4604, 1);
#line 81 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
WriteAttributeValue("", 4596, item.Id, 4596, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4605, 23, true);
            WriteLiteral(" class=\"btn tblActnBtn\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\'", 4628, "\'", 4658, 3);
            WriteAttributeValue("", 4638, "showrole(\"", 4638, 10, true);
#line 81 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
WriteAttributeValue("", 4648, item.Id, 4648, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4656, "\")", 4656, 2, true);
            EndWriteAttribute();
            BeginContext(4659, 285, true);
            WriteLiteral(@">
                                                            <i class=""material-icons"">vpn_key</i>
                                                        </button>
                                                    </td>

                                                </tr>
");
            EndContext();
#line 87 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                            }

#line default
#line hidden
            BeginContext(4991, 52, true);
            WriteLiteral("\r\n                                        </tbody>\r\n");
            EndContext();
#line 90 "E:\c#project\asp\Work\BookingNew\Booking Web\Views\Account\getUsers.cshtml"
                                    }

#line default
#line hidden
            BeginContext(5082, 2775, true);
            WriteLiteral(@"
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Your content goes here  -->
            </div>
        </div>
    </div>
</div>
<!--start Info Modal-->
<div class=""modal fade"" id=""gridModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalGrid""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalGrid"">User Information</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""Information"">

            </div>
            <div class=""modal-footer"">
                <!-- <button type=""button"" class=""btn btn-info waves-ef");
            WriteLiteral(@"fect"">Save</button>-->
                <button type=""button"" class=""btn btn-danger waves-effect""
                        data-dismiss=""modal"">
                    close
                </button>
            </div>
        </div>
    </div>
</div>
<!--start Role Modal-->
<div class=""modal fade"" id=""RoleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalGrid""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalGrid"">User Roles</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""Role"">
            </div>
            <div class=""modal-footer"">
                <div class=""preloader"" id=""loading"" style=""display:none;"">
                    <div");
            WriteLiteral(@" class=""spinner-layer pl-cyan"">
                        <div class=""circle-clipper left"">
                            <div class=""circle""></div>
                        </div>
                        <div class=""circle-clipper right"">
                            <div class=""circle""></div>
                        </div>
                    </div>
                </div>
                <button type=""button"" class=""btn btn-info waves-effect"" onclick='addOrRemove()'>Save</button>
                <button type=""button"" class=""btn btn-danger waves-effect""
                        data-dismiss=""modal"">
                    close
                </button>
            </div>
            </div>
    </div>
</div>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7874, 9, true);
                WriteLiteral("\r\n       ");
                EndContext();
                BeginContext(7883, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa22734", async() => {
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
                BeginContext(7931, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7937, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa23990", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(8005, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(8011, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8afa89784e26d0438eb5a7cd2e6ec565e0dcbfa25246", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(8058, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(8063, 1642, true);
            WriteLiteral(@"<script>
    function GetDetails(id) {

        $.ajax({
            url: ""/Account/GetUserDetail/"" + id,
            type: ""Get"",
            AllowCache: false
        }).done(function (res) {
            $(""#Information"").empty();
            $(""#Information"").append(res);
            $(""#gridModal"").modal('show');
        });
    }
    function showrole(id) {
        //$(""#RoleModal"").modal('show');
     
         $.ajax({
             url: ""/Account/GetUserRoles/"" + id,
             type: ""Get"",
             AllowCache: false
         }).done(function (res) {
             $(""#Role"").empty();
             $(""#Role"").append(res);
             $(""#RoleModal"").modal('show');
         });
    }
    function addOrRemove()
    {
        var id = $('#userId').val();
        var roles = $('#roles').val();
        if (roles == null)
        {
            swal(""Error!"", ""roles Must has value"", ""error"");
            return false;
        }
        $('#loading').show();
        $.aj");
            WriteLiteral(@"ax({
            url: ""/Account/addOrRemoveRoles"",
            type: ""Post"",
            data: { id: id, roles: roles },
            AllowCache: false
        }).done(function (res) {
            if (res == 1)
            {
                $('#loading').hide();
                swal(""Updated!"", ""this record has been Updated."", ""success"");
                //$(""#RoleModal"").modal('hide');
                //showrole(id);
            }
            else {
                $('#loading').hide();
                swal(""Error!"", ""there are a problem"", ""error"");
            }
        });
    }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ViewModel_User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
