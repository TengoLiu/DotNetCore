using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Category : BaseModel {
        /// <summary>
        /// 父结点的ID
        /// </summary>
        public int ParID { get; set; }

        /// <summary>
        /// 分类的级别
        /// 这个字段，可以说是冗余的，但是却可以辅助一下来获取某一个级别的数据
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 分类对应的商品
        /// </summary>
        public virtual ICollection<GoodsCategory> GoodsCategory { get; set; }
    }
}
