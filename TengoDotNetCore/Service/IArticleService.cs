using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleService {
        /// <summary>
        /// 通过ID获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Article> Detail(int? id);

        /// <summary>
        /// 修改更新一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Edit(Article model);

        /// <summary>
        /// 添加一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Add(Article model);

        /// <summary>
        /// 通过id删除一个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResultObj> Delete(int? id);

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="keyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="includeCategory">是否要读取关联属性-文章分类</param>
        /// <returns></returns>
        Task<PageList<Article>> List(PageInfo pageInfo, int categoryID, string keyword, string sortBy,bool includeCategory);
    }
}
