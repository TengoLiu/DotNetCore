using System.ComponentModel.DataAnnotations;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 文章对应的栏目分类
    /// </summary>
    public class ArticleCategory : BaseModel {

        [Required, MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
