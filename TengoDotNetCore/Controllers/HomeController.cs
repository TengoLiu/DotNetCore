using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        public async Task<IActionResult> Index([FromServices]TengoDbContext db) {
            ViewBag.Banners = await db.Article.Where(p => p.ArticleType.TypeName == "首页轮播图").Take(10).OrderByDescending(p => p.Id).ToListAsync();
            ViewBag.Goods = await db.Goods.Where(p => p.Status == 1).Take(10).OrderByDescending(p => p.Id).ToListAsync();
            return View();
        }

        public IActionResult About() {
            return View();
        }

        public IActionResult Contract() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        [Route("home/error")]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
