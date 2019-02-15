using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class CartItem : BaseModel {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public bool Selected { get; set; }
    }
}
