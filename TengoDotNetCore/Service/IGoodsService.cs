using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IGoodsService {
        /// <summary>
        /// 通过ID获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Goods> Detail(int? id, bool includeCategorys = false);

        /// <summary>
        /// 修改更新一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Edit(Goods model);

        /// <summary>
        /// 添加一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Add(Goods model);

        /// <summary>
        /// 通过id删除一个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResultObj> Delete(int? id);

        /// <summary>
        /// 筛选商品列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="categoryID"></param>
        /// <param name="keyword"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<PageList<Goods>> List(PageInfo pageInfo, int categoryID, string keyword, string sortBy);


        /// <summary>
        /// 通过ID获取分类详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> CategoryDetail(int? id);

        /// <summary>
        /// 修改更新一个分类Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> CategoryEdit(Category model);

        /// <summary>
        /// 添加一个分类Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> CategoryAdd(Category model);

        /// <summary>
        /// 通过id删除一个分类Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResultObj> CategoryDelete(int? id);

        Task<List<Category>> CategoryList();
    }
}
