using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.PBLL;

namespace TengoDotNetCore.Controllers {
    public class GoodsController : BaseController {
        private GoodsPBLL pbll;

        public GoodsController(TengoDbContext db, GoodsPBLL pbll) : base(db) {
            this.pbll = pbll;
        }

        #region Index 商品列表
        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, List<int> categoryIDs = null, string keyword = null, string sortBy = null) {
            ViewBag.Category = await db.Category.ToAsyncEnumerable().ToList();
            if (pageInfo.PageSize <= 0) {
                pageInfo.PageSize = 60;
            }
            ViewBag.Goods = await pbll.PageList(pageInfo, categoryID, categoryIDs, keyword, sortBy);
            return View();
        }
        #endregion

        #region Detail 商品详情
        public async Task<IActionResult> Detail(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.Goods
                .Include(p => p.GoodsCategory)
                .ThenInclude(pt => pt.Category)
                .ToAsyncEnumerable()
                .FirstOrDefault(p => p.ID == id);
            if (model == null || model.Status != 1) {
                return new NotFoundResult();
            }

            ViewData.Model = model;
            ViewBag.RecGoods = await db.Goods
                                    .Where(p => p.Status == 1)
                                    .ToAsyncEnumerable()
                                    .OrderBy(p => Guid.NewGuid())
                                    .Take(5)
                                    .ToList();
            return View();
        }
        #endregion
    }
}