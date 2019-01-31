using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Controllers {
    public class HomeController : BaseController {
        public IActionResult Index() {
            HttpContext.Session.Set("hello", Encoding.Default.GetBytes("hello world"));
            ViewBag.Hello = HttpContext.Session.GetString("hello");
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
