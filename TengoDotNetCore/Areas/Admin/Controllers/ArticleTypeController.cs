using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class ArticleTypeController : BaseController {
        private readonly ArticleService service;
        public ArticleTypeController(ArticleService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await service.CategoryPageList(pageInfo, keyword);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromServices]TengoDbContext db, int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.Article.FirstOrDefaultAsync(p => p.Id == id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleType model) {
            if (ModelState.IsValid) {
                return Json(await service.UpdateArticleType(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleType model) {
            if (ModelState.IsValid) {
                return Json(await service.InsertArticleType(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0) {
            return Json(await service.DeleteArticleType(id));
        }
    }
}