using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.BLL {
    public class OrderBLL : BaseBLL {

        public OrderBLL(TengoDbContext db) : base(db) { }

        public async Task<JsonResultObj> Save(int userId, int addrId, string message = "") {
            return new JsonResultObj();
        }
    }
}