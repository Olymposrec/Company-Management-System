#pragma checksum "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "844d02e1f383006b84a0df923178f7ee40dc7115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_RequestHistory), @"mvc.1.0.view", @"/Views/Request/RequestHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"844d02e1f383006b84a0df923178f7ee40dc7115", @"/Views/Request/RequestHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83bac7183d4a43b242342d727cbfeb2b0a0c6454", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_RequestHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestsListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <link href=""https://cdn.datatables.net/1.11.4/css/dataTables.bootstrap4.min.css"" rel=""stylesheet"" />
<style>
    .table {
        table-layout: fixed;
    }
        .table td {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
</style>
    
");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""//cdn.datatables.net/1.11.4/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.11.4/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#UserTable').DataTable();
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "844d02e1f383006b84a0df923178f7ee40dc71156586", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div class=""card shadow mt-5"">
    <div class=""card-header bg-dark"">
        Users Application List
    </div>
    <div class=""card-body table-responsive-sm"">
        <table id=""UserTable"" class=""table table-bordered table-striped mt-3"">
            <thead>
                <tr>
                    <td style=""width:250px;"">Service Name</td>
                    <td style=""width:300px;"">Title</td>
                    <td style=""width:250px;"">Request Date</td>
                    <td style=""width:150px;"">Request Status</td>
                    <td style=""width:min-content;"">Options</td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 43 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                 if (Model.Requests.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                     foreach (var request in Model.Requests)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                         if (request.UserId == Model.User.Id && request.isDeleted == false)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                             foreach (var service in Model.Services)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                 foreach (var companyService in Model.CompaniesServices)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                     if (companyService.ServiceId == service.Id)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                         if (request.CompaniesServiceId == companyService.Id)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr");
            BeginWriteAttribute("class", " class=\"", 2196, "\"", 2503, 1);
#nullable restore
#line 57 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
WriteAttributeValue("", 2204, request.RequestStatus==Request.EnumRequestStatus.Waiting ? "bg-info":
                                       request.RequestStatus==Request.EnumRequestStatus.Accepted ? "bg-success":
                                       request.RequestStatus==Request.EnumRequestStatus.Closed ? "bg-danger":"", 2204, 299, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <td>");
#nullable restore
#line 60 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                               Write(service.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td><div style=\"line-height: 50px; max-height:50px; overflow: hidden\">");
#nullable restore
#line 61 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                                                                                                 Write(Html.Raw(request.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div> </td>\r\n                                                <td>");
#nullable restore
#line 62 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                               Write(request.RequestDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 63 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                               Write(request.RequestStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 3010, "\"", 3051, 2);
            WriteAttributeValue("", 3017, "/Request/RequestDetail/", 3017, 23, true);
#nullable restore
#line 65 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
WriteAttributeValue("", 3040, request.Id, 3040, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\"><i class=\"fas fa-edit\"></i></a>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 68 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                     


                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-warning\">\r\n                        <h3>No Applications</h3>\r\n                    </div>\r\n");
#nullable restore
#line 82 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestHistory.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestsListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
