using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Service {
    public interface IArticleCategoryService : IEntityService<ArticleCategory> {
        Task<List<ArticleCategory>> List();
    }
}
