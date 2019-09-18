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
            ViewData.Model = await service.GetPageList(pageInfo.Page, pageInfo.PageSize
                                                        , p => p.ArticleType_Id == articleType_Id
                                                            && p.Status == 1
                                                            && (!string.IsNullOrWhiteSpace(keyword) && p.Title.Contains(keyword) || string.IsNullOrWhiteSpace(keyword)));
            ViewBag.Keyword = keyword;
            ViewBag.ArticleType_Id = articleType_Id;
            ViewBag.ArticleType_Ids = new SelectList(await service.ArticleTypeList(), "Id", "TypeName", articleType_Id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0) {
            if (id <= 0) {
                return new NotFoundResult(); ;
            }
            var model = await service.Get(p => p.Id == id);
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
            return MyJsonResultParamInvalid();
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
            return MyJsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0) {
            return Json(await service.Delete(id));
        }
    }
}