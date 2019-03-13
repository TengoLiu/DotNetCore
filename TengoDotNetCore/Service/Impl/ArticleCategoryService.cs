using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service.Abs;

namespace TengoDotNetCore.Service.Impl {
    public class ArticleCategoryService : AbsService, IArticleCategoryService {

        public ArticleCategoryService(TengoDbContext db) : base(db) {
        }

        public async Task<List<ArticleCategory>> List() {
            return await db.ArticleCategory.ToListAsync();
        }

        public async Task<int> Add(ArticleCategory model) {
            db.ArticleCategory.Add(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int? id) {
            if (id == null) {
                return 1;
            }
            var model = await db.ArticleCategory.SingleOrDefaultAsync(p => p.ID == id);
            if (model != null) {
                db.ArticleCategory.Remove(model);
                return await db.SaveChangesAsync();
            }
            return 1;
        }

        public async Task<ArticleCategory> Detail(int? ID) {
            if (ID == null || ID <= 0) {
                return null;
            }
            var model = await db.ArticleCategory.ToAsyncEnumerable().FirstOrDefault(p => p.ID == ID);
            return model;
        }

        public async Task<int> Edit(ArticleCategory model) {
            db.Entry(model).Property(p => p.Title).IsModified = true;
            db.Entry(model).Property(p => p.CoverImg).IsModified = true;
            db.Entry(model).Property(p => p.Sort).IsModified = true;
            return await db.SaveChangesAsync();
        }
    }
}
