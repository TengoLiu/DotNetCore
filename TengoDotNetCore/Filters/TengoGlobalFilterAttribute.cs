using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using TengoDotNetCore.Common.BaseModels;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace TengoDotNetCore.Filters {
    public class TengoGlobalFilterAttribute : ActionFilterAttribute {
        private IHostingEnvironment _env;

        public TengoGlobalFilterAttribute(IHostingEnvironment env) {
            _env = env;
        }

        /// <summary>
        /// 摘要:
        ///     在执行操作方法之前由 ASP.NET MVC 框架调用。
        ///     
        ///     在执行Action之前调用会此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 摘要:
        ///     在执行操作方法后由 ASP.NET MVC 框架调用。
        ///      
        ///     执行完Action方法之后调用此方法，如果报错的话，可以在这一步处理
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            #region 如果Action执行之后发现报错了
            if (filterContext.Exception != null) {
                if (_env.IsDevelopment()) {
                    //如果是测试环境的话，那么啥都不做，直接显示报错页面
                }
                else {//由于中间件已经给我定义好了报错的页面了，所以这里只需要对Api报错进行处理就好了
                    var path = filterContext.HttpContext.Request.Path.ToString();
                    if (path.Contains("/api", StringComparison.OrdinalIgnoreCase)) {
                        filterContext.Canceled = true;
                        filterContext.Result = new JsonResult(new JsonResultObj {
                            code = 999,
                            msg = Common.Constant.ERROR_DEFAULT
                        });
                    }
                }
            }
            #endregion

            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 摘要:
        ///     在执行操作结果之前由 ASP.NET MVC 框架调用。
        ///      
        ///     执行完Action取完数据，正准备去渲染视图的时候调用此方法，
        ///     如果说在Action执行错误的话，那么可能会返回
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext context) {
            base.OnResultExecuting(context);
        }

        /// <summary>
        /// 摘要:
        ///     在执行操作结果后由 ASP.NET MVC 框架调用。
        /// 
        ///     渲染完视图，得到最终的HTML之后执行此方法。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext context) {
            base.OnResultExecuted(context);
        }

    }
}
