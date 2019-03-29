using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        HomeService service;

        public HomeController(HomeService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index() {
            ViewData.Model = await service.GetIndex();
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
