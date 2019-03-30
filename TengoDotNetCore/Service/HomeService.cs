using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Service.Abs;

namespace TengoDotNetCore.Service {
    public class HomeService : AbsService {
        public HomeService(TengoDbContext db) : base(db) {
        }

        public async Task<IDictionary<string, object>> GetIndex() {
            var dicRes = new Dictionary<string, object>();
            dicRes["banners"] = await db.Article.ToAsyncEnumerable().Where(p => p.CategoryID == 4).Take(10).ToList();
            dicRes["goods"] = await db.Goods.ToAsyncEnumerable().Where(p => p.Status == 1).OrderBy(p => Guid.NewGuid()).Take(60).ToList();
            return dicRes;
        }
    }
}
