using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleService {
        Task<PageList<Article>> List(PageInfo pageInfo, string keyword, string sortBy);

        Task<Article> Detail(int? id);

        Task<int> Edit(Article model);

        Task<int> Add(Article model);

        Task<int> Delete(int? id);
    }
}
