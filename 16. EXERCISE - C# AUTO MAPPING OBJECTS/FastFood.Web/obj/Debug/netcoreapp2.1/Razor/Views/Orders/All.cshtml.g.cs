#pragma checksum "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49f9e46c98598d42a0463bc13c9bd6a5f7806a2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_All), @"mvc.1.0.view", @"/Views/Orders/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/All.cshtml", typeof(AspNetCore.Views_Orders_All))]
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
#line 1 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\_ViewImports.cshtml"
using FastFood.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49f9e46c98598d42a0463bc13c9bd6a5f7806a2c", @"/Views/Orders/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Orders.OrderAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(64, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
  
    ViewData["Title"] = "All Orders";

#line default
#line hidden
            BeginContext(112, 406, true);
            WriteLiteral(@"<h1 class=""text-center"">All Orders</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">OrderId</th>
            <th class=""col-md-2"">Customer</th>
            <th class=""col-md-2"">Employee</th>
            <th class=""col-md-2"">DateTime</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(574, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(634, 1, false);
#line 22 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
                            Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(635, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(676, 16, false);
#line 23 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
                            Write(Model[i].OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(692, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(733, 17, false);
#line 24 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
                            Write(Model[i].Customer);

#line default
#line hidden
            EndContext();
            BeginContext(750, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(791, 17, false);
#line 25 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
                            Write(Model[i].Employee);

#line default
#line hidden
            EndContext();
            BeginContext(808, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(849, 17, false);
#line 26 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
                            Write(Model[i].DateTime);

#line default
#line hidden
            EndContext();
            BeginContext(866, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 28 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Orders\All.cshtml"
    }

#line default
#line hidden
            BeginContext(895, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Orders.OrderAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
