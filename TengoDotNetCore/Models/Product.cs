using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Product : BaseModel {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }

        /// <summary>
        /// 价格
        /// 由于如果不指定[Column(TypeName = "decimal(18, 2)")]的话
        /// 则默认是decimal(18, 2)，实际上可以根据需要来指定在数据库中的类型
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

    }
}
