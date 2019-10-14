using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Data {
    /// <summary>
    /// 分页查询工具类
    /// </summary>
    public class PageUtils {
        /// <summary>
        /// 执行读取分页的数据
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageInfo">分页信息</param>
        /// <returns></returns>
        public static async Task<PageList<T>> CreatePageAsync<T>(IQueryable<T> query, PageInfo pageInfo) {
            return await CreatePageAsync(query, pageInfo.Page, pageInfo.PageSize);
        }

        /// <summary>
        /// 执行读取分页的数据
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="page">查询的页码</param>
        /// <param name="pageSize">页长</param>
        /// <returns></returns>
        public static async Task<PageList<T>> CreatePageAsync<T>(IQueryable<T> query, int page, int pageSize) {
            if (page <= 0) {
                page = 1;
            }
            if (pageSize <= 0) {
                pageSize = 10;
            }
            var data = new PageList<T>(page, pageSize);
            data.Page = page;
            data.PageSize = pageSize;
            data.Total = await query.CountAsync();
            data.DataList = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return data;
        }
    }
}
