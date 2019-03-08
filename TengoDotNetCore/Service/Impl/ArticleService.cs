﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Abs;

namespace TengoDotNetCore.Service.Impl {
    public class ArticleService : AbsService, IArticleService {
        private readonly TengoDbContext db;

        public ArticleService(TengoDbContext db) {
            this.db = db;
        }

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public async Task<PageList<Article>> List(PageInfo pageInfo, string keyword, string sortBy) {
            var query = db.Article.AsQueryable();
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

        public async Task<Article> Detail(int? ID) {
            if (ID == null || ID <= 0) {
                return null;
            }
            var article = await db.Article.ToAsyncEnumerable().FirstOrDefault(p => p.ID == ID);
            return article;
        }

        public async Task<int> Edit(Article model) {
            db.Entry(model).Property(p => p.Title).IsModified = true;
            db.Entry(model).Property(p => p.Author).IsModified = true;
            db.Entry(model).Property(p => p.Status).IsModified = true;
            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(Article model) {
            db.Article.Add(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int? id) {
            if (id == null) {
                return 1;
            }
            var article = await db.Article.SingleOrDefaultAsync(p => p.ID == id);
            if (article != null) {
                db.Article.Remove(article);
                return await db.SaveChangesAsync();
            }
            return 1;
        }
    }
}
