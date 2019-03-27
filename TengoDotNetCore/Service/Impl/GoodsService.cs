using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Abs;

namespace TengoDotNetCore.Service.Impl {
    public class GoodsService : AbsService, IGoodsService {

        public GoodsService(TengoDbContext db) : base(db) {
        }

        public async Task<JsonResultObj> Add(Goods model) {
            try {
                db.Goods.Add(model);
                await db.SaveChangesAsync();
                return Success("添加成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<JsonResultObj> Delete(int? id) {
            try {
                if (id != null) {
                    var model = await db.Goods.SingleOrDefaultAsync(p => p.ID == id);
                    if (model != null) {
                        db.Goods.Remove(model);
                        await db.SaveChangesAsync();
                    }
                }
                return Success("删除成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<Goods> Detail(int? id, bool includeCategorys = false) {
            if (id == null || id <= 0) {
                return null;
            }
            var query = db.Goods.AsQueryable();
            if (includeCategorys) {
                query = query.Include(p => p.GoodsCategory);
            }
            var goods = await query.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            return goods;
        }

        public async Task<JsonResultObj> Edit(Goods model) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Name;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
                model.UpdateTime = DateTime.Now;
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Name).IsModified = true;
                db.Entry(model).Property(p => p.NameEn).IsModified = true;
                db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                db.Entry(model).Property(p => p.Price).IsModified = true;
                db.Entry(model).Property(p => p.Stock).IsModified = true;
                db.Entry(model).Property(p => p.Status).IsModified = true;
                db.Entry(model).Property(p => p.Keywords).IsModified = true;
                db.Entry(model).Property(p => p.Description).IsModified = true;
                db.Entry(model).Property(p => p.Content).IsModified = true;
                db.Entry(model).Property(p => p.MContent).IsModified = true;
                db.Entry(model).Property(p => p.Sort).IsModified = true;

                //先获取商品分类关系
                //var goodsCategory = db.GoodsCategory.Include(p => p.Category).FirstOrDefault(p => p.GoodsID == model.ID && p.CategoryID == 16);

                //如果关系不存在的话，那么要新建
                //if (goodsCategory == null) {
                //    //先获取分类
                //    var category = db.Category.FirstOrDefault(p => p.ID == 16);
                //    //如果连分类都不存在，那么还谈什么商品与分类的关系？直接报错！
                //    if (category == null) {
                //        return Error("分类不存在！");
                //    }

                //    //新建一个分类关系
                //    goodsCategory = new GoodsCategory {
                //        GoodsID = model.ID,
                //        CategoryID = category.ID
                //    };
                //}
                //取出本商品就的分类关系集合
                var oldGCs = db.GoodsCategory.Where(p => p.GoodsID == model.ID).ToList();
                //定义一个集合，存放即将要写入的分类关系
                //var newGCs = new List<GoodsCategory>();

                //我想通过移除全部旧的然后再插入新的，这样不行，居然报错了，因此我只能写代码对比新旧集合了 - -！
                //db.GoodsCategory.RemoveRange(oldGCs);

                //然后添加新的分类关系
                //newGCs.Add(goodsCategory);

                //获取所有父类，并且把所有父类结点都加进去
                //var parGC = await GetParentCategorys(goodsCategory.Category.ParID);
                //if (parGC != null) {
                //    foreach (var item in parGC) {
                //        newGCs.Add(new GoodsCategory {
                //            GoodsID = model.ID,
                //            CategoryID = item.ID
                //        });
                //    }
                //}

                oldGCs.ForEach(p => {
                    //找一找看看旧的集合里面有没有跟新的集合一样的值，如果有，那么就不用动
                    var existItem = model.GoodsCategory.FirstOrDefault(q => q.CategoryID == p.CategoryID);

                    //如果旧的集合里面有，但是新的没有的话，说明这个老东西要删了
                    if (existItem == null) {
                        db.GoodsCategory.Remove(p);
                    }
                    else {
                        //不然就把新集合里面的移除掉，后面剩下的就是纯粹要插入的了
                        model.GoodsCategory.Remove(existItem);
                    }
                });

                //比对完之后,剩下的就是纯粹要插入的了，那么直接插入即可
                if (model.GoodsCategory.Count > 0) {
                    db.GoodsCategory.AddRange(model.GoodsCategory);
                }
                await db.SaveChangesAsync();
                return Success("修改成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<PageList<Goods>> List(PageInfo pageInfo, int categoryID, string keyword, string sortBy) {
            var query = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) || p.NameEn.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
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
            return await PageList<Goods>.CreateAsync(query, pageInfo);
        }

        #region 商品分类相关
        public async Task<JsonResultObj> CategoryAdd(Category model) {
            model.AddTime = DateTime.Now;
            if (model.ParID == 0) {
                model.Level = 1;
            }
            else {
                var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                if (parent == null) {
                    return Error("父结点不存在！");
                }
                model.Level = parent.Level + 1;
            }
            db.Category.Add(model);
            await db.SaveChangesAsync();
            return Success("添加成功！");
        }

        public async Task<JsonResultObj> CategoryDelete(int? id) {
            try {
                if (id == null) {
                    return Success("删除成功！");
                }
                var model = await db.Category.SingleOrDefaultAsync(p => p.ID == id);
                if (model != null) {
                    db.Category.Remove(model);
                    await db.SaveChangesAsync();
                }
                return Success("删除成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<Category> CategoryDetail(int? id) {
            if (id == null || id <= 0) {
                return null;
            }
            var model = await db.Category.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            return model;
        }

        public async Task<JsonResultObj> CategoryEdit(Category model) {
            try {
                if (model.ParID == 0) {
                    model.Level = 1;
                }
                else {
                    var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                    if (parent == null) {
                        return Error("父结点不存在！");
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
                return Success("更新成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<List<Category>> CategoryList() {
            return await db.Category.ToAsyncEnumerable().ToList();
        }
        #endregion
    }
}
