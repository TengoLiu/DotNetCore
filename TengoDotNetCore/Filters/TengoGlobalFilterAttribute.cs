using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Filters {
    public class TengoGlobalFilterAttribute : ActionFilterAttribute {

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
            //如果说执行Action方法出现错误的话,中断操作,并且重定向到错误页面
            if (filterContext.Exception != null) {
                filterContext.Canceled = true;
                filterContext.Result = new RedirectToRouteResult("/error");
                return;
            }
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
