using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IArticleCategoryService  {
        /// <summary>
        /// 通过ID获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleCategory> Detail(int? id);

        /// <summary>
        /// 修改更新一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Edit(ArticleCategory model);

        /// <summary>
        /// 添加一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Add(ArticleCategory model);

        /// <summary>
        /// 通过id删除一个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResultObj> Delete(int? id);

        Task<List<ArticleCategory>> List();

        Task<PageList<ArticleCategory>> PageList(PageInfo pageInfo, string keyword);
    }
}
