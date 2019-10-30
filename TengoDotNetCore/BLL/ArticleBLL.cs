using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.BLL {
    public class ArticleBLL : BaseBLL {

        public ArticleBLL(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Insert(Article model) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Title + "," + model.Author;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
                db.Article.Add(model);
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
        public async Task<JsonResultObj> Update(Article model) {
            try {
                if (string.IsNullOrWhiteSpace(model.Keywords)) {
                    model.Keywords = model.Title + "," + model.Author;
                }
                if (string.IsNullOrWhiteSpace(model.Description)) {
                    model.Description = model.Keywords;
                }
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Title).IsModified = true;
                db.Entry(model).Property(p => p.Author).IsModified = true;
                db.Entry(model).Property(p => p.ArticleType_Id).IsModified = true;
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Delete(int? id) {
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

        #region 商品分类相关
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> UpdateArticleType(ArticleType model) {
            try {
                db.Entry(model).Property(p => p.TypeName).IsModified = true;
                db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                db.Entry(model).Property(p => p.Sort).IsModified = true;
                await db.SaveChangesAsync();
                return JsonResultSuccess("更新成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> InsertArticleType(ArticleType model) {
            try {
                db.ArticleType.Add(model);
                await db.SaveChangesAsync();
                return JsonResultSuccess("添加成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        public async Task<JsonResultObj> DeleteArticleType(int? id) {
            try {
                if (id == null) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.ArticleType.SingleOrDefaultAsync(p => p.Id == id);
                if (model != null) {
                    db.ArticleType.Remove(model);
                    await db.SaveChangesAsync();
                }
                return JsonResultSuccess("删除成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        public async Task<List<ArticleType>> ArticleTypeList() {
            return await db.ArticleType.ToListAsync();
        }

        public async Task<PageList<ArticleType>> CategoryPageList(PageInfo pageInfo, string keyword) {
            var query = db.ArticleType.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.TypeName.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            return await db.GetPageListAsync(query, pageInfo);
        }
        #endregion
    }
}
