using System.Collections.Generic;

namespace TengoDotNetCore.Common.BaseModels {
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
        public PageList() {
            DataList = new List<T>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page">查询的页码</param>
        /// <param name="pageSize">页长</param>
        public PageList(int page, int pageSize) {
            this.Page = page;
            this.PageSize = pageSize;
            DataList = new List<T>();
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

        
    }
}
