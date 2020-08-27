using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class GoodsController : BaseController {
        public GoodsBLL service;

        public GoodsController(GoodsBLL service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices]TengoDbContext db, PageInfo pageInfo, List<int> categoryID = null, string keyword = null, string sortBy = null) {
            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = categoryID;
            ViewBag.Category = await db.Category.ToListAsync();
            ViewBag.Goods = await service.PageList(pageInfo, categoryID, keyword, sortBy);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromServices]TengoDbContext db, int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await service.Get(id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.Category = await db.Category.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Goods model, List<int> categoryIds, List<string> albumUrls) {
            if (ModelState.IsValid) {
                #region 处理商品图册
                if (albumUrls != null && albumUrls.Count > 0) {
                    model.Albums = string.Join(',', albumUrls);
                }
                else {
                    model.Albums = string.Empty;
                }
                #endregion

                return Json(await service.Update(model, categoryIds));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add([FromServices]TengoDbContext db) {
            ViewBag.Category = await db.Category.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Goods model, List<int> categoryIds) {
            if (ModelState.IsValid) {
                try {
                    return Json(await service.Insert(model, categoryIds));
                }
                catch (Exception e) {
                    return MyJsonResultError(e);
                }
            }
            return MyJsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0) {
            return Json(await service.Delete(id));
        }
    }
}