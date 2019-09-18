using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        public async Task<IActionResult> Index([FromServices]ArticleService articleService, [FromServices]GoodsService goodsService) {
            ViewBag.Banners = await articleService.GetList(p => p.ArticleType_Id == 4, 10);

            ViewBag.Goods = await goodsService.GetList(p => p.Status == 1, 10);
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
