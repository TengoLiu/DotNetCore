using System;

namespace TengoDotNetCore.Models {
    public class DelGoods : Goods {
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
    }
}