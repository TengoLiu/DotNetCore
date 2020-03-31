using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Controllers {
    public class TestController : BaseController {

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
        public string Path([FromServices]IHostingEnvironment hostingEnvironment) {
            return hostingEnvironment.WebRootPath;
        }

        /// <summary>
        /// 测试联表并筛选自定义Model
        /// </summary>
        /// <param name="db"></param>
        public void TestUnion([FromServices]TengoDbContext db) {
            var query = from Address addr in db.Address.AsQueryable()
                        join user in db.User.AsQueryable()
                        on addr.UserID equals user.Id
                        where 1 == 1
                        select new {
                            user.Id,
                            user.NickName,
                            addr.Province
                        };
            var data = query.ToList();
        }
    }
}