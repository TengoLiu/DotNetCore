using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleCategoryService : IEntityService<ArticleCategory> {
        Task<List<ArticleCategory>> List();

        Task<PageList<ArticleCategory>> PageList(PageInfo pageInfo, string keyword);
    }
}
