using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class GoodsController : BaseController {
        private readonly GoodsService service;
        public GoodsController(GoodsService service) {
            this.service = service;
        }

        #region Index 商品列表
        public async Task<IActionResult> Index(PageInfo pageInfo, List<int> categoryID = null, string keyword = null, string sortBy = null) {
            ViewBag.Category = await service.GetCategoryList();
            if (pageInfo.PageSize <= 0) {
                pageInfo.PageSize = 60;
            }
            ViewBag.Goods = await service.PageList(pageInfo, categoryID, keyword, sortBy);
            return View();
        }
        #endregion

        #region Detail 商品详情
        public async Task<IActionResult> Detail(int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await service.Get(id);
            if (model == null || model.Status != 1) {
                return new NotFoundResult();
            }

            ViewData.Model = model;
            ViewBag.RecGoods = await service.GetRecList(5);
            return View();
        }
        #endregion

        #region RecList 获取推荐商品列表 api/goods/reclist
        [Route("api/goods/reclist")]
        public async Task<IActionResult> RecList(int take = 5) {
            return Json(await service.GetRecList(take));
        }
        #endregion
    }
}