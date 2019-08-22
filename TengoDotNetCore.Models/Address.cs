using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Common;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    public class Address : BaseModel {
        /// <summary>
        /// User外键
        /// </summary>
        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public User User { get; set; }

        [Required]
        [RegularExpression(Constant.REGEX_PHONE)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Detail { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        public string Tag { get; set; }

        public bool IsDefault { get; set; }
    }
}
