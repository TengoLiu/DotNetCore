using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.PBLL.Base;

namespace TengoDotNetCore.PBLL {
    public class GoodsPBLL : BasePBLL {

        public GoodsPBLL(TengoDbContext db) : base(db) { }

        public async Task<PageList<Goods>> PageList(PageInfo pageInfo, int categoryID, List<int> categoryIDs, string keyword, string sortBy) {
            var query = db.Goods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase)
                || p.NameEn.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(sortBy)) {
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
            }
            if (categoryID > 0) {
                query = query.Where(p => p.GoodsCategory.Exists(q => q.CategoryID == categoryID));
            }
            if (categoryIDs != null && categoryIDs.Count > 0) {
                foreach (var item in categoryIDs) {
                    query = query.Where(p => p.GoodsCategory.Exists(q => q.CategoryID == item));
                }
            }
            return await PageList<Goods>.CreateAsync(query, pageInfo);
        }
    }
}
