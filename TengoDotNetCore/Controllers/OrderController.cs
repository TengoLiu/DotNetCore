using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class OrderController : BaseController {
        #region Index 用户订单列表
        public IActionResult Index() {
            return View();
        }
        #endregion

        #region List 获取订单列表接口 api/order/list
        [Route("api/order/list")]
        public async Task<IActionResult> List([FromServices]OrderService service, PageInfo pageInfo) {
            return MyJsonResult(await service.List(pageInfo, 1));
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

        #region Save 保存订单接口 api/order/save
        [Route("api/order/save")]
        public async Task<IActionResult> Save([FromServices]OrderService service, int addrId, string message = "") {
            return MyJsonResult(await service.Save(addrId, message));
        }
        #endregion

        #region Confitm 订单支付页面
        public IActionResult Confitm(int orderId) {
            return View();
        }
        #endregion
    }
}