#pragma checksum "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1af684f9b1572fdf89201a8732009cfd28e2cc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dish_Index), @"mvc.1.0.view", @"/Views/Dish/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dish/Index.cshtml", typeof(AspNetCore.Views_Dish_Index))]
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
#line 1 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1af684f9b1572fdf89201a8732009cfd28e2cc2", @"/Views/Dish/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Dish_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Application.DTO.DishDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(45, 11, true);
            WriteLiteral("\r\n<p>\r\n    ");
            EndContext();
            BeginContext(56, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1af684f9b1572fdf89201a8732009cfd28e2cc23503", async() => {
                BeginContext(79, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(93, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(186, 42, false);
#line 10 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Titile));

#line default
#line hidden
            EndContext();
            BeginContext(228, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(284, 47, false);
#line 13 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ingridients));

#line default
#line hidden
            EndContext();
            BeginContext(331, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(387, 43, false);
#line 16 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Serving));

#line default
#line hidden
            EndContext();
            BeginContext(430, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(486, 41, false);
#line 19 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(527, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(583, 44, false);
#line 22 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(627, 99, true);
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 29 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(758, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(807, 41, false);
#line 32 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Titile));

#line default
#line hidden
            EndContext();
            BeginContext(848, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(904, 46, false);
#line 35 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ingridients));

#line default
#line hidden
            EndContext();
            BeginContext(950, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1006, 42, false);
#line 38 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Serving));

#line default
#line hidden
            EndContext();
            BeginContext(1048, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1104, 40, false);
#line 41 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1144, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1200, 43, false);
#line 44 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Category));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 67, true);
            WriteLiteral("\r\n            </td>\r\n          \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1311, 53, false);
#line 48 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1364, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1385, 58, false);
#line 49 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new {  id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1443, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1464, 57, false);
#line 50 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1521, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 53 "C:\Users\Antonije\source\repos\FoodOrederingAPI\WebApp\Views\Dish\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1560, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Application.DTO.DishDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
