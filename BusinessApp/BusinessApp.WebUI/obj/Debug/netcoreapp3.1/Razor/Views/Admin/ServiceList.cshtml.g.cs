#pragma checksum "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43d38812d5fc76466422c7eb8f0e10108e9c2bb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ServiceList), @"mvc.1.0.view", @"/Views/Admin/ServiceList.cshtml")]
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
#nullable restore
#line 1 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.RequestsModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.ServiceModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.LogsViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.UsersModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.DepartmentsModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.AccountModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models.CompanyModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using BusinessApp.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43d38812d5fc76466422c7eb8f0e10108e9c2bb3", @"/Views/Admin/ServiceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83bac7183d4a43b242342d727cbfeb2b0a0c6454", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ServiceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/ServiceDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral(@"<div id=""accordion"">
    <div class=""card  shadow mt-5"">
        <div class=""card-header bg-dark"">
            <a href=""#collapseServicelist"" class=""card-link p-1"" data-toggle=""collapse"">
                Service List
            </a>
        </div>
        <div id=""collapseServicelist"" class=""collapse show"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-12 table-responsive-sm"">
                        <table id=""dataTable"" class=""table table-bordered mt-3 w-100"">
                            <thead>
                                <tr>
                                    <td>#</td>
                                    <td style=""width:500px;"">Service Name</td>
                                    <td style=""width:500px;"">Service Description</td>
                                    <td style=""width:max-content;"">Options</td>
                                </tr>
                            </thead>
                            <tbod");
            WriteLiteral("y>\r\n");
#nullable restore
#line 23 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                 if (Model.Services.Count() > 0)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                     foreach (var service in Model.Services)
                                    {
                                        if (service.isDeleted == false)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td style=\"width:20px;\">");
#nullable restore
#line 30 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                                                   Write(service.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td style=\"width:150px;\">");
#nullable restore
#line 31 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                                                    Write(service.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td style=\"width:150px;\">");
#nullable restore
#line 32 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                                                    Write(service.ServiceDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td style=\"width:20px;\">\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 1858, "\"", 1892, 2);
            WriteAttributeValue("", 1865, "/Admin/Services/", 1865, 16, true);
#nullable restore
#line 34 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
WriteAttributeValue("", 1881, service.Id, 1881, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\"><i class=\"fas fa-edit\"></i></a>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43d38812d5fc76466422c7eb8f0e10108e9c2bb310270", async() => {
                WriteLiteral("\r\n                                                        <input type=\"hidden\" name=\"ServiceName\"");
                BeginWriteAttribute("value", " value=\"", 2174, "\"", 2202, 1);
#nullable restore
#line 36 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
WriteAttributeValue("", 2182, service.ServiceName, 2182, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                        <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 2294, "\"", 2313, 1);
#nullable restore
#line 37 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
WriteAttributeValue("", 2302, service.Id, 2302, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                        <button type=\"submit\" class=\"btn btn-danger btn-sm\"><i class=\"far fa-trash-alt\"></i></button>\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                        }

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                     
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"alert alert-warning\">\r\n                                        <h3>No Service</h3>\r\n                                    </div>\r\n");
#nullable restore
#line 51 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Admin\ServiceList.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
