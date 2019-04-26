using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<JsonResultObj> Insert(Goods model) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Name + "," + model.NameEn;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
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
                var goods = await db.Goods.Include(p => p.GoodsCategory).FirstOrDefaultAsync(p => p.Id == model.Id);

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

                var oldGCs = db.GoodsCategory.Where(p => p.Goods_ID == model.Id).ToList();

                oldGCs.ForEach(p => {
                    //找一找看看旧的集合里面有没有跟新的集合一样的值，如果有，那么就不用动
                    var existId = categoryIds.FirstOrDefault(q => q == p.Category_ID);

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
                            Category_ID = cid,
                            Goods_ID = model.Id
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
                query = query.Where(p => p.GoodsCategory.Exists(q => q.Category_ID == categoryID));
            }
            if (categoryIDs != null && categoryIDs.Count > 0) {
                foreach (var item in categoryIDs) {
                    query = query.Where(p => p.GoodsCategory.Exists(q => q.Category_ID == item));
                }
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
