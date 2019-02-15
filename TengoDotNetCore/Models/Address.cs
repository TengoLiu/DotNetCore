using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Address : BaseModel {
        public int Id { get; set; }
        public User User { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
        public string Tag { get; set; }
        public bool IsDefault { get; set; }
    }
}
