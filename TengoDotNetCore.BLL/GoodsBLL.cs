using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.BLL {
    public class GoodsBLL : BaseBLL {

        public GoodsBLL(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Goods> Get(int id) {
            var model = await db.Goods.FirstOrDefaultAsync(p => p.Id == id);
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
                        var cty = await db.Category.FirstOrDefaultAsync(p => p.Id == cid);
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
                        var cty = await db.Category.FirstOrDefaultAsync(p => p.Id == cid);
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

        /// <summary>
        /// 筛选商品列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="categoryIDs"></param>
        /// <param name="keyword"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<PageList<Goods>> PageList(PageInfo pageInfo, List<int> categoryIDs, string keyword, string sortBy) {

            var query = db.Goods.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword)) {
                keyword = keyword.Trim();
                query = query.Where(p => p.Name.Contains(keyword) || p.NameEn.Contains(keyword));
            }
            //categoryIDs多选,先移除无意义的0
            if (categoryIDs != null && categoryIDs.Count > 0) {
                categoryIDs.RemoveAll(p => p <= 0);
            }
            //由于在数据库中商品的分类设计为 categoryId1,categoryId2...
            //因此现在还不方便做分类的筛选，或者说，还没发现有合适的方式来做
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
            return await db.GetPageListAsync(query, pageInfo);
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
                  .Take(take)
                  .ToListAsync();
        }


    }
}
