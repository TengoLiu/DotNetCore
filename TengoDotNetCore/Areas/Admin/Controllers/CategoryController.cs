using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class CategoryController : BaseController {
        /// <summary>
        /// 当前控制器私有的service对象，在构造函数中传入
        /// 在IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly IGoodsService service;

        public CategoryController(IGoodsService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index() {
            ViewData.Model = await service.CategoryList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewData["Category"] = await service.CategoryList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.CategoryAdd(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var article = await service.Detail(id);
            ViewData["Category"] = await service.CategoryList();
            ViewData.Model = article;
            if (article == null) {
                return new NotFoundResult();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.CategoryAdd(model));
            }
            return JsonResultParamInvalid();
        }
    }
}