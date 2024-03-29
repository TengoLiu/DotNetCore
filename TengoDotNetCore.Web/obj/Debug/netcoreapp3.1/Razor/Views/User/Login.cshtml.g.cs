#pragma checksum "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Views\User\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c236c89eb2a4e2814e9d571d142f42d809005cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Login), @"mvc.1.0.view", @"/Views/User/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c236c89eb2a4e2814e9d571d142f42d809005cf", @"/Views/User/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74ff4fc8911935cb5178e0cec4d2432186c4c8b5", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <div class=\"container\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c236c89eb2a4e2814e9d571d142f42d809005cf3802", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <label for=""account"">请输入您的账号/手机号/邮箱</label>
                <input id=""account"" type=""text"" class=""form-control"" placeholder=""请输入您的账号"" />
                <small class=""form-text text-muted"">请输入您的账号.</small>
            </div>
            <div class=""form-group"">
                <label for=""password"">请输入您的密码</label>
                <input id=""password"" type=""password"" class=""form-control"" />
                <small class=""form-text text-muted"">请输入您的密码.</small>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <button type=\"button\" class=\"btn btn-primary\" id=\"btnSubmit\">提 交</button>\r\n        <br /> <br />\r\n        <a href=\"register\">没有账号？请先注册~</a>\r\n    </div>\r\n");
            DefineSection("Footer", async() => {
                WriteLiteral(@"
    <script>
        $(""#btnSubmit"").click(function () {
            var account = $(""#account"").val();
            var password = $(""#password"").val();
            if (isNullOrUndefinedOrEmpty(account)) {
                dialogAlert(""提示"", ""请输入账号/手机号/邮箱！"");
                return;
            }
            if (isNullOrUndefinedOrEmpty(password)) {
                dialogAlert(""提示"", ""请输入密码！"");
                return;
            }
            var returnUrl = getUrlParam(""returnUrl"");
            $.ajax({
                url: ""/api/user/login"",
                type: ""POST"",
                data: {
                    account: account,
                    password: password
                },
                dataType: ""JSON"",
                success: function (data) {
                    if (data.code == 1000) {
                        if (isNullOrUndefinedOrEmpty(returnUrl)) {
                            location.href = ""/"";
                        }
                        else {
  ");
                WriteLiteral(@"                          location.href = returnUrl;
                        }
                    }
                    else if (data.code == 2000) {
                        dialogAlert(""提示"",data.msg);
                        setTimeout(function () { }, 1000);
                    }
                    else {
                        dialogAlert(""提示"",data.msg);
                    }
                },
                error: function () {
                    dialogAlert(""提示"",""系统繁忙，请稍后再试......"");
                }
            });
        });
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
