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

        public async Task<Order> Get(int id, bool getGoods = false) {
            var query = db.Orders.AsQueryable();
            if (getGoods) {
                query = query.Include(p => p.GoodsList);
            }
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }


        /// <summary>
        /// 获取用户的订单列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> List(PageInfo pageInfo, int userId) {
            var query = db.Orders.Include(p => p.GoodsList).Where(p => p.UserID == userId);
            return JsonResultSuccess("success", await CreatePageAsync(query, pageInfo));
        }

        public async Task<JsonResultObj> Save(int addrId, string message = "") {
            return new JsonResultObj();
        }

        /// <summary>
        /// 获取订单填写页面的数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> GetEditData(int userId) {
            var cartList = new List<object>();

            foreach (var item in db.CartItem.Include(p => p.Goods)) {
                cartList.Add(new {
                    item.Goods.Id,
                    item.Goods.Name,
                    item.Goods.NameEn,
                    item.Goods.Price,
                    item.Goods.CoverImg,
                    item.Qty
                });
            };

            var addrList = await db.Address.Where(p => p.User_ID == userId).ToListAsync();
            return JsonResultSuccess("success", new {
                cartList,
                addrList
            });
        }
    }
}