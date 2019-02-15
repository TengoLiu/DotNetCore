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
        public PageList(PageInfo pageInfo) {
            this.Page = pageInfo.Page;
            this.PageSize = pageInfo.PageSize;
        }

        //所有数据的总数
        public long Total { get; set; }
        //当前页的数据
        public List<T> DataList { get; set; }
    }
}
