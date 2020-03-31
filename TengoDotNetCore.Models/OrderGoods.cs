using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 订单商品的Model
    /// </summary>
    public class OrderGoods : BaseModel {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 商品对应的订单实体
        /// </summary>
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 商品名称，就不写英文名称了，如果有的话，直接拼接进来就好了
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrginalPrice { get; set; }

        /// <summary>
        /// 分摊了各种优惠之后商品的价格
        /// </summary>
        [Column(TypeName = "decimal(18, 5)")]
        public decimal RealPrice { get; set; }

        /// <summary>
        /// 商品封面图
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string Specifications { get; set; }
    }
}
