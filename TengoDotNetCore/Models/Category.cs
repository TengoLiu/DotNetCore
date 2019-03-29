using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 商品的分类，树形结构
    /// </summary>
    public class Category : BageTreeNode {

        /// <summary>
        /// 分类对应的商品
        /// </summary>
        public virtual List<GoodsCategory> GoodsCategory { get; set; }
    }
}
