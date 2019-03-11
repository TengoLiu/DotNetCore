﻿using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleService : IEntityService<Article> {
        Task<PageList<Article>> List(PageInfo pageInfo, string keyword, string sortBy);
    }
}
