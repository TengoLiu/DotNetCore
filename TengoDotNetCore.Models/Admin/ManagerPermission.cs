using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.Models.Admin {
    public class ManagerPermission : BaseModel {
        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public PermissionType PermissionType { get; set; }

        /// <summary>
        /// 从根节点到当前结点的路径，序列化成json
        /// </summary>
        public string RoutePathList { get; set; }

        public int Sort { get; set; }
    }

    public enum PermissionType {
        MenuTitle,
        Menu,
        ChildPage,
        Interface
    }
}
