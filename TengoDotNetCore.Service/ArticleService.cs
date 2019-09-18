using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class ArticleService : BaseService<Article> {

        public ArticleService(TengoDbContext db) : base(db) { }

        public override async Task<Article> Get(Expression<Func<Article, bool>> where, params Expression<Func<Article, Property>>[] includes) {
            return await CreateQueryable(db.Article, where, includes).FirstOrDefaultAsync();
        }

        public override async Task<List<Article>> GetList(Expression<Func<Article, bool>> where, params Expression<Func<Article, Property>>[] includes) {
            return await CreateQueryable(db.Article, where, includes).ToListAsync();
        }

        public override async Task<List<Article>> GetList(Expression<Func<Article, bool>> where, int rowCount, params Expression<Func<Article, Property>>[] includes) {
            return await CreateQueryable(db.Article, where, includes).Take(rowCount).ToListAsync();
        }

        public override async Task<PageList<Article>> GetPageList(int page, int pageSize, Expression<Func<Article, bool>> where, params Expression<Func<Article, Property>>[] includes) {
            return await CreatePageAsync(CreateQueryable(db.Article, where, includes), page, pageSize);
        }


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
                model.DoBeforeInsert();
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
                model.DoBeforeUpdate();
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
            return await CreatePageAsync(query, pageInfo);
        }
        #endregion
    }
}
