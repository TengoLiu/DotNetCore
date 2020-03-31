namespace TengoDotNetCore.Common.BaseModels {
    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageInfo {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 每页的长度
        /// </summary>
        public int PageSize { get; set; }
    }
}
