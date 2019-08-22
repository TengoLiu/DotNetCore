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
    public class ArticleService : BaseService {

        public ArticleService(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Article> Get(int id) {
            var model =await db.Article.FirstOrDefaultAsync(p => p.Id == id);
            return model;
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
                model.UpdateTime = DateTime.Now;
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

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo">分页信息，封装了页码以及页长凳</param>
        /// <param name="keyword">关键词</param>
        /// <param name="sortBy">排序条件</param>
        /// <returns></returns>
        public async Task<PageList<Article>> PageList(PageInfo pageInfo, int articleType_Id, string keyword, string sortBy, bool includeCategory) {
            var query = db.Article.AsQueryable();
            if (articleType_Id > 0) {
                query = query.Where(p => p.ArticleType_Id == articleType_Id);
            }
            if (includeCategory) {
                query = query.Include(p => p.ArticleType);
            }
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Title.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) || p.Author.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(sortBy))
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
            return await CreatePageAsync(query, pageInfo);
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
