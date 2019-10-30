using System.ComponentModel.DataAnnotations.Schema;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 购物车商品条目
    /// </summary>
    public class CartItem {

        /// <summary>
        /// User的外键
        /// </summary>
        public int User_Id { get; set; }

        /// <summary>
        /// 用户详情
        /// </summary>
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }

        /// <summary>
        /// Goods的外键
        /// </summary>
        public int Goods_ID { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [ForeignKey("Goods_ID")]
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected { get; set; }
    }
}
