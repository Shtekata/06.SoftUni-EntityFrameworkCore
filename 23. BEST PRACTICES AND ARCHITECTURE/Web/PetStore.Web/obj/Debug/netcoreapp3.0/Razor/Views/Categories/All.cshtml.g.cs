#pragma checksum "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a031094d7545f05324112a4cc7526f649e3cfd7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_All), @"mvc.1.0.view", @"/Views/Categories/All.cshtml")]
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
#line 1 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Services.Models.Pet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web.Models.Pet;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a031094d7545f05324112a4cc7526f649e3cfd7c", @"/Views/Categories/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4cd50cada616b095dfe5cfca5b0799c49cb035b", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PetStore.Web.ViewModels.Category.CategoryListingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
  
    ViewData["Title"] = "All";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>\r\n    Categories\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a031094d7545f05324112a4cc7526f649e3cfd7c4804", async() => {
                WriteLiteral("Create");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                #\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
          var counter = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
         foreach (var item in Model)
        {
            counter+=1;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-sm btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 44 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }, new { @class = "btn btn-sm btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 45 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }, new { @class = "btn btn-sm btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "D:\OneDrive\Projects\06. SoftUni - Entity Framework Core\23. BEST PRACTICES AND ARCHITECTURE\Web\PetStore.Web\Views\Categories\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PetStore.Web.ViewModels.Category.CategoryListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
