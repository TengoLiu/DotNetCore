using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ArticleController : BaseController {
        /// <summary>
        /// 当前控制器私有的service对象，在构造函数中传入
        /// 在IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly IArticleService service;

        public ArticleController(IArticleService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, string keyword = null, string sortBy = null) {
            ViewData.Model = await service.List(pageInfo, categoryID, keyword, sortBy, true);
            ViewBag.Keyword = keyword;
            ViewBag.CategoryID = categoryID;
            ViewBag.CategoryIDs = new SelectList(await service.CategoryList(), "ID", "Title", categoryID);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var model = await service.Detail(id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.CategoryID = new SelectList(await service.CategoryList(), "ID", "Title", model.CategoryID);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.Edit(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.CategoryID = new SelectList(await service.CategoryList(), "ID", "Title", 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.Add(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            //对于删除来说，其实我只要执行就好了，不管它成不成功！
            await service.Delete(id);
            return JsonResultSuccess("删除成功！");
        }
    }
}