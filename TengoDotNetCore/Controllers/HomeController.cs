using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        public HomeController(TengoDbContext db) : base(db) { }

        public async Task<IActionResult> Index() {
            ViewBag.Banners = await db.Article.ToAsyncEnumerable()
                                    .Where(p => p.CategoryID == 4)
                                    .Take(10)
                                    .ToList();
            ViewBag.Goods = await db.Goods.ToAsyncEnumerable()
                                    .Where(p => p.Status == 1)
                                    .OrderBy(p => Guid.NewGuid())
                                    .Take(60)
                                    .ToList();
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
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
