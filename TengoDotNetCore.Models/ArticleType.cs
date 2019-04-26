using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 文章对应的栏目分类
    /// </summary>
    public class ArticleType : BaseModel {

        [Required, MaxLength(50)]
        public string TypeName { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }

        public virtual List<Article> Articles { get; set; }
    }
}
