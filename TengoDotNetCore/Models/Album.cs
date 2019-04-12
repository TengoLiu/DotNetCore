using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 图册，包含原图、各个尺寸的缩略图
    /// </summary>
    public class Album : BaseModel {

        /// <summary>
        /// 原图地址
        /// </summary>
        public string OriginalPath { get; set; }
    }
}
