using System.ComponentModel.DataAnnotations.Schema;

namespace TengoDotNetCore.Models.Admin {
    public class ManagerRole_ManagerPermission {
        public int ManagerRoleId { get; set; }

        public int ManagerPermissionId { get; set; }

        [ForeignKey("ManagerRoleId")]
        public virtual ManagerRole ManagerRole { get; set; }

        [ForeignKey("ManagerPermissionId")]
        public virtual ManagerPermission ManagerPermission { get; set; }
    }
}
