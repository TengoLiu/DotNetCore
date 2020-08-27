using System;
using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Models.Admin {
    public class Manager : BaseModel {
        public string Password { get; set; }

        public int Status { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; }

        public string LastLoginIP { get; set; }

        public DateTime LastLoginTime { get; set; }


        [ForeignKey("RoleId")]
        public virtual ManagerRole ManagerRole { get; set; }
    }
}
