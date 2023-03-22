#pragma checksum "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b98792631ea5e9e53732beacbdebfc8adf5cebb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TroubleTickets.Pages.Admin.Pages_Admin_ControlPanel), @"mvc.1.0.razor-page", @"/Pages/Admin/ControlPanel.cshtml")]
namespace TroubleTickets.Pages.Admin
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
#line 1 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\_ViewImports.cshtml"
using TroubleTickets;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b98792631ea5e9e53732beacbdebfc8adf5cebb9", @"/Pages/Admin/ControlPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eda8fc696e2ff0a5a616a716bfeea8c697732aee", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Admin_ControlPanel : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Admin/EditTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Admin/DeleteTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
  
    ViewData["Title"] = "ControlPanel";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Control Panel</h1>

<div>

    <table class=""table table-bordered table-sm table-striped"">

        <thead>

            <tr>

                <th>ID</th>
                <th>Ticket Title</th>
                <th>Category</th>
                <th>Submitted</th>
                <th>Reported On</th>
                <th>Active</th>
                <th>DOTS</th>
                <th>Response</th>

            </tr>

        </thead>

        <tbody>

");
#nullable restore
#line 32 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
             if (Model == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"7\" class=\"text-center\">No Model</td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
            }

            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                 foreach (var p in Model.tix)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 44 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Ticket_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 45 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Ticket_Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 46 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Reporting_Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Orig_Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 50 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                          
                            if (p.Active == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Active</td>\r\n");
#nullable restore
#line 54 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Closed</td>\r\n");
#nullable restore
#line 58 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                            }
                         

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <td>");
#nullable restore
#line 61 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                       Write(p.Responder_Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"width:100%;\">");
#nullable restore
#line 62 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                                           Write(p.Responder_Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
            WriteLiteral("                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b98792631ea5e9e53732beacbdebfc8adf5cebb97964", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                                                              WriteLiteral(p.Ticket_ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b98792631ea5e9e53732beacbdebfc8adf5cebb910161", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                                                                WriteLiteral(p.Ticket_ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 70 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\Q4\Asp.Net\Week 9\TroubleTickets\Pages\Admin\ControlPanel.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n\r\n\r\n\r\n\r\n    </table> \r\n\r\n\r\n\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TroubleTickets.Pages.Admin.ControlPanelModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TroubleTickets.Pages.Admin.ControlPanelModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TroubleTickets.Pages.Admin.ControlPanelModel>)PageContext?.ViewData;
        public TroubleTickets.Pages.Admin.ControlPanelModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
