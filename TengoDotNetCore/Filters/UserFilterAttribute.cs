using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TengoDotNetCore.Common;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Common.Sessions;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Filters {
    public class UserFilterAttribute : ActionFilterAttribute {
        /// <summary>
        /// 摘要:
        ///     在执行操作方法之前由 ASP.NET MVC 框架调用。
        ///     
        ///     在执行Action之前调用会此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            //如果发现Session里面的用户不存在的话，那么就给Result赋值，根据文档说明，赋值之后会短路本请求，也就是直接返回结果。
            if (filterContext.HttpContext.Session.Get<User>(Constant.SESSION_USER) == null) {
                if (filterContext.HttpContext.Request.Path.ToString().Contains("api", StringComparison.OrdinalIgnoreCase)) {//如果包含有“api”的话，说明是接口
                    filterContext.Result = new JsonResult(new JsonResultObj {
                        code = 2000,
                        msg = "您的登录状态已过期，请登录后再重新请求......"
                    });
                }
                else {
                    filterContext.Result = new RedirectResult("/user/login");
                }
            }
        }
    }
}
