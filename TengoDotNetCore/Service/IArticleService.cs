using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleService : IEntityService<Article> {
        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="keyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="includeCategory">是否要读取关联属性-文章分类</param>
        /// <returns></returns>
        Task<PageList<Article>> List(PageInfo pageInfo, string keyword, string sortBy,bool includeCategory);
    }
}
