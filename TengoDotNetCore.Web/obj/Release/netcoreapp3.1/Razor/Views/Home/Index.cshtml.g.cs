#pragma checksum "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2b80240b95134e8e61eed984eac5b53e022efc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\_ViewImports.cshtml"
using TengoDotNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\_ViewImports.cshtml"
using TengoDotNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\_ViewImports.cshtml"
using TengoDotNetCore.Common.BaseModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2b80240b95134e8e61eed984eac5b53e022efc6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74ff4fc8911935cb5178e0cec4d2432186c4c8b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/swiper/swiper.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/swiper/swiper.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
  
    ViewBag.Title = "首页";

#line default
#line hidden
#nullable disable
            DefineSection("Header", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2b80240b95134e8e61eed984eac5b53e022efc64628", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<div class=\"container-fluid\">\r\n    <!--banner start-->\r\n    <div class=\"swiper-container swiper-container swiper-container-horizontal banner\">\r\n        <div class=\"swiper-wrapper\">\r\n");
#nullable restore
#line 11 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
             if (ViewBag.Banners != null) {
                for (var i = 0; i < ViewBag.Banners.Count; i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"swiper-slide text-center\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 501, "\"", 535, 1);
#nullable restore
#line 14 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 508, ViewBag.Banners[i].LinkUrl, 508, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 587, "\"", 621, 1);
#nullable restore
#line 15 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 593, ViewBag.Banners[i].CoverImg, 593, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 622, "\"", 630, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </a>\r\n                    </div>\r\n");
#nullable restore
#line 18 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"swiper-pagination\"></div>\r\n    </div>\r\n    <!--banner end-->\r\n</div>\r\n<br />\r\n<div class=\"container home-index\">\r\n    <ul class=\"clearfix index-goods\">\r\n");
#nullable restore
#line 29 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
         foreach (var item in ViewBag.Goods) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"float-left\"");
            BeginWriteAttribute("title", " title=\"", 1001, "\"", 1032, 2);
#nullable restore
#line 30 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1009, item.Name, 1009, 10, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1019, item.NameEn, 1020, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1054, "\"", 1086, 2);
            WriteAttributeValue("", 1061, "/goods/detail?id=", 1061, 17, true);
#nullable restore
#line 31 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1078, item.Id, 1078, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                    <img class=\"square width-full\"");
            BeginWriteAttribute("src", " src=\"", 1156, "\"", 1176, 1);
#nullable restore
#line 32 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1162, item.CoverImg, 1162, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </a>\r\n                <p class=\"price\">￥");
#nullable restore
#line 34 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
                             Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1273, "\"", 1305, 2);
            WriteAttributeValue("", 1280, "/goods/detail?id=", 1280, 17, true);
#nullable restore
#line 35 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1297, item.Id, 1297, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <p class=\"goods-name\">");
#nullable restore
#line 36 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("&ensp;&ensp;");
#nullable restore
#line 36 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
                                                           Write(item.NameEn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 39 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>\r\n\r\n");
            DefineSection("Footer", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2b80240b95134e8e61eed984eac5b53e022efc611340", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        /*轮播baner start*/
        var swiper1 = new Swiper('.swiper-container', {
            loop: true,
            autoplay: true,
            speed: 1000,
            pagination: {
                el: '.swiper-pagination',
                clickable: true,
            }
        });

        $("".swiper-pagination-bullet"").hover(function () {
            $(this).click();
        }, function () {
            swiper1.autoplay.start();
        });

        $("""")
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
