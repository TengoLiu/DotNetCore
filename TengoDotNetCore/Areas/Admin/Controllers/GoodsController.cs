using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class GoodsController : BaseController {
        public GoodsService service;

        public GoodsController(GoodsService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, string keyword = null, string sortBy = null) {
            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = categoryID;
            ViewBag.Category = await service.GetCategoryList();
            ViewBag.Goods = service.PageList(pageInfo, categoryID, null, keyword, sortBy);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult();
            }
            var model = await service.Get((int)id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.Category = await service.GetCategoryList();
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
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.Category = await service.GetCategoryList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Goods model, List<int> categoryIds) {
            if (ModelState.IsValid) {
                if (categoryIds != null) {
                    model.GoodsCategory = new List<GoodsCategory>();
                    categoryIds.ForEach(p => {
                        model.GoodsCategory.Add(new GoodsCategory {
                            Goods = model,
                            Category_ID = p
                        });
                    });
                }
                try {
                    return Json(await service.Insert(model));
                }
                catch (Exception e) {
                    return JsonResultError(e);
                }
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            return Json(await service.Delete(id));
        }
    }
}