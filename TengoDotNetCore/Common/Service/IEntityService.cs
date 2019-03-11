using System.Threading.Tasks;

namespace TengoDotNetCore.Common.Service {

    /// <summary>
    /// 涉及到实体Model的Service必备的一些基础增删改查方法
    /// 注：如果是一些不涉及到实体的Model的话，就不需要继承此接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityService<T> {
        /// <summary>
        /// 通过ID获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Detail(int? id);

        /// <summary>
        /// 修改更新一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> Edit(T model);

        /// <summary>
        /// 添加一个Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> Add(T model);

        /// <summary>
        /// 通过id删除一个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int? id);
    }
}
