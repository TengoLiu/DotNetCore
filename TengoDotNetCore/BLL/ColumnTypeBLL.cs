using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.BLL {
    public class ColumnTypeBLL : BaseBLL {
        public ColumnTypeBLL(TengoDbContext db) : base(db) { }

        public async Task<JsonResultObj> Insert(ColumnType model) {
            db.ColumnType.Add(model);
            await db.SaveChangesAsync();
            return JsonResultSuccess("添加成功！");
        }
    }
}
