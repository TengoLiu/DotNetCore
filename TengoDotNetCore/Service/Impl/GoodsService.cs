using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<int> Add(Goods model) {
            db.Goods.Add(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int? id) {
            if (id == null) {
                return 1;
            }
            var model = await db.Goods.SingleOrDefaultAsync(p => p.ID == id);
            if (model != null) {
                db.Goods.Remove(model);
                return await db.SaveChangesAsync();
            }
            return 1;
        }

        public async Task<Goods> Detail(int? id) {
            if (id == null || id <= 0) {
                return null;
            }
            var goods = await db.Goods.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            return goods;
        }

        public async Task<int> Edit(Goods model) {
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
            db.Entry(model).Property(p => p.UpdateTime).IsModified = true;
            db.Entry(model).Property(p => p.Sort).IsModified = true;
            return await db.SaveChangesAsync();
        }

        public async Task<PageList<Goods>> List(PageInfo pageInfo, string keyword, string sortBy) {
            var query = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) || p.NameEn.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
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
            return await PageList<Goods>.CreateAsync(query, pageInfo);
        }
    }
}
