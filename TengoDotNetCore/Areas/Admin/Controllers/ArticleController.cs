using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ArticleController : BaseController {
        private readonly ArticleBLL service;
        public ArticleController(ArticleBLL service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices]TengoDbContext db, PageInfo pageInfo, int articleType_Id = 0, string keyword = null, string sortBy = null) {
            var query = db.Article.AsQueryable();
            if (articleType_Id > 0) {
                query = query.Where(p => p.ArticleType_Id == articleType_Id);
            }
            if (!string.IsNullOrWhiteSpace(keyword)) {
                keyword = keyword.Trim();
                query = query.Where(p => p.Title.Contains(keyword));
            }
            ViewData.Model = await PageUtils.CreatePageAsync(query, pageInfo.Page, pageInfo.PageSize);
            ViewBag.Keyword = keyword;
            ViewBag.ArticleType_Id = articleType_Id;
            ViewBag.ArticleType_Ids = new SelectList(await service.ArticleTypeList(), "Id", "TypeName", articleType_Id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromServices]TengoDbContext db, int id = 0) {
            if (id <= 0) {
                return new NotFoundResult(); ;
            }
            var model = await db.Article.FirstOrDefaultAsync(p => p.Id == id);
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