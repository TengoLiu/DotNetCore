using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class CategoryController : BaseController {

        public CategoryController(TengoDbContext db) : base(db) { }

        public async Task<IActionResult> Index() {
            ViewData.Model = await db.Category.ToAsyncEnumerable().ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.Category = await db.Category.ToAsyncEnumerable().ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category model) {
            if (ModelState.IsValid) {
                model.AddTime = DateTime.Now;
                if (model.ParID == 0) {
                    model.Level = 1;
                }
                else {
                    var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                    if (parent == null) {
                        return JsonResultError("父结点不存在！");
                    }
                    model.Level = parent.Level + 1;
                }
                db.Category.Add(model);
                await db.SaveChangesAsync();
                return JsonResultSuccess("添加成功！");
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.Category.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            if (model == null) {
                return new NotFoundResult();
            }

            ViewBag.Category = await db.Category.ToAsyncEnumerable().ToList();
            ViewData.Model = model;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model) {
            if (ModelState.IsValid) {
                try {
                    if (model.ParID == 0) {
                        model.Level = 1;
                    }
                    else {
                        var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                        if (parent == null) {
                            return JsonResultError("父结点不存在！");
                        }
                        model.Level = parent.Level + 1;
                    }
                    model.AddTime = DateTime.Now;
                    model.UpdateTime = DateTime.Now;
                    //标明哪些字段变动了
                    db.Entry(model).Property(p => p.Name).IsModified = true;
                    db.Entry(model).Property(p => p.ParID).IsModified = true;
                    db.Entry(model).Property(p => p.Level).IsModified = true;
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

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            try {
                if (id == null) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.Category.SingleOrDefaultAsync(p => p.ID == id);
                if (model != null) {
                    db.Category.Remove(model);
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