using TengoDotNetCore.Common;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    public class BaseController : MyControllerBase {

        public BaseController(TengoDbContext db) : base(db) { }
    }
}
