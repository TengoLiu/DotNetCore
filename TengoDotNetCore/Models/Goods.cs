using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 商品的实体类
    /// </summary>
    public class Goods : BaseModel {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }

        /// <summary>
        /// 价格
        /// 由于如果不指定[Column(TypeName = "decimal(18, 2)")]的话
        /// 则默认是decimal(18, 2)，实际上可以根据需要来指定在数据库中的类型
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        /// <summary>
        /// 状态
        /// 1.正常显示并且可购买
        /// 2.不显示但可正常购买
        /// 3.已下架，即显示但不可购买
        /// 4.待审核，即404错误，不能看也不能购买
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }
    }
}
