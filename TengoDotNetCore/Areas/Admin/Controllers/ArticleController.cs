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
        private readonly IArticleCategoryService acservice;

        public ArticleController(IArticleService service, IArticleCategoryService acservice) {
            this.service = service;
            this.acservice = acservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null, string sortBy = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await service.List(pageInfo, keyword, sortBy, true);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var model = await service.Detail(id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.CategoryID = new SelectList(await acservice.List(), "ID", "Title", model.CategoryID);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model) {
            if (ModelState.IsValid) {
                var res = await service.Edit(model);
                if (res > 0) {
                    return JsonResultSuccess("修改成功！");
                }
                return JsonResultSuccess("修改失败，请检查信息是否有误！");
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.CategoryID = new SelectList(await acservice.List(), "ID", "Title", 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article model) {
            if (ModelState.IsValid) {
                var res = await service.Add(model);
                if (res > 0) {
                    return JsonResultSuccess("新增成功！");
                }
                return JsonResultSuccess("修改失败，请检查信息是否有误！");
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