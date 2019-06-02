using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : BaseModel {

        #region 用户信息相关
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string UserPhone { get; set; }
        #endregion

        #region 订单主体信息
        /// <summary>
        /// 订单序列号、流水号
        /// 以时间yyyyMMdd + 8位数字组成
        /// 8位数字每天更新一次
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 商品金额
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GoodsAmount { get; set; }

        /// <summary>
        /// 物流费用
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ExpressFee { get; set; }

        /// <summary>
        /// 订单实付金额
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 订单备注，用于后台工作人员备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 订单用户留言
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 订单来源
        /// </summary>
        public string Orgin { get; set; }
        #endregion

        #region 支付方式信息相关
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentName { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }
        /// <summary>
        /// 支付状态,是否已支付
        /// </summary>
        public bool PayStatus { get; set; }
        #endregion

        #region 物流信息
        /// <summary>
        /// 物流方式名称
        /// </summary>
        public string ExpressSendName { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string ExpressNo { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 是否已发货
        /// </summary>
        public bool IsSend { get; set; }
        #endregion

        #region 收货地址相关
        /// <summary>
        /// 收货地址所在省份
        /// </summary>
        public string AddrProvince { get; set; }
        /// <summary>
        /// 收货地址城市
        /// </summary>
        public string AddrCity { get; set; }
        /// <summary>
        /// 收货地址所在地区
        /// </summary>
        public string AddrArea { get; set; }
        /// <summary>
        /// 收货地址详细街道、房间号等
        /// </summary>
        public string AddrDetail { get; set; }
        /// <summary>
        /// 收货地址里面的手机号
        /// </summary>
        public string AddrPhone { get; set; }
        #endregion

        /// <summary>
        /// 订单商品
        /// </summary>
        public virtual List<OrderGoods> GoodsList { get; set; }
    }
}
