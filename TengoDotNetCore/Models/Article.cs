using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {

    public class Article : BaseModel {
        [Required, MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// PC端商品详情
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 移动端的商品详情
        /// </summary>
        public string MContent { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Required, MaxLength(50)]
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
        /// 状态，1正常显示，2不显示但可正常访问，3待审核
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
