using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Models.Base {

    /// <summary>
    /// 基础的Model，包含一些公用的属性，比如主键Id、添加时间和修改时间
    /// </summary>
    public class BaseModel {
        /// <summary>
        /// 无论什么Model，都要有主键Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
