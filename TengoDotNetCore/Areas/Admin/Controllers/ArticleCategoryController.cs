using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.PBLL;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class ArticleCategoryController : BaseController {

        private readonly ArticlePBLL pbll;
        public ArticleCategoryController(TengoDbContext db, ArticlePBLL pbll) : base(db) {
            this.pbll = pbll;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await pbll.CategoryPageList(pageInfo, keyword);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.ArticleCategory.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleCategory model) {
            if (ModelState.IsValid) {
                try {
                    db.Entry(model).Property(p => p.Title).IsModified = true;
                    db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                    db.Entry(model).Property(p => p.Sort).IsModified = true;
                    await db.SaveChangesAsync();
                    return JsonResultSuccess("更新成功！");
                }
                catch (Exception e) {
                    return JsonResultError(e);
                }
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleCategory model) {
            if (ModelState.IsValid) {
                try {
                    db.ArticleCategory.Add(model);
                    await db.SaveChangesAsync();
                    return JsonResultSuccess("添加成功！");
                }
                catch (Exception e) {
                    return JsonResultError(e);
                }
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            try {
                if (id == null) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.ArticleCategory.SingleOrDefaultAsync(p => p.ID == id);
                if (model != null) {
                    db.ArticleCategory.Remove(model);
                    await db.SaveChangesAsync();
                }
                return JsonResultSuccess("删除成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }
    }
}