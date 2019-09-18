using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// 插入对象时执行一些共通操作，目前仅设置一下插入时间和更新时间
        /// </summary>
        public void DoBeforeInsert() {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 更新对象时执行一些共通的操作，目前仅设置一下更新时间
        /// </summary>
        public void DoBeforeUpdate() {
            AddTime = DateTime.Now;
        }

    }
}
