#pragma checksum "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e36920ee01366c7028070987b00092be13a7bfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CoMgr_Views_Employee_EmployeeList), @"mvc.1.0.view", @"/Areas/CoMgr/Views/Employee/EmployeeList.cshtml")]
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
#line 1 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\_ViewImports.cshtml"
using IKProject_2512;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\_ViewImports.cshtml"
using IKProject_2512.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e36920ee01366c7028070987b00092be13a7bfa", @"/Areas/CoMgr/Views/Employee/EmployeeList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e12173450b529fbd9696171b1719b2f9ab02cf27", @"/Areas/CoMgr/Views/_ViewImports.cshtml")]
    public class Areas_CoMgr_Views_Employee_EmployeeList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IKProject_2512.Models.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PassiveEmployeeList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
  
    ViewData["Title"] = "EmployeeList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Aktif Personel Listesi</h4>\r\n\r\n<br />\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e36920ee01366c7028070987b00092be13a7bfa5176", async() => {
                WriteLiteral("Pasif Personel Listesi");
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
            WriteLiteral("\r\n\r\n<table class=\"table \" style=\"text-transform:capitalize\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
           Write(Html.DisplayNameFor(model => model.PhotoPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1e36920ee01366c7028070987b00092be13a7bfa8178", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
                   WriteLiteral("~/ImageFile/"+item.PhotoPath);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 34 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
               Write(Html.DisplayFor(modelItem => item.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
                                                                Write(Html.DisplayFor(modelItem => item.EmployeeMiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
               Write(Html.DisplayFor(modelItem => item.EmployeeLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Zeynep Hande\source\Workspaces\Scrum_2. Dönem Projesi\IKProject_2512\IKProject_2512\IKProject_2512\Areas\CoMgr\Views\Employee\EmployeeList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IKProject_2512.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591