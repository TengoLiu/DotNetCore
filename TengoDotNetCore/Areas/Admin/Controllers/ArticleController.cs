using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ArticleController : BaseController {
        private readonly ArticleService service;
        public ArticleController(ArticleService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, int articleType_Id = 0, string keyword = null, string sortBy = null) {
            ViewData.Model = await service.PageList(pageInfo, articleType_Id, keyword, sortBy, true);
            ViewBag.Keyword = keyword;
            ViewBag.ArticleType_Id = articleType_Id;
            ViewBag.ArticleType_Ids = new SelectList(await service.ArticleTypeList(), "Id", "TypeName", articleType_Id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id=0) {
            if ( id <= 0) {
                return new NotFoundResult(); ;
            }
            var model = await service.Get((int)id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.ArticleType_Id = new SelectList(await service.ArticleTypeList(), "Id", "TypeName", model.ArticleType_Id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model) {
            if (ModelState.IsValid) {
                return Json(await service.Update(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.ArticleType_Id = new SelectList(await service.ArticleTypeList(), "Id", "TypeName", 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article model) {
            if (ModelState.IsValid) {
                return Json(await service.Insert(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id=0) {
            return Json(await service.Delete(id));
        }
    }
}