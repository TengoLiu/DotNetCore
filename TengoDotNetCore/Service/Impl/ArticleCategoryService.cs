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
    public class ArticleCategoryService : AbsService, IArticleCategoryService {

        public ArticleCategoryService(TengoDbContext db) : base(db) {
        }

        public async Task<List<ArticleCategory>> List() {
            return await db.ArticleCategory.ToListAsync();
        }

        public async Task<JsonResultObj> Add(ArticleCategory model) {
            try {
                db.ArticleCategory.Add(model);
                await db.SaveChangesAsync();
                return Success("添加成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<JsonResultObj> Delete(int? id) {
            try {
                if (id == null) {
                    return Success("删除成功！");
                }
                var model = await db.ArticleCategory.SingleOrDefaultAsync(p => p.ID == id);
                if (model != null) {
                    db.ArticleCategory.Remove(model);
                    await db.SaveChangesAsync();
                }
                return Success("删除成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<ArticleCategory> Detail(int? ID) {
            if (ID == null || ID <= 0) {
                return null;
            }
            var model = await db.ArticleCategory.ToAsyncEnumerable().FirstOrDefault(p => p.ID == ID);
            return model;
        }

        public async Task<JsonResultObj> Edit(ArticleCategory model) {
            try {
                db.Entry(model).Property(p => p.Title).IsModified = true;
                db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                db.Entry(model).Property(p => p.Sort).IsModified = true;
                await db.SaveChangesAsync();
                return Success("更新成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<PageList<ArticleCategory>> PageList(PageInfo pageInfo, string keyword) {
            var query = db.ArticleCategory.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Title.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            return await PageList<ArticleCategory>.CreateAsync(query, pageInfo);
        }
    }
}
