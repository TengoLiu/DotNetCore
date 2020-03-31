using System.ComponentModel.DataAnnotations;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Models {
    public class ColumnType : BaseModel {
        /// <summary>
        /// 类别名称
        /// </summary>
        [Required(ErrorMessage = "类别名称是必填的")]
        public string TypeName { get; set; }
    }
}