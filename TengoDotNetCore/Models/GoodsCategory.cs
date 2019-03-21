using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Models {
    public class GoodsCategory {
        public int GoodsID { get; set; }
        public Goods Goods { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
