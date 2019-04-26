using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TengoDotNetCore.Controllers {
    public class CartController : BaseController {
        public CartController() {
        }

        #region Index 我的购物车
        public IActionResult Index() {
            return View();
        }
        #endregion
    }
}