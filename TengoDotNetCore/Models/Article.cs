using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {

    public class Article : BaseModel {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImg { get; set; }

        public string Content { get; set; }

        public string MContent { get; set; }
        /// <summary>
        /// 状态，1正常显示，2不显示但可正常访问，3待审核
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 排序，排序越大越靠前
        /// </summary>
        public int Sort { get; set; }
    }
}
