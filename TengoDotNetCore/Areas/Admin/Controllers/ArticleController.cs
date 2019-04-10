using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ArticleController : BaseController {
        private readonly ArticlePBLL pbll;
        public ArticleController(TengoDbContext db, ArticlePBLL pbll) : base(db) {
            this.pbll = pbll;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, string keyword = null, string sortBy = null) {
            ViewData.Model = await pbll.PageList(pageInfo, categoryID, keyword, sortBy, true);
            ViewBag.Keyword = keyword;
            ViewBag.CategoryID = categoryID;
            ViewBag.CategoryIDs = new SelectList(await pbll.CategoryList(), "ID", "Title", categoryID);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult(); ;
            }
            var model = await db.Article.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.CategoryID = new SelectList(await pbll.CategoryList(), "ID", "Title", model.CategoryID);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model) {
            if (ModelState.IsValid) {
                try {
                    if (string.IsNullOrWhiteSpace(model.Keywords)) {
                        model.Keywords = model.Title + "," + model.Author;
                    }
                    if (string.IsNullOrWhiteSpace(model.Description)) {
                        model.Description = model.Keywords;
                    }
                    model.UpdateTime = DateTime.Now;
                    //标明哪些字段变动了
                    db.Entry(model).Property(p => p.Title).IsModified = true;
                    db.Entry(model).Property(p => p.Author).IsModified = true;
                    db.Entry(model).Property(p => p.CategoryID).IsModified = true;
                    db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                    db.Entry(model).Property(p => p.Status).IsModified = true;
                    db.Entry(model).Property(p => p.Keywords).IsModified = true;
                    db.Entry(model).Property(p => p.Description).IsModified = true;
                    db.Entry(model).Property(p => p.LinkUrl).IsModified = true;
                    db.Entry(model).Property(p => p.Content).IsModified = true;
                    db.Entry(model).Property(p => p.MContent).IsModified = true;
                    db.Entry(model).Property(p => p.Sort).IsModified = true;
                    db.Entry(model).Property(p => p.UpdateTime).IsModified = true;
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
        public async Task<IActionResult> Add() {
            ViewBag.CategoryID = new SelectList(await pbll.CategoryList(), "ID", "Title", 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article model) {
            if (ModelState.IsValid) {
                try {
                    if (string.IsNullOrWhiteSpace(model.Keywords)) {
                        model.Keywords = model.Title + "," + model.Author;
                    }
                    if (string.IsNullOrWhiteSpace(model.Description)) {
                        model.Description = model.Keywords;
                    }
                    model.AddTime = DateTime.Now;
                    model.UpdateTime = DateTime.Now;
                    db.Article.Add(model);
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
            if (id == null) {
                return JsonResultSuccess("删除成功！");
            }
            var model = await db.Article.SingleOrDefaultAsync(p => p.ID == id);
            if (model != null) {
                db.Article.Remove(model);
                await db.SaveChangesAsync();
            }
            return JsonResultSuccess("删除成功！");
        }
    }
}