using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service.Impl {
    public class ArticleService : IArticleService {
        private readonly TengoDbContext db;

        public ArticleService(TengoDbContext db) {
            this.db = db;
        }

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public async Task<PageList<Article>> List(PageInfo pageInfo, string sortBy) {
            var query = db.Articles.AsQueryable();
            switch (sortBy) {
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
            var article = await db.Articles.ToAsyncEnumerable().FirstOrDefault(p => p.ID == ID);
            return article;
        }

        public async Task<int> Edit(Article model) {
            db.Entry(model).Property(p => p.Title).IsModified = true;
            db.Entry(model).Property(p => p.Author).IsModified = true;
            db.Entry(model).Property(p => p.Status).IsModified = true;
            return await db.SaveChangesAsync();
        }

        public Task<int> Add(Article model) {
            db.Articles.Add(model);
            return db.SaveChangesAsync();
        }
    }
}
