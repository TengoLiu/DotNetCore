using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Models.Base {
    /// <summary>
    /// 分页数据列表
    /// </summary>
    /// <typeparam name="T">分页数据对应的类型</typeparam>
    public class PageList<T> : PageInfo {

        /// <summary>
        /// 所有数据的总数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 数据的总页数
        /// </summary>
        public long TotalPage {
            get {
                if (PageSize <= 0) {
                    return 0;
                }
                var mod = Total % PageSize;
                long cnt = Total / PageSize;
                return mod == 0 ? cnt : cnt + 1;
            }
        }

        //当前页的数据
        public List<T> DataList { get; set; }


        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page">查询的页码</param>
        /// <param name="pageSize">页长</param>
        public PageList(int page, int pageSize) {
            this.Page = page;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pageInfo">分页信息</param>
        public PageList(PageInfo pageInfo) {
            this.Page = pageInfo.Page;
            this.PageSize = pageInfo.PageSize;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page">查询的页码</param>
        /// <param name="pageSize">页长</param>
        /// <param name="total">所有数据的总数</param>
        /// <param name="dataList">当前页的数据</param>
        public PageList(int page, int pageSize, long total, List<T> dataList) {
            this.Page = page;
            this.PageSize = pageSize;
            this.Total = total;
            this.DataList = dataList;
        }
        #endregion

        /// <summary>
        /// 执行读取分页的数据
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageInfo">分页信息</param>
        /// <returns></returns>
        public static async Task<PageList<T>> CreateAsync(IQueryable<T> query, PageInfo pageInfo) {
            return await CreateAsync(query, pageInfo.Page, pageInfo.PageSize);
        }

        /// <summary>
        /// 执行读取分页的数据
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="page">查询的页码</param>
        /// <param name="pageSize">页长</param>
        /// <returns></returns>
        public static async Task<PageList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize) {
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
