#pragma checksum "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47e5b23912f08ceb736966783c9abfb066143209"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_All), @"mvc.1.0.view", @"/Views/Employees/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employees/All.cshtml", typeof(AspNetCore.Views_Employees_All))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47e5b23912f08ceb736966783c9abfb066143209", @"/Views/Employees/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Employees.EmployeesAllViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Employees", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
  
    ViewData["Title"] = "All Employees";

#line default
#line hidden
            BeginContext(122, 400, true);
            WriteLiteral(@"<h1 class=""text-center"">All Employees</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">Name</th>
            <th class=""col-md-2"">Age</th>
            <th class=""col-md-2"">Address</th>
            <th class=""col-md-2"">Position</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(578, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(639, 3, false);
#line 22 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
                             Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(643, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(684, 13, false);
#line 23 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(697, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(738, 12, false);
#line 24 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Age);

#line default
#line hidden
            EndContext();
            BeginContext(750, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(791, 16, false);
#line 25 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Address);

#line default
#line hidden
            EndContext();
            BeginContext(807, 40, true);
            WriteLiteral("</td>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(848, 17, false);
#line 26 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
                            Write(Model[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(865, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 28 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\16. EXERCISE - C# AUTO MAPPING OBJECTS\FastFood.Web\Views\Employees\All.cshtml"
    }

#line default
#line hidden
            BeginContext(894, 79, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<div class=\"button-holder d-flex\" align=\"center\">\r\n    ");
            EndContext();
            BeginContext(973, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b735ed1036744829ff77d1d0ce85bf3", async() => {
                BeginContext(1063, 8, true);
                WriteLiteral("Register");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1075, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Employees.EmployeesAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
