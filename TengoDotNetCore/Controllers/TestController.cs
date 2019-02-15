using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TengoDotNetCore.Controllers {
    public class TestController : Controller {

        public void TestCookie1() {
            HttpContext.Response.Cookies.Append("hello", "lkt");
        }

        public void TestCookie2() {
            HttpContext.Response.Cookies.Append("hello", "lkt", new Microsoft.AspNetCore.Http.CookieOptions {
                //指定这个Cookie是重要的，不需要经过用户的同意就可以存储
                IsEssential = true
            });
        }

    }
}