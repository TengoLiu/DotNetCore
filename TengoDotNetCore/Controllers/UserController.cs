using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.BLL;

namespace TengoDotNetCore.Controllers {
    public class UserController : Controller {

        private UserBLL _bll;

        public UserController(UserBLL _bll) {
            this._bll = _bll;
        }

        public IActionResult Index() {
            
            return View();
        }
    }
}