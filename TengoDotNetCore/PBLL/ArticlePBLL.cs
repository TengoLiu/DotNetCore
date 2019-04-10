using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.PBLL.Base;

namespace TengoDotNetCore.PBLL {
    public class ArticlePBLL : BasePBLL {

        public ArticlePBLL(TengoDbContext db) : base(db) {}

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo">分页信息，封装了页码以及页长凳</param>
        /// <param name="keyword">关键词</param>
        /// <param name="sortBy">排序条件</param>
        /// <returns></returns>
        public async Task<PageList<Article>> PageList(PageInfo pageInfo, int categoryID, string keyword, string sortBy, bool includeCategory) {
            var query = db.Article.AsQueryable();
            if (categoryID > 0) {
                query = query.Where(p => p.CategoryID == categoryID);
            }
            if (includeCategory) {
                query = query.Include("Category");
            }
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Title.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) || p.Author.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(sortBy))
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
            return await PageList<Article>.CreateAsync(query, pageInfo);
        }

        #region 商品分类相关
        public async Task<List<ArticleCategory>> CategoryList() {
            return await db.ArticleCategory.ToListAsync();
        }

        public async Task<PageList<ArticleCategory>> CategoryPageList(PageInfo pageInfo, string keyword) {
            var query = db.ArticleCategory.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Title.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            return await PageList<ArticleCategory>.CreateAsync(query, pageInfo);
        }
        #endregion
    }
}
