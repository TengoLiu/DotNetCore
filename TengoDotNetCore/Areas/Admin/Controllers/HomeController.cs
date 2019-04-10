using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class HomeController : BaseController {
        public HomeController(TengoDbContext db) : base(db) { }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Welcome() {
            ViewBag.CurrentIP = HttpContext.Connection.RemoteIpAddress;
            return View();
        }
    }
}