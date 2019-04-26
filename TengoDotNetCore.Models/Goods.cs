using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 商品的实体类
    /// </summary>
    public class Goods : BaseModel {

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "名称是必填的"), MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 外文名称
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 商品的图册列表，一堆图片，用逗号隔开
        /// </summary>
        public string Albums { get; set; }

        /// <summary>
        /// PC端商品详情
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 移动端的商品详情
        /// </summary>
        public string MContent { get; set; }

        /// <summary>
        /// 价格
        /// 由于如果不指定[Column(TypeName = "decimal(18, 2)")]的话
        /// 则默认是decimal(18, 2)，实际上可以根据需要来指定在数据库中的类型
        /// </summary>
        [Required(ErrorMessage = "价格是必填的！")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [Required]
        [Range(0, 99999)]
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
        /// 获取商品状态的名称
        /// </summary>
        /// <returns></returns>
        public static string GetStatus(Goods model) {
            switch (model.Status) {
                case 1:
                    return "正常销售";
                case 2:
                    return "销售不展示";
                case 3:
                    return "已下架";
                case 4:
                    return "待审核";
                default:
                    return "待审核";
            }
        }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// SEO关键词
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 存放商品分类的Json
        /// 还是不要做多对多关系吧，
        /// 因为如果那样做的话，查询会非常地麻烦，并且消耗性能
        /// 比如要多选的时候，如果是通过中间表来查，同一条记录，由于关系的变化，还会出现多次
        /// </summary>
        public string CategoryIdStr { get; set; }

        public string CategoryStr { get; set; }

        /// <summary>
        /// 商品的分类列表
        /// </summary>
        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}
