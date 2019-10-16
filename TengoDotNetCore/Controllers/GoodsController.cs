using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.Controllers {
    public class GoodsController : BaseController {

        #region Index 商品列表
        public async Task<IActionResult> Index([FromServices]GoodsBLL service, [FromServices]TengoDbContext db, PageInfo pageInfo, List<int> categoryID = null, string keyword = null, string sortBy = null) {
            ViewBag.Category = await db.Category.ToListAsync();
            if (pageInfo.PageSize <= 0) {
                pageInfo.PageSize = 60;
            }
            ViewBag.Goods = await service.PageList(pageInfo, categoryID, keyword, sortBy);
            return View();
        }
        #endregion

        #region Detail 商品详情
        public async Task<IActionResult> Detail([FromServices]GoodsBLL service, int id = 0) {
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
        public async Task<IActionResult> RecList([FromServices]GoodsBLL service, int take = 5) {
            return Json(await service.GetRecList(take));
        }
        #endregion
    }
}