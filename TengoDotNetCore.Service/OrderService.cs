using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class OrderService : BaseService {

        public OrderService(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 获取用户的订单列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> List(PageInfo pageInfo, int userId) {
            var query = db.Orders.Include(p=>p.GoodsList).Where(p => p.UserID == userId);
            return JsonResultSuccess("success", await CreatePageAsync(query, pageInfo));
        }

        public async Task<JsonResultObj> Save(int addrId, string message = "") {
            return new JsonResultObj();
        }
    }
}
