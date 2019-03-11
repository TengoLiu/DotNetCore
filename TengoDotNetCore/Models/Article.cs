using System.ComponentModel.DataAnnotations;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Article : BaseModel {
        [Required(ErrorMessage = "标题是必填的"), MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 文章分类
        /// </summary>
        public ArticleCategory Category { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// PC端详情
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 移动端的详情
        /// </summary>
        public string MContent { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required(ErrorMessage = "作者是必填的"), MaxLength(50)]
        public string Author { get; set; }
        /// <summary>
        /// SEO关键词
        /// </summary>
        [MaxLength(128)]
        public string Keywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// 状态
        /// 0：待审核，也就是404错误
        /// 1：正常显示
        /// 2：不会在列表页出现，但是可以直接查看详情
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }
    }
}
