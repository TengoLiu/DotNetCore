using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TengoDotNetCore.Web.MiddleWares {
    /// <summary>
    /// Tengo自定义中间件
    /// 2019年8月1日
    /// </summary>
    public class TengoMiddleWare {
        /// <summary>
        /// 下一个中间件的委托
        /// </summary>
        private readonly RequestDelegate _next;

        public TengoMiddleWare(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            // 在请求执行的时候可以对上下文做一些事情

            //然后调用下一个中间件
            await _next.Invoke(context);

            //然后如果后面一系列的中间件都执行完了之后，还可以看看这个时候的上下文，顺便也做一些操作
        }
    }

    /// <summary>
    /// MyMiddlewareExtensions帮助器类，可以更轻松地配置中间件中的你Startup类。 
    /// UseTengoMiddleware方法将中间件类添加到请求管道。 
    /// 在中间件的构造函数中注入获取所需的中间件服务。
    /// 换句话说，可以在Startup里面直接使用app.UseMiddleware()啦！
    /// </summary>
    public static class MyMiddlewareExtensions {
        public static IApplicationBuilder UseTengoMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<TengoMiddleWare>();
        }
    }
}
