using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class GoodsController : BaseController {

        public GoodsController(TengoDbContext db) : base(db) { }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, int categoryID = 0, string keyword = null, string sortBy = null) {
            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = categoryID;
            ViewBag.Category = await db.Category.ToAsyncEnumerable().ToList();

            var query = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword.Trim()) || p.NameEn.Contains(keyword.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(sortBy)) {
                switch (sortBy.Trim().ToLower()) {
                    case "id":
                        query = query.OrderBy(p => p.ID);
                        break;
                    case "id_desc":
                        query = query.OrderByDescending(p => p.ID);
                        break;
                    case "sort":
                        query = query.OrderBy(p => p.Sort);
                        break;
                    case "sort_desc":
                        query = query.OrderByDescending(p => p.Sort);
                        break;
                    default:
                        query = query.OrderByDescending(p => p.ID);
                        break;
                }
            }
            if (categoryID > 0) {
                query = query.Where(p => p.GoodsCategory.Exists(q => q.CategoryID == categoryID));
            }
            ViewBag.Goods = await PageList<Goods>.CreateAsync(query, pageInfo);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || id <= 0) {
                return new NotFoundResult();
            }
            var query = db.Goods.Include(p => p.GoodsCategory).AsQueryable();
            var model = await query.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);

            ViewData["Category"] = await db.Category.ToAsyncEnumerable().ToList();
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Goods model, List<int> categoryIds, List<string> albumUrls) {
            if (ModelState.IsValid) {
                try {
                    if (string.IsNullOrWhiteSpace(model.Keywords)) {
                        model.Keywords = model.Name;
                    }
                    if (string.IsNullOrWhiteSpace(model.Description)) {
                        model.Description = model.Keywords;
                    }

                    #region 处理商品图册
                    if (albumUrls != null && albumUrls.Count > 0) {
                        model.Albums = string.Join(',', albumUrls);
                    }
                    else {
                        model.Albums = string.Empty;
                    }
                    #endregion

                    var goods = await db.Goods.Include(p => p.GoodsCategory).FirstOrDefaultAsync(p => p.ID == model.ID);

                    model.UpdateTime = DateTime.Now;
                    //标明哪些字段变动了
                    db.Entry(model).Property(p => p.Name).IsModified = true;
                    db.Entry(model).Property(p => p.NameEn).IsModified = true;
                    db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                    db.Entry(model).Property(p => p.Albums).IsModified = true;
                    db.Entry(model).Property(p => p.Price).IsModified = true;
                    db.Entry(model).Property(p => p.Stock).IsModified = true;
                    db.Entry(model).Property(p => p.Status).IsModified = true;
                    db.Entry(model).Property(p => p.Keywords).IsModified = true;
                    db.Entry(model).Property(p => p.Description).IsModified = true;
                    db.Entry(model).Property(p => p.Content).IsModified = true;
                    db.Entry(model).Property(p => p.MContent).IsModified = true;
                    db.Entry(model).Property(p => p.Sort).IsModified = true;

                    var oldGCs = db.GoodsCategory.Where(p => p.GoodsID == model.ID).ToList();

                    oldGCs.ForEach(p => {
                        //找一找看看旧的集合里面有没有跟新的集合一样的值，如果有，那么就不用动
                        var existId = categoryIds.FirstOrDefault(q => q == p.CategoryID);

                        //如果旧的集合里面有，但是新的没有的话，说明这个老东西要删了
                        if (existId <= 0) {
                            db.GoodsCategory.Remove(p);
                        }
                        else {
                            categoryIds.Remove(existId);
                        }
                    });

                    //比对完之后,剩下的就是纯粹要插入的了，那么直接插入即可
                    if (categoryIds.Count > 0) {
                        foreach (var cid in categoryIds) {
                            db.GoodsCategory.Add(new GoodsCategory {
                                CategoryID = cid,
                                GoodsID = model.ID
                            });
                        }
                    }
                    await db.SaveChangesAsync();
                    return JsonResultSuccess("修改成功！");
                }
                catch (Exception e) {
                    return JsonResultError(e);
                }
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.Category = await db.Category.ToAsyncEnumerable().ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Goods model, List<int> categoryIds) {
            if (ModelState.IsValid) {
                if (categoryIds != null) {
                    model.GoodsCategory = new List<GoodsCategory>();
                    categoryIds.ForEach(p => {
                        model.GoodsCategory.Add(new GoodsCategory {
                            Goods = model,
                            CategoryID = p
                        });
                    });
                }
                try {
                    db.Goods.Add(model);
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
                if (id != null) {
                    var model = await db.Goods.SingleOrDefaultAsync(p => p.ID == id);
                    if (model != null) {
                        db.Goods.Remove(model);
                        await db.SaveChangesAsync();
                    }
                }
                return JsonResultSuccess("删除成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }
    }
}