using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class CartController : BaseController {

        #region Index 我的购物车
        public IActionResult Index() {
            return View();
        }
        #endregion

        #region List 获取购物车列表接口 api/cart/list
        [Route("api/cart/list")]
        public async Task<IActionResult> List([FromServices]CartService service) {
            return MyJsonResultSuccess("success",await service.GetUserCartList(1, true));
        }
        #endregion

        #region SetQty 更新覆盖购物车商品数量 幂等! api/cart/setQty
        [Route("api/cart/setQty")]
        public async Task SetQty([FromServices]CartService service, int goodsID, int qty) {
            await service.SetQty(1, goodsID, qty);
        }
        #endregion

        #region RemoveAll 清空购物车 api/cart/removeAll
        [Route("api/cart/removeAll")]
        public async Task RemoveAll([FromServices]CartService service) {
            await service.RemoveAll(1);
        }
        #endregion

        #region SetChecked 设置单个商品状态为选中 幂等! api/cart/setChecked
        [Route("api/cart/setChecked")]
        public async Task SetChecked([FromServices]CartService service, int goodsID, int selected) {
            await service.SetChecked(1, goodsID, selected);
        }
        #endregion

        #region SetAllChecked 设置所有商品为选中或未选中 幂等! api/cart/setAllChecked
        [Route("api/cart/setAllChecked")]
        public async Task SetAllChecked([FromServices]CartService service, int selected) {
            await service.SetAllChecked(1, selected);
        }
        #endregion
    }
}