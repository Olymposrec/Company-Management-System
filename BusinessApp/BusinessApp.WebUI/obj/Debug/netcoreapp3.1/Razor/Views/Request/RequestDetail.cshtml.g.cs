#pragma checksum "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "590f368e543c184681eaaf11cc2fbf08219bae2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_RequestDetail), @"mvc.1.0.view", @"/Views/Request/RequestDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"590f368e543c184681eaaf11cc2fbf08219bae2f", @"/Views/Request/RequestDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83bac7183d4a43b242342d727cbfeb2b0a0c6454", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_RequestDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btn-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control input-sm chat_input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Write your message here..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Request", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RequestDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card mb-2 mt-2\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 62, "\"", 260, 3);
            WriteAttributeValue("", 70, "card-header", 70, 11, true);
            WriteAttributeValue(" ", 81, "bg-", 82, 4, true);
#nullable restore
#line 4 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
WriteAttributeValue("", 85, Model.Request.RequestStatus==Request.EnumRequestStatus.Waiting ? "info":
                Model.Request.RequestStatus==Request.EnumRequestStatus.Closed ? "danger":"warning", 85, 175, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 6 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
   Write(Model.Request.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -\r\n        <span><small>Request ");
#nullable restore
#line 7 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                        Write(Model.Request.RequestStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></span>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <p>");
#nullable restore
#line 10 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
      Write(Html.Raw(Model.Request.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "590f368e543c184681eaaf11cc2fbf08219bae2f9762", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"card mb-2 mt-2\">\r\n        <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 638, "\"", 660, 1);
#nullable restore
#line 17 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
WriteAttributeValue("", 646, Model.User.Id, 646, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"requestId\"");
                BeginWriteAttribute("value", " value=\"", 711, "\"", 736, 1);
#nullable restore
#line 18 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
WriteAttributeValue("", 719, Model.Request.Id, 719, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <div");
                BeginWriteAttribute("class", " class=\"", 754, "\"", 952, 3);
                WriteAttributeValue("", 762, "card-header", 762, 11, true);
                WriteAttributeValue(" ", 773, "bg-", 774, 4, true);
#nullable restore
#line 19 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
WriteAttributeValue("", 777, Model.Request.RequestStatus==Request.EnumRequestStatus.Waiting ? "info":
                Model.Request.RequestStatus==Request.EnumRequestStatus.Closed ? "danger":"warning", 777, 175, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            <i class=\"fas fa-comment\"></i>\r\n            ");
#nullable restore
#line 22 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
       Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"card-body overflow-auto\" style=\"background-color:whitesmoke; height:450px\">\r\n\r\n");
#nullable restore
#line 27 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
             if (Model.RequestResponses != null)
            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                 foreach (var response in Model.RequestResponses)
                {


                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                     if (Model.Request.Id == response.RequestId)
                    {


                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                         if (response.ResponseType == RequestResponse.EnumResponseType.Receiver)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""row text-right  justify-content-end mt-3"">
                                <div class=""col-sm-6 col-xs-6 rounded shadow ml-auto"">
                                    <div class=""p-2 messages msg_receive"">
                                        <p class=""card-text"">
                                            ");
#nullable restore
#line 44 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                       Write(Html.Raw(response.Response));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </p>\r\n                                        <time class=\"text-muted text-left\"> ");
#nullable restore
#line 46 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                                                        Write(response.ResponseDate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</time>
                                    </div>
                                </div>
                                <div class=""col-sm-1 col-xs-1"">
                                    <img src=""/img/avatar2.png"" class=""img-responsive rounded-circle"" width=""50"" height=""50"">
                                </div>
                            </div>
");
#nullable restore
#line 53 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                        }
                        else if (response.ResponseType == RequestResponse.EnumResponseType.Sender)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""row text-left mt-3  justify-content-start mb-2"">
                                <div class=""col-sm-1 col-xs-1 avatar"">
                                    <img src=""/img/avatar.png"" class=""img-responsive rounded-circle"" width=""50"" height=""50"">
                                </div>
                                <div class=""col-sm-6 col-xs-6 rounded shadow mr-auto"" style=""background-color: #d9c8c0"">
                                    <div class=""p-2 messages msg_sent"">
                                        <p class=""card-text"">
                                            ");
#nullable restore
#line 63 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                       Write(Html.Raw(response.Response));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </p>\r\n                                        <time class=\"text-muted text-left\"> ");
#nullable restore
#line 65 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                                                        Write(response.ResponseDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</time>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 69 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <div class=\"card-footer\">\r\n            <div");
                BeginWriteAttribute("class", " class=\"", 3660, "\"", 3762, 2);
                WriteAttributeValue("", 3668, "input-group", 3668, 11, true);
#nullable restore
#line 76 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
WriteAttributeValue(" ", 3679, Model.Request.RequestStatus == Request.EnumRequestStatus.Closed ? "disabled":"", 3680, 82, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "590f368e543c184681eaaf11cc2fbf08219bae2f18112", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 77 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RequestResponse.Response);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <span class=\"input-group-btn\">\r\n                    <button type=\"submit\" ");
#nullable restore
#line 79 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                      Write(Model.Request.RequestStatus == Request.EnumRequestStatus.Closed ? "disabled" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" name=\"sendResponse\" value=\"sendResponse\" class=\"btn btn-primary btn\" id=\"btn-chat\"><i class=\"fas fa-paper-plane\"></i></button>\r\n                </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<div class=""card  shadow mt-3 mb-3"">
    <div class=""card-header bg-dark"">
        Files
    </div>
    <div class=""card-body"">
        <div class=""row table-responsive-sm"">
            <div class=""col-md-12 "">
                <table id=""dataTable"" class=""table table-bordered mt-3 w-100"">
                    <thead>
                        <tr>
                            <td>#</td>
                            <td style=""width:500px;"">File Name</td>
                            <td style=""width:500px;"">File Extension</td>
                            <td style=""width:min-content;"">Download Link</td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 104 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                         if (Model.FilesDownload.Count() > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                             foreach (var file in Model.FilesDownload)
                            {
                                if (Model.Request.Id == file.RequestId)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td >");
#nullable restore
#line 111 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                        Write(file.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td >");
#nullable restore
#line 112 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                        Write(file.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td >");
#nullable restore
#line 113 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                        Write(file.FileExtension);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td >\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "590f368e543c184681eaaf11cc2fbf08219bae2f24881", async() => {
                WriteLiteral("\r\n                                                <button type=\"button\" class=\"btn btn-primary\">Download</button>\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5675, "~/files/", 5675, 8, true);
#nullable restore
#line 115 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
AddHtmlAttributeValue("", 5683, file.FileName, 5683, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("download", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 120 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"alert alert-warning\">\r\n                                <h3>No File</h3>\r\n                            </div>\r\n");
#nullable restore
#line 128 "C:\Users\dell\source\repos\BusinessApp\BusinessApp.WebUI\Views\Request\RequestDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
