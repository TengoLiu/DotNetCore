using System.ComponentModel.DataAnnotations;

namespace TengoDotNetCore.Common.BaseModels {
    /// <summary>
    /// 树形结构分类的基类
    /// 所有符合树形结构的分类都可以继承此类，以拥有一些共通的属性
    /// </summary>
    public class BageTreeNode : BaseModel {
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
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称是必填的")]
        public string Name { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }
    }
}
