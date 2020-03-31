using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.BLL {
    public class ColumnBLL : BaseBLL {
        public ColumnBLL(TengoDbContext db) : base(db) { }

        public async Task<JsonResultObj> Insert(ColumnType model) {
            db.ColumnType.Add(model);
            await db.SaveChangesAsync();
            return JsonResultSuccess("添加成功！");
        }
    }
}
