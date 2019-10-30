using System;

namespace TengoDotNetCore.Models.Base {

    /// <summary>
    /// 基础的Model，包含一些公用的属性，比如主键Id、添加时间和修改时间
    /// </summary>
    public abstract class BaseModel {
        /// <summary>
        /// 无论什么Model，都要有主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// 添加了这个属性，意味着当这一行数据在插入或修改时，都会自动变化，再也不用手动赋值了
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
