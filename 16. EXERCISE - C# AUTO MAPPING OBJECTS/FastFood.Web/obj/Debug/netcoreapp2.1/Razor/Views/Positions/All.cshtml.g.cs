#pragma checksum "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebf987a03512158a4e3f6411afe39794ff3eecc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Positions_All), @"mvc.1.0.view", @"/Views/Positions/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Positions/All.cshtml", typeof(AspNetCore.Views_Positions_All))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebf987a03512158a4e3f6411afe39794ff3eecc7", @"/Views/Positions/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Positions_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Positions.PositionsAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml"
  
    ViewData["Title"] = "All Positions";

#line default
#line hidden
            BeginContext(122, 267, true);
            WriteLiteral(@"<h1 class=""text-center"">All Positions</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">Positions</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 16 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(445, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(506, 3, false);
#line 19 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml"
                             Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(510, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(551, 13, false);
#line 20 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml"
                            Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(564, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 22 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Positions\All.cshtml"
    }

#line default
#line hidden
            BeginContext(593, 22, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Positions.PositionsAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
