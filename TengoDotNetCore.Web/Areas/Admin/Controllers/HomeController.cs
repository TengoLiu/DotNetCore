using Microsoft.AspNetCore.Mvc;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class HomeController : BaseController {

        public IActionResult Login() {
            return View();
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Welcome() {
            ViewBag.CurrentIP = HttpContext.Connection.RemoteIpAddress;
            return View();
        }
    }
}