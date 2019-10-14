using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.BLL {
    public class CartService : BaseBLL{
        public CartService(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 获取用户的购物车列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="includeGoods"></param>
        /// <returns></returns>
        public async Task<List<CartItem>> GetUserCartList(int userId, bool includeGoods = false) {
            var query = db.CartItem.AsQueryable();
            if (includeGoods) {
                query = query.Include(p => p.Goods);
            }
            var cartList = await query.Where(p => p.User_Id == userId).ToListAsync();
            return cartList;
        }

        /// <summary>
        /// 更新购物车商品数量
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goodsID"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> SetQty(int userId, int goodsID, int qty) {
            if (goodsID <= 0 || userId <= 0) {
                return JsonResultParamInvalid();
            }
            var cartItem = db.CartItem.FirstOrDefault(p => p.Goods_ID == goodsID);
            if (qty > 0) {
                if (cartItem == null) {
                    cartItem = new CartItem {
                        Goods_ID = goodsID,
                        Qty = qty,
                        Selected = true,
                        User_Id = userId
                    };
                    db.CartItem.Add(cartItem);
                    await db.SaveChangesAsync();
                }
                else {
                    cartItem.Qty = qty;
                    cartItem.Selected = true;
                    await db.SaveChangesAsync();
                }
            }
            else {
                if (cartItem != null) {
                    db.CartItem.Remove(cartItem);
                    await db.SaveChangesAsync();
                }
            }
            return JsonResultSuccess("success");
        }

        /// <summary>
        /// 设置单个商品的选中状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goodsID"></param>
        /// <param name="selected">是否选中，大于0则为选中</param>
        /// <returns></returns>
        public async Task SetChecked(int userId, int goodsID, int selected) {
            if (goodsID <= 0 || userId <= 0) {
                return;
            }
            var cartItem = db.CartItem.FirstOrDefault(p => p.User_Id == userId && p.Goods_ID == goodsID);
            if (cartItem != null) {
                cartItem.Selected = selected > 0;
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 设置全部商品的选中状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goodsID"></param>
        /// <param name="selected">是否选中，大于0则为选中</param>
        /// <returns></returns>
        public async Task SetAllChecked(int userId, int selected) {
            if (userId <= 0) {
                return;
            }
            var cartItems = db.CartItem.Where(p => p.User_Id == userId);
            foreach (var item in cartItems) {
                item.Selected = selected > 0;
            }
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// 移除购物车里面的所有商品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task RemoveAll(int userId) {
            var cartItems = db.CartItem.Where(p => p.User_Id == userId);
            foreach (var item in cartItems) {
                db.CartItem.Remove(item);
            }
            await db.SaveChangesAsync();
        }
    }
}
