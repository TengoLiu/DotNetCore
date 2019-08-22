﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class AddressController : Controller {
        public IActionResult Index() {
            var service = HttpContext.RequestServices.GetService(typeof(AddressService));
            return View();
        }
    }
}