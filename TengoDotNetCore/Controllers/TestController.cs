using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace TengoDotNetCore.Controllers {
    public class TestController : Controller {

        private readonly IHostingEnvironment _hostingEnvironment;
        public TestController(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        public void TestCookie1() {
            HttpContext.Response.Cookies.Append("hello", "lkt");
        }

        public void TestCookie2() {
            HttpContext.Response.Cookies.Append("hello", "lkt", new Microsoft.AspNetCore.Http.CookieOptions {
                //指定这个Cookie是重要的，不需要经过用户的同意就可以存储
                IsEssential = true
            });
        }

        /// <summary>
        /// 获取物理路径
        /// 需要注入一股服务端环境对象IHostingEnvironment
        /// </summary>
        /// <returns></returns>
        public string Path() {
            return _hostingEnvironment.WebRootPath;
        }
    }
}