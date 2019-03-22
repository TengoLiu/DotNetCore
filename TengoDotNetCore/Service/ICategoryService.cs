using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface ICategoryService {
        /// <summary>
        /// 通过ID获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> Detail(int? id);

        /// <summary>
        /// 修改更新一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Edit(Category model);

        /// <summary>
        /// 添加一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<JsonResultObj> Add(Category model);

        /// <summary>
        /// 通过id删除一个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResultObj> Delete(int? id);

        Task<List<Category>> List();
    }
}
