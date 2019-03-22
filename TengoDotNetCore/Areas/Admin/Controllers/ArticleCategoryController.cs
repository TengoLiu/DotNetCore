using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class ArticleCategoryController : BaseController {
        private readonly IArticleCategoryService service;
        public ArticleCategoryController(IArticleCategoryService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await service.PageList(pageInfo, keyword);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var model = await service.Detail(id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleCategory model) {
            if (ModelState.IsValid) {
                return JsonResult(await service.Edit(model));
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