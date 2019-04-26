using System.ComponentModel.DataAnnotations.Schema;

namespace TengoDotNetCore.Models {
    public class GoodsCategory {
        /// <summary>
        /// Goods外键
        /// </summary>
        public int Goods_ID { get; set; }
        
        [ForeignKey("Goods_ID")]
        public Goods Goods { get; set; }

        /// <summary>
        /// Category外键
        /// </summary>
        public int Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public Category Category { get; set; }
    }
}
