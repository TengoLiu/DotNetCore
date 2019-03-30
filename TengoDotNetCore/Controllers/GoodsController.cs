using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class GoodsController : BaseController {

        private GoodsService service;

        public GoodsController(GoodsService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, string keyword = null, string sortBy = null) {
            ViewData.Model = await service.GetIndexVM(pageInfo, categoryID, keyword, sortBy);
            return View();
        }
    }
}