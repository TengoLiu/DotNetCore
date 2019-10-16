using LitJson;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TengoDotNetCore.API.WXPay;
using TengoDotNetCore.BLL;

namespace TengoDotNetCore.Controllers {
    public class PaymentController : BaseController {

        #region 微信JSAPI公众号支付
        public async Task<ActionResult> WXPay([FromServices]OrderBLL orderService
            , int outTradeNo = 0, string code = null, int orderId = 0, int isDelaySend = 0) {

            //如果outTradeNo参数为空，那么是第一次进来的情况
            if (outTradeNo <= 0) {

                #region  商场本身业务逻辑 第一次（也就是从订单点击去支付之后）进来的时候会执行这里
                if (orderId <= 0) {
                    return Redirect("/error");
                }
                var order = await orderService.Get(orderId);
                if (order == null) {
                    return Redirect("/error");
                }
                if (order.RealAmount == 0) {//如果支付金额是0元，那么有可能是活动啥的不用付钱，那么状态应该是已经支付了的，直接跳回去看看
                    return Redirect("/order/detail?id=" + order.Id);
                }
                if (order.PayStatus) {
                    return Redirect("/order/detail?id=" + order.Id);
                }

                #endregion

                #region 构造网页授权获取code的URL，并且重定向跳转到微信的地址
                var host = HttpContext.Request.Host;
                var path = Request.Path;
                //指定获取code之后要跳回来的地址，这里我会加上订单流水号
                var redirect_uri = HttpUtility.UrlEncode("https://" + host + "/payment/WXPay?outTradeNo=" + orderId);
                var data = new WxPayData();
                data.SetValue("appid", WxPayConfig.APPID);
                data.SetValue("redirect_uri", redirect_uri);
                data.SetValue("response_type", "code");
                data.SetValue("scope", "snsapi_base");
                data.SetValue("state", "STATE" + "#wechat_redirect");
                var url = "https://open.weixin.qq.com/connect/oauth2/authorize?" + data.ToUrl();
                //触发微信返回code码
                return Redirect(url);//Redirect函数会抛出ThreadAbortException异常，不用处理这个异常
                #endregion
            }
            //重定向回来之后包含了code
            else if (!string.IsNullOrWhiteSpace(code)) {

                #region GetOpenidAndAccessToken 从Url里面拿取上面第一步重定向之后返回来附带的code，然后进一步获取openid和accessToken，接着再统一下单，获取支付参数

                var model = new WXPay();

                #region  GetOpenidAndAccessTokenFromCode(code); 先通过code构造请求来获取openid和accessToken
                try {
                    //构造获取openid及access_token的url
                    var data = new WxPayData();
                    data.SetValue("appid", WxPayConfig.APPID);
                    data.SetValue("secret", WxPayConfig.APPSECRET);
                    //写入code码，以获取openid和access_token
                    data.SetValue("code", code);
                    data.SetValue("grant_type", "authorization_code");
                    string url = "https://api.weixin.qq.com/sns/oauth2/access_token?" + data.ToUrl();

                    //请求url以获取数据
                    string result = HttpService.Get(url);

                    //LogFactory.GetLogger().Info("WXPay", "GetOpenidAndAccessTokenFromCode响应 : " + result);

                    //保存access_token，用于收货地址获取
                    var jd = JsonMapper.ToObject(result);
                    model.access_token = (string)jd["access_token"];

                    //获取用户openid
                    model.openid = (string)jd["openid"];

                    //LogFactory.GetLogger().Info("WXPay", "获取到的openid : " + model.openid);
                    //LogFactory.GetLogger().Info("WXPay", "获取到的access_token : " + model.access_token);
                }
                catch (Exception ex) {
                    //LogFactory.GetLogger().Error("WXPay", ex, remark: "GetOpenidAndAccessTokenFromCode错误");
                    throw new WxPayException(ex.ToString());
                }
                #endregion

                try {
                    //读取订单信息
                    var order = await orderService.Get(outTradeNo);

                    //注意这里的订单号就要设置为流水号了
                    model.out_trade_no = outTradeNo.ToString();
                    model.total_fee = Convert.ToInt32(order.RealAmount * 100);

                    #region 调用统一下单，获得下单结果 获取prepay_id
                    //统一下单
                    var data = new WxPayData();

                    #region 处理商品前缀
                    var subject = "Teogn电商商品";
                    #endregion

                    data.SetValue("body", subject);//商品描述
                    data.SetValue("attach", subject);//附加数据

                    data.SetValue("out_trade_no", model.out_trade_no);
                    data.SetValue("total_fee", model.total_fee);

                    data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
                    data.SetValue("goods_tag", "");//订单优惠标记
                    data.SetValue("trade_type", "JSAPI");
                    data.SetValue("openid", model.openid);

                    var unifiedOrderResult = WxPayApi.UnifiedOrder(data);
                    if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("prepay_id") || unifiedOrderResult.GetValue("prepay_id").ToString() == "") {
                        //LogFactory.GetLogger().Info("WXPay", "统一下单报错：UnifiedOrder response error!");
                        throw new WxPayException("UnifiedOrder response error!");
                    }


                    #endregion

                    #region  获取H5调起JS API参数
                    //LogFactory.GetLogger().Info("WXPay", "JsApiPay::GetJsApiParam is processing...");
                    var jsApiParam = new WxPayData();
                    jsApiParam.SetValue("appId", unifiedOrderResult.GetValue("appid"));
                    jsApiParam.SetValue("timeStamp", WxPayApi.GenerateTimeStamp());
                    jsApiParam.SetValue("nonceStr", WxPayApi.GenerateNonceStr());
                    jsApiParam.SetValue("package", "prepay_id=" + unifiedOrderResult.GetValue("prepay_id"));
                    jsApiParam.SetValue("signType", "MD5");
                    jsApiParam.SetValue("paySign", jsApiParam.MakeSign());
                    model.wxJsApiParam = jsApiParam.ToJson();
                    //LogFactory.GetLogger().Info("WXPay", "wxJsApiParam : " + model.wxJsApiParam);
                    #endregion

                    ViewData.Model = model;
                    return View();
                }
                catch (Exception exp) {
                    //LogFactory.GetLogger().Error("微信支付异常", exp);
                    return Redirect("/error?msg=微信支付异常...");
                }
                #endregion

            }
            else {//异常情况，不用理会
                return Redirect("/error?msg=支付异常...");
            }
        }

        /// <summary>
        /// 接收并解析微信支付响应数据的方法
        /// </summary>
        /// <returns></returns>
        public WxPayData GetNotifyData() {
            //接收从微信后台POST过来的数据
            var s = Request.Body;
            int count = 0;
            byte[] buffer = new byte[1024];
            var builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0) {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            var data = new WxPayData();
            try {
                data.FromXml(builder.ToString());
            }
            catch (WxPayException ex) {//如果遇到微信支付签名错误的话，直接抛出这异常
                throw ex;
            }
            return data;
        }

        #region Notify 微信支付异步响应的方法，即微信支付之后会给这个方法发一条消息通知我们
        public string Notify() {
            WxPayData notifyData = null;
            try {
                notifyData = GetNotifyData();
            }
            catch (WxPayException ex) {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                return res.ToXml();
            }
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id")) {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                //LogFactory.GetLogger().Error("微信支付PC端异步回调异常", new Exception("The Pay result is error :" + "-----" + res.ToXml()));
                return res.ToXml();
            }
            string transaction_id = notifyData.GetValue("transaction_id").ToString();
            //查询订单，判断订单真实性
            if (!API.WXPay.WXPay.QueryOrder(transaction_id)) {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                //LogFactory.GetLogger().Error("微信支付PC端异步回调异常", new Exception("订单查询失败" + "-----" + res.ToXml()));
                return res.ToXml();
            }
            //查询订单成功
            else {
                // 商户订单号
                string orderNo = notifyData.GetValue("out_trade_no").ToString();
                // 实际支付金额
                string txnAmt = notifyData.GetValue("total_fee").ToString();
                decimal total_fee = Convert.ToDecimal(txnAmt) / 100;
                //处理订单支付后的逻辑
                //var result = BLLFactory.PaymentBLL.DoAfterOrderPaid(orderNo, "WxPayWeb", transaction_id, total_fee, notifyData.ToJson());
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                return res.ToXml();
            }
        }
        #endregion

        #endregion
    }
}