using System;
using TengoDotNetCore.Common.BaseModels;

namespace TengoDotNetCore.API.WXPay.Refund {
    /// <summary>
    /// 微信退款操作类
    /// </summary>
    public class WXRefund {
        //退款请求地址
        private string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";

        /// <summary>
        /// 执行退款请求
        /// </summary>
        /// <param name="out_trade_no">商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。</param>
        /// <param name="out_refund_no">商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。</param>
        /// <param name="total_fee">订单金额,注意，单位为分</param>
        /// <param name="refund_fee">退款金额,注意，单位为分</param>
        /// <param name="refund_desc">退款原因，非必填</param>
        /// <returns></returns>
        public JsonResultObj Excute(string out_trade_no, string out_refund_no, int total_fee, int refund_fee, string refund_desc = "正常退款") {
            try {
                WxPayData data = new WxPayData();
                //商户账号appid 	
                data.SetValue("appid", WxPayConfig.APPID);

                //商户号
                data.SetValue("mch_id", WxPayConfig.MCHID);

                //随机字符串
                data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));

                //商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
                data.SetValue("out_trade_no", out_trade_no);
                //商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
                data.SetValue("out_refund_no", out_refund_no);
                //订单金额
                data.SetValue("total_fee", total_fee);
                //退款金额
                data.SetValue("refund_fee", refund_fee);
                //退款货币种类
                data.SetValue("refund_fee_type", "CNY");
                data.SetValue("refund_desc", refund_desc);
                data.SetValue("refund_account", "REFUND_SOURCE_UNSETTLED_FUNDS");
                data.SetValue("notify_url", "");

                data.SetValue("sign", data.MakeSign());
                var xml = data.ToXml();//转换xml格式

                int timeOut = 10;
                var start = DateTime.Now;//请求开始时间

                string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

                var end = DateTime.Now;
                int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

                WxPayData result = new WxPayData();
                //将xml格式的结果转换为对象以返回
                result.FromXml(response);
                var result_code = result.GetValue("result_code").ToString();
                var return_code = result.GetValue("result_code").ToString();
                if (result_code.Equals("SUCCESS", StringComparison.OrdinalIgnoreCase) && return_code.Equals("SUCCESS", StringComparison.OrdinalIgnoreCase)) {
                    return new JsonResultObj {
                        code = 1000,
                        msg = "退款成功！金额" + result.GetValue("refund_fee") + "(单位：分)已经成功原路退款至该用户"
                    };
                }
                else {
                    var err_code_des = result.GetValue("err_code_des").ToString();
                    return new JsonResultObj {
                        msg = err_code_des,
                    };
                }
            }
            catch (Exception ex) {
                //LogFactory.GetLogger().Error("微信退款请求异常", ex);
                return new JsonResultObj {
                    msg = ex.Message,
                };
            }
        }
    }
}
