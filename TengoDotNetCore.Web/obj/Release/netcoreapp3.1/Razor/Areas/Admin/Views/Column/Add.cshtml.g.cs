#pragma checksum "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89c41c90f594762265c6e83a15579c7fb9b004da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Column_Add), @"mvc.1.0.view", @"/Areas/Admin/Views/Column/Add.cshtml")]
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
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TengoDotNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TengoDotNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TengoDotNetCore.Common.BaseModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TengoDotNetCore.Models.Logs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\_ViewImports.cshtml"
using System.Collections.Specialized;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89c41c90f594762265c6e83a15579c7fb9b004da", @"/Areas/Admin/Views/Column/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f02a4c950b8dd1e24f340473cf3cd744c09756c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Column_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Column>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
  
    ViewBag.Title = "新增栏目";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"page-container\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89c41c90f594762265c6e83a15579c7fb9b004da5602", async() => {
                WriteLiteral(@"
        <div class=""text-danger""></div>
        <div class=""row cl"">
            <label for=""columnType"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>栏目类别：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <select id=""ColumnType"" name=""ColumnTypeId"" class=""input-text"">
");
#nullable restore
#line 12 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
                     foreach (var item in ViewBag.Types) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89c41c90f594762265c6e83a15579c7fb9b004da6493", async() => {
#nullable restore
#line 13 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
                                            Write(item.TypeName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 14 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
            </div>
        </div>
        <div class=""row cl"">
            <label for=""Status"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>是否显示：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <select class=""input-text"" id=""Status"" name=""status"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89c41c90f594762265c6e83a15579c7fb9b004da8980", async() => {
                    WriteLiteral("显示");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89c41c90f594762265c6e83a15579c7fb9b004da10219", async() => {
                    WriteLiteral("不显示");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
            </div>
        </div>
        <div class=""row cl"">
            <label for=""title"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>中文名称：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                ");
#nullable restore
#line 30 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.TextBoxFor(p => p.Title, new { @class = "input-text" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 31 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.ValidationMessageFor(p => p.Title, null, new { @class = "c-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <div class=""row cl"">
            <label for=""ImgUrl"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red""></span>主图(PC)：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <img id=""uploadImg"" style=""width:300px;margin-bottom:15px;border:1px solid #e4e4e4;""");
                BeginWriteAttribute("src", " src=\"", 1824, "\"", 1874, 1);
#nullable restore
#line 37 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
WriteAttributeValue("", 1830, TengoDotNetCore.Common.Constant.DEFAULT_PIC, 1830, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <span>上传图片或者在下面填入图片的网络地址。</span>\r\n                <br />\r\n                <input class=\"input-text\" type=\"text\" id=\"upload-url\" name=\"imgUrl\"");
                BeginWriteAttribute("value", " value=\"", 2037, "\"", 2089, 1);
#nullable restore
#line 40 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
WriteAttributeValue("", 2045, TengoDotNetCore.Common.Constant.DEFAULT_PIC, 2045, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                <input class=""input-text"" type=""button"" id=""upload-button"" value=""选择图片上传（1920*480）"" />
            </div>
        </div>
        <div class=""row cl"">
            <label for=""MImgUrl"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red""></span>主图(移动)：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <img id=""uploadImg"" style=""width:160px;margin-bottom:15px;border:1px solid #e4e4e4;""");
                BeginWriteAttribute("src", " src=\"", 2537, "\"", 2587, 1);
#nullable restore
#line 47 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
WriteAttributeValue("", 2543, TengoDotNetCore.Common.Constant.DEFAULT_PIC, 2543, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <span>上传图片或者在下面填入图片的网络地址。</span>\r\n                <br />\r\n                <input class=\"input-text\" type=\"text\" id=\"upload-url\" name=\"mImgUrl\"");
                BeginWriteAttribute("value", " value=\"", 2751, "\"", 2803, 1);
#nullable restore
#line 50 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
WriteAttributeValue("", 2759, TengoDotNetCore.Common.Constant.DEFAULT_PIC, 2759, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                <input class=""input-text"" type=""button"" id=""upload-button2"" value=""选择图片上传（640*320）"" />
            </div>
        </div>
        <div class=""row cl"">
            <label for=""Href"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red""></span>PC链接：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                ");
#nullable restore
#line 57 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.TextBoxFor(p => p.Href, new { @class = "input-text" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 58 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.ValidationMessageFor(p => p.Href, null, new { @class = "c-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"row cl\">\r\n            <label for=\"title\" class=\"form-label col-xs-4 col-sm-2\"><span class=\"c-red\"></span>移动端链接：</label>\r\n            <div class=\"formControls col-xs-8 col-sm-9\">\r\n                ");
#nullable restore
#line 64 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.TextBoxFor(p => p.MHref, new { @class = "input-text" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 65 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.ValidationMessageFor(p => p.MHref, null, new { @class = "c-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"row cl\">\r\n            <label for=\"Sort\" class=\"form-label col-xs-4 col-sm-2\"><span class=\"c-red\">*</span>排序数字：</label>\r\n            <div class=\"formControls col-xs-8 col-sm-9\">\r\n                ");
#nullable restore
#line 71 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.TextBoxFor(p => p.Sort, new { @class = "input-text" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 72 "D:\VS2017Projects\TengoDotNetCore\TengoDotNetCore.Web\Areas\Admin\Views\Column\Add.cshtml"
           Write(Html.ValidationMessageFor(p => p.Sort, null, new { @class = "c-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <div class=""row cl"">
            <label for=""ValidStartTime"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>上线时间：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" onfocus=""WdatePicker({ maxDate: '#F{$dp.$D(\'ValidEndTime\')||\'%y-%M-%d\'}' })"" id=""ValidStartTime"" name=""validStartTime""");
                BeginWriteAttribute("value", " value=\"", 4528, "\"", 4536, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""input-text Wdate"" style=""width:120px;"">
            </div>
        </div>
        <div class=""row cl"">
            <label for=""ValidEndTime"" class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>下线时间：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" onfocus=""WdatePicker({ minDate: '#F{$dp.$D(\'ValidStartTime\')}' })"" id=""ValidEndTime"" name=""validEndTime""");
                BeginWriteAttribute("value", " value=\"", 4969, "\"", 4977, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""input-text Wdate"" style=""width:120px;"">
            </div>
        </div>
        <div class=""row cl"">
            <div class=""col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2"">
                <a id=""btn-submit"" class=""btn btn-primary radius"">
                    <i class=""Hui-iconfont"">&#xe632;</i> 保存并提交审核
                </a>
                <button onclick=""removeIframe();"" class=""btn btn-default radius"" type=""button"">&nbsp;&nbsp;取消&nbsp;&nbsp;</button>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            $(""#btn-submit"").click(function () {
                /*
                 * 按照我以前的做法，我肯定是input里面不写字段的限制，并且只会在后面的js里面写上一堆的限制，
                 * 然后提交的时候在校验rules是否符合要求。
                 * 但是按照上面那样的做法的话，非常地不妥。那样需要我手动在JS写字段限制的规则，导致大大增多了工作量，这是非常反人类的！
                 * 这一句代码其实就是对表单再进行一次校验，并且判断校验是否通过，可谓一举两得
                 */
                if (!$(""#form1"").valid()) {
                    return;
                }
                $.ajax({
                    url: ""/admin/column/ApiAdd"",
                    type: ""POST"",
                    data: $(""#form1"").serialize(),
                    dataType: ""JSON"",
                    success: function (data) {
                        if (data.status == 1000) {
                            layer.msg(data.msg, { icon: 1, time: 1000 });
                            setTimeout(function () {
                                var index = parent.layer.getFrameIndex(window.name);
                                ");
                WriteLiteral(@"console.log(window.name);
                                parent.$('.btn-refresh').click();
                                parent.layer.close(index);
                            }, 1500);
                            parent.location.reload();
                        }
                        else if (data.staus == 2000) {
                            layer.msg(data.msg, { icon: 1, time: 1500 });
                            setTimeout(function () { location.href = ""/admin/manager/login""; }, 1000);
                        }
                        else {
                            layer.msg(data.msg, { icon: 2, time: 2000 });
                        }
                    },
                    error: function () {
                        layer.msg(""系统繁忙，请稍后再试......"", { icon: 2, time: 1000 });
                    }
                });
            });
        });

        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true,
           ");
                WriteLiteral(@"     uploadJson: '/admin/kindEditor/upload',
                fileManagerJson: '/admin/kindEditor/fileManager',
            });
            //商品主图上传
            K('#upload-button').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        showRemote: true,
                        imageUrl: K('#upload-url').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#upload-url').val(url);
                            $('#uploadImg').prop(""src"", url);
                            editor.hideDialog();
                        }
                    });
                });
            });
            K('#upload-button2').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        showRemote: false,
                        imageUrl: K('#upload-url2').val(),");
                WriteLiteral(@"
                        clickFn: function (url, title, width, height, border, align) {
                            K('#upload-url2').val(url);
                            $('#uploadImg2').prop(""src"", url);
                            editor.hideDialog();
                        }
                    });
                });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Column> Html { get; private set; }
    }
}
#pragma warning restore 1591
