using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Address : BaseModel {
        /// <summary>
        /// User外键
        /// </summary>
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
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
