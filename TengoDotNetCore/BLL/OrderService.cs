using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.BLL {
    public class OrderService : BaseBLL {

        public OrderService(TengoDbContext db) : base(db) { }

        public async Task<Order> Get(int id, bool getGoods = false) {
            var query = db.Orders.AsQueryable();
            if (getGoods) {
                query = query.Include(p => p.GoodsList);
            }
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<JsonResultObj> Save(int userId, int addrId, string message = "") {
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