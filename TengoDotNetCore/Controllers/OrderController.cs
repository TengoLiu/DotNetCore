using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Controllers {
    public class OrderController : BaseController {

        #region Index 用户订单列表
        public IActionResult Index() {
            return View();
        }
        #endregion

        #region List 获取订单列表接口 api/order/list
        [Route("api/order/list")]
        public async Task<IActionResult> List([FromServices]TengoDbContext db, PageInfo pageInfo) {
            var list = await db.GetPageListAsync(db.Order.Include(p => p.GoodsList).Where(p => p.UserID == 1), pageInfo);
            return MyJsonResultSuccess("s", list);
        }
        #endregion

        #region Detail 订单详情页
        public IActionResult Detail(int orderId) {
            return View();
        }
        #endregion

        #region Edit 订单填写页面
        public IActionResult Edit() {
            return View();
        }
        #endregion

        #region GetEditViewData 获取订单填写页面的数据 api/order/getEditData
        [Route("api/order/getEditData")]
        public async Task<IActionResult> GetEditData([FromServices]TengoDbContext db) {
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

            var addrList = await db.Address.Where(p => p.UserID == 1).ToListAsync();
            return MyJsonResultSuccess("success", new {
                cartList,
                addrList
            });
        }
        #endregion

        #region Save 保存订单接口 api/order/save
        [Route("api/order/save")]
        public async Task<IActionResult> Save([FromServices]OrderBLL service, int addrId, string message = "") {
            return MyJsonResult(await service.Save(1, addrId, message));
        }
        #endregion

        #region Confitm 订单支付页面
        public IActionResult Confitm(int orderId) {
            return View();
        }
        #endregion
    }
}