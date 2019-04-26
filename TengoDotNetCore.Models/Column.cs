using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Column : BaseModel {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称是必填的")]
        public string Title { get; set; }

        /// <summary>
        /// ColumnType外键
        /// </summary>  
        public int ColumnType_Id { get; set; }

        /// <summary>
        /// 栏目类别
        /// </summary>
        [Display(Name = "栏目类别")]
        [ForeignKey("ColumnType_Id")]
        public virtual ColumnType ColumnType { get; set; }

        /// <summary>
        /// PC端封面图
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 移动端封面图
        /// </summary>
        public string MImgUrl { get; set; }

        /// <summary>
        /// PC跳转链接
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 移动端跳转链接
        /// </summary>
        public string MHref { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>  
        [Required(ErrorMessage = "状态是必填的")]
        public int Status { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序数字是必填的")]
        public int Sort { get; set; }

        /// <summary>
        /// 上线时间
        /// </summary>
        [Required(ErrorMessage = "上线时间是必填的")]
        public DateTime ValidStartTime { get; set; }

        /// <summary>
        /// 下线时间
        /// </summary>
        [Required(ErrorMessage = "下线时间是必填的")]
        public DateTime ValidEndTime { get; set; }

    }
}