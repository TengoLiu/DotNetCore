using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TengoDotNetCore.Controllers {
    public class GoodsController : BaseController {

        public IActionResult Index() {
            return View();
        }
    }
}