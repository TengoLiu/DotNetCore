using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Data {
    /// <summary>
    /// Db扩展类。例如扩展添加分页的筛选方法
    /// </summary>
    public static class DbExtensions {

        #region 扩展DbContext添加分页方法
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this DbContext context, IQueryable<T> query, PageInfo pageInfo) {
            return GetPageList(context, query, pageInfo.Page, pageInfo.PageSize);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this DbContext context, IQueryable<T> query, int page, int pageSize) {
            if (page <= 0) {
                page = 1;
            }
            if (pageSize <= 0) {
                pageSize = 10;
            }
            var data = new PageList<T>(page, pageSize);
            data.Page = page;
            data.PageSize = pageSize;
            data.Total = query.Count();
            data.DataList = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return data;
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public static async Task<PageList<T>> GetPageListAsync<T>(this DbContext context, IQueryable<T> query, PageInfo pageInfo) {
            return await GetPageListAsync(context, query, pageInfo.Page, pageInfo.PageSize);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PageList<T>> GetPageListAsync<T>(this DbContext context, IQueryable<T> query, int page, int pageSize) {
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
        #endregion
    }
}
