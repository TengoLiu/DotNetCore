using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class ArticleCategoryController : BaseController {
        private readonly IArticleService service;
        public ArticleCategoryController(IArticleService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await service.CategoryPageList(pageInfo, keyword);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var model = await service.CategoryDetail(id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleCategory model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.CategoryEdit(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleCategory model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.CategoryAdd(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            //对于删除来说，其实我只要执行就好了，不管它成不成功！
            await service.CategoryDelete(id);
            return JsonResultSuccess("删除成功！");
        }
    }
}