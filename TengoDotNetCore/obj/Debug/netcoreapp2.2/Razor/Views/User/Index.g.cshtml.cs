#pragma checksum "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "178f975cee6b48dd9993025ac20abdaae85a8193"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\_ViewImports.cshtml"
using TengoDotNetCore;

#line default
#line hidden
#line 2 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\_ViewImports.cshtml"
using TengoDotNetCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"178f975cee6b48dd9993025ac20abdaae85a8193", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a037980ea1b4cc56f2f93f2a8cf086e23d1e2607", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml"
  
    ViewData["Title"] = "用户列表";

#line default
#line hidden
            BeginContext(59, 16, true);
            WriteLiteral("<h1>Index</h1>\r\n");
            EndContext();
#line 6 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml"
 foreach(var item in Model) {

#line default
#line hidden
            BeginContext(106, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(126, 7, false);
#line 8 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml"
   Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(133, 1, true);
            WriteLiteral("-");
            EndContext();
            BeginContext(135, 13, false);
#line 8 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml"
            Write(item.NickName);

#line default
#line hidden
            EndContext();
            BeginContext(148, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 10 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore\Views\User\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
