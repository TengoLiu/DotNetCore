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
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class OrderService : BaseService<Order> {

        public OrderService(TengoDbContext db) : base(db) { }

        public override async Task<Order> Get(Expression<Func<Order, bool>> where, params Expression<Func<Order, Property>>[] includes) {
            return await CreateQueryable(db.Orders, where, includes).FirstOrDefaultAsync();
        }

        public override async Task<List<Order>> GetList(Expression<Func<Order, bool>> where, params Expression<Func<Order, Property>>[] includes) {
            return await CreateQueryable(db.Orders, where, includes).ToListAsync();
        }

        public override async Task<List<Order>> GetList(Expression<Func<Order, bool>> where, int rowCount, params Expression<Func<Order, Property>>[] includes) {
            return await CreateQueryable(db.Orders, where, includes).Take(rowCount).ToListAsync();
        }

        public override async Task<PageList<Order>> GetPageList(int page, int pageSize, Expression<Func<Order, bool>> where, params Expression<Func<Order, Property>>[] includes) {
            return await CreatePageAsync(CreateQueryable(db.Orders, where, includes), page, pageSize);
        }





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