#pragma checksum "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18d97f1f1f6e860cfc224c2a4eac207b175e5f8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
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
#line 1 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\_ViewImports.cshtml"
using TuristickaAgencijaAdminApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\_ViewImports.cshtml"
using TuristickaAgencijaAdminApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18d97f1f1f6e860cfc224c2a4eac207b175e5f8a", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c990e4733520ec4aa2da9f5d9b591a9feb61056d", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TuristickaAgencijaAdminApplication.Models.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <p>\r\n        <a class=\"btn btn-success\">");
#nullable restore
#line 12 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                              Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </p>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
     for (int i = 0; i < Model.OrderedLines.Count(); i++)
    {
        var item = Model.OrderedLines.ElementAt(i).LineInOrder;

        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 22 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3 m-4\">\r\n                <div class=\"card\" style=\"width: 18rem; height: 30rem;\">\r\n                   <div class=\"card-body\">\r\n                        <h3>");
#nullable restore
#line 27 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                       Write(item.LinePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <h3>");
#nullable restore
#line 28 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                       Write(item.StartingDestination.DestinationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <h3>");
#nullable restore
#line 29 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                       Write(item.FinalDestination.DestinationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p>");
#nullable restore
#line 30 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                      Write(item.Company.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n\r\n                </div>\r\n            </div> ");
#nullable restore
#line 34 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
                   if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 37 "C:\Users\stoja\source\repos\TuristickaAgencijaAdminApplication\TuristickaAgencijaAdminApplication\Views\Order\Details.cshtml"
        }

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TuristickaAgencijaAdminApplication.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591