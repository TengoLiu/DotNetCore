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
    public class CommonService : BaseService {
        public CommonService(TengoDbContext db) : base(db) { }

        public async Task<Dictionary<string, object>> GetHomeIndexViewModel() {
            var dic = new Dictionary<string, object>();
            dic["Banners"] = await db.Article
                                    .Where(p => p.ArticleType_Id == 4)
                                    .Take(10)
                                    .ToListAsync();
            dic["Goods"] = await db.Goods
                                    .Where(p => p.Status == 1)
                                    .OrderBy(p => Guid.NewGuid())
                                    .Take(60)
                                    .ToListAsync();
            return dic;
        }
    }
}
