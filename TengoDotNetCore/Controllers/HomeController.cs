using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        public async Task<IActionResult> Index([FromServices]CommonService service) {
            var dic = await service.GetHomeIndexViewModel();
            if (dic != null) {
                ViewBag.Banners = dic["Banners"];
                ViewBag.Goods = dic["Goods"];
            }
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

        public void TestFenCi([FromServices]CommonService service) {
            service.TestFenCi();
        }
    }
}
