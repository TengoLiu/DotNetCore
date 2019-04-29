﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class GoodsService : BaseService {

        public GoodsService(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Goods> Get(int id) {
            var model = await db.Goods
                .FirstOrDefaultAsync(p => p.Id == id);
            return model;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Insert(Goods model, List<int> categoryIds) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Name + "," + model.NameEn;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
                StringBuilder sbId = null;
                StringBuilder sbStr = null;
                if (categoryIds != null && categoryIds.Count > 0) {
                    sbId = new StringBuilder();
                    sbStr = new StringBuilder();
                    foreach (var cid in categoryIds) {
                        var cty = await GetCategory(cid);
                        if (cty != null) {
                            sbId.AppendFormat("'{0}',", cid);
                            //注意，由于分号被我用了，所以如果分类本身就有分号的话，要替换成中文的
                            sbStr.AppendFormat("'{0}',", cty.Name.Replace('\'', '’'));
                        }
                    }
                    sbId.Remove(sbId.Length - 1, 1);
                    sbStr.Remove(sbStr.Length - 1, 1);
                }
                model.CategoryIdStr = sbId != null ? sbId.ToString() : string.Empty;
                model.CategoryStr = sbStr != null ? sbStr.ToString() : string.Empty;
                model.AddTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                db.Goods.Add(model);
                await db.SaveChangesAsync();
                return JsonResultSuccess("添加成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Update(Goods model, List<int> categoryIds) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Name;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
                var goods = await db.Goods.FirstOrDefaultAsync(p => p.Id == model.Id);

                StringBuilder sbId = null;
                StringBuilder sbStr = null;
                if (categoryIds != null && categoryIds.Count > 0) {
                    sbId = new StringBuilder();
                    sbStr = new StringBuilder();
                    foreach (var cid in categoryIds) {
                        var cty = await GetCategory(cid);
                        if (cty != null) {
                            sbId.AppendFormat("'{0}',", cid);
                            //注意，由于分号被我用了，所以如果分类本身就有分号的话，要替换成中文的
                            sbStr.AppendFormat("'{0}',", cty.Name.Replace('\'', '’'));
                        }
                    }
                    sbId.Remove(sbId.Length - 1, 1);
                    sbStr.Remove(sbStr.Length - 1, 1);
                }
                goods.Name = model.Name;
                goods.NameEn = model.NameEn;
                goods.CoverImg = model.CoverImg;
                goods.Albums = model.Albums;
                goods.Price = model.Price;
                goods.Stock = model.Stock;
                goods.Status = model.Status;
                goods.CategoryIdStr = sbId != null ? sbId.ToString() : string.Empty;
                goods.CategoryStr = sbStr != null ? sbStr.ToString() : string.Empty;
                goods.Keywords = model.Keywords;
                goods.Description = model.Description;
                goods.Content = model.Content;
                goods.MContent = model.MContent;
                goods.Sort = model.Sort;
                goods.UpdateTime = DateTime.Now;

                await db.SaveChangesAsync();
                return JsonResultSuccess("修改成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Delete(int? id) {
            try {
                if (id == null) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.Article.SingleOrDefaultAsync(p => p.Id == id);
                if (model != null) {
                    db.Article.Remove(model);
                    await db.SaveChangesAsync();
                }
                return JsonResultSuccess("删除成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        public async Task<PageList<Goods>> PageList(PageInfo pageInfo, int categoryID, List<int> categoryIDs, string keyword, string sortBy) {
            var query = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase)
                || p.NameEn.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(sortBy)) {
                switch (sortBy.Trim().ToLower()) {
                    case "id":
                        query = query.OrderBy(p => p.Id);
                        break;
                    case "id_desc":
                        query = query.OrderByDescending(p => p.Id);
                        break;
                    case "sort":
                        query = query.OrderBy(p => p.Sort);
                        break;
                    case "sort_desc":
                        query = query.OrderByDescending(p => p.Sort);
                        break;
                    default:
                        query = query.OrderByDescending(p => p.Id);
                        break;
                }
            }
            if (categoryID > 0) {
                //query = query.Where(p => p.GoodsCategory.Exists(q => q.Category_ID == categoryID));
            }
            if (categoryIDs != null && categoryIDs.Count > 0) {
                //foreach (var item in categoryIDs) {
                //    query = query.Where(p => p.GoodsCategory.Exists(q => q.Category_ID == item));
                //}
            }
            return await CreatePageAsync(query, pageInfo);
        }

        /// <summary>
        /// 获取推荐商品
        /// </summary>
        /// <returns></returns>
        public async Task<List<Goods>> GetRecList(int take = 5) {
            if (take <= 0 || take >= 15) {//推荐商品一次性不能拿那么多
                take = 5;
            }
            return await db.Goods
                  .Where(p => p.Status == 1)
                  .OrderBy(p => Guid.NewGuid())
                  .Take(5)
                  .ToListAsync();
        }

        #region 分类相关
        public async Task<Category> GetCategory(int id) {
            if (id <= 0) {
                return null;
            }
            return await db.Category.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Category>> GetCategoryList() {
            return await db.Category.ToListAsync();
        }

        public async Task<JsonResultObj> InsertCategory(Category model) {
            if (model == null) {
                return JsonResultParamInvalid();
            }
            model.AddTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            if (model.ParID == 0) {
                model.Level = 1;
            }
            else {
                var parent = await db.Category.FirstOrDefaultAsync(p => p.Id == model.ParID);
                if (parent == null) {
                    return JsonResultError("父结点不存在！");
                }
                model.Level = parent.Level + 1;
            }
            db.Category.Add(model);
            await db.SaveChangesAsync();
            return JsonResultSuccess("添加成功！");
        }

        public async Task<JsonResultObj> UpdateCategory(Category model) {
            try {
                if (model.ParID == 0) {
                    model.Level = 1;
                }
                else {
                    var parent = await db.Category.FirstOrDefaultAsync(p => p.Id == model.ParID);
                    if (parent == null) {
                        return JsonResultError("父结点不存在！");
                    }
                    model.Level = parent.Level + 1;
                }
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

        public async Task<JsonResultObj> DeleteCategory(int id) {
            try {
                if (id <= 0) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.Category.FirstOrDefaultAsync(p => p.Id == id);
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
        #endregion
    }
}