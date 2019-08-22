using System;

namespace TengoDotNetCore.API.WXPay {
    public class WXPay {
        /// <summary>
        /// openid用于调用统一下单接口
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// access_token用于获取收货地址js函数入口参数
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 统一下单接口返回结果
        /// </summary>
        public WxPayData unifiedOrderResult { get; set; }
        /// <summary>
        /// H5调起JS API参数
        /// </summary>
        public string wxJsApiParam { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no = string.Empty;
        /// <summary>
        /// 商户订单总金额
        /// </summary>
        public int total_fee = 0;

        /// <summary>
        /// 微信支付获得图片
        /// </summary>
        public string url = string.Empty;
        /// <summary>
        /// 微信支付获得图片
        /// </summary>
        public string date = DateTime.Now.ToString("yyMMddHHmmss");

        //查询订单
        public static bool QueryOrder(string transaction_id) {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            string resultSandBoxNew = res.ToJson();
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS") {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
