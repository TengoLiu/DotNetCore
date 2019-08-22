using System;
using System.Net;

namespace TengoDotNetCore.API.WXPay.Transfer {
    //https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=3_1
    public class WxTransfer {
        #region 企业付款到零钱
        /// <summary>
        /// 微信付款到零钱
        /// </summary>
        public static WxPayData DoWxTransfer(string openid, string wechatRealName, string bankName, decimal transferAmount, string remark, string transferNo) {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            int amount = (Int32)(transferAmount * 100);//付款金额
            string desc = remark;//付款说明
            string partner_trade_no = transferNo;//订单编号

            int timeOut = 10;

            WxPayData request = new WxPayData();
            request.SetValue("mch_appid", WxPayConfig.APPID);//商户账号appid 	
            request.SetValue("mchid", WxPayConfig.MCHID);//商户号
            request.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));// );//随机字符串
            request.SetValue("partner_trade_no", partner_trade_no);//订单号
            request.SetValue("openid", openid);//商户appid下，某用户的openid
            request.SetValue("check_name", "FORCE_CHECK");//NO_CHECK：不校验真实姓名,FORCE_CHECK：强校验真实姓名
            request.SetValue("re_user_name", wechatRealName);//收款方用户名
            request.SetValue("amount", amount);//付款金额
            request.SetValue("desc", desc);//付款说明
            request.SetValue("spbill_create_ip", getServerIpv4());//用户端或者服务端的IP。
            request.SetValue("sign", request.MakeSign());//签名
            string xml = request.ToXml();//转换xml格式

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            WxPayData result = new WxPayData();
            //将xml格式的结果转换为对象以返回
            result.FromXml(response);

            return result;
        }

        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string getServerIpv4() {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily.ToString() == "InterNetwork") {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /// <summary>
        /// 查询微信付款到零钱
        /// </summary>
        /// <param name="transferNo"></param>
        /// <param name="serialNumber"></param>
        public static string DoWxOrderQuery(string transferNo, string serialNumber) {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";

            int timeOut = 10;

            WxPayData request = new WxPayData();
            request.SetValue("appid", WxPayConfig.APPID);//商户账号appid 	
            request.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            request.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));// );//随机字符串
            request.SetValue("partner_trade_no", transferNo);//订单号
            request.SetValue("sign", request.MakeSign());//签名
            string xml = request.ToXml();//转换xml格式

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //WxPayData result = new WxPayData();
            ////将xml格式的结果转换为对象以返回
            //result.FromXml(response);

            return response;
        }
        #endregion

        #region 企业付款到银行卡
        /// <summary>
        /// 微信付款到银行卡
        /// </summary>
        public static WxPayData DoWxBankTransfer(string bankAccountNo, string wechatRealName, string bankName, decimal transferAmount, string remark, string transferNo) {
            string url = "https://api.mch.weixin.qq.com/mmpaysptrans/pay_bank";
            string enc_bank_no = bankAccountNo;//银行卡卡号
            string enc_true_name = wechatRealName;//收款方用户名
            string bank_code = bankName;//开户行
            int amount = (Int32)(transferAmount * 100);//付款金额
            string desc = remark;//付款说明
            string partner_trade_no = transferNo;//订单编号

            //https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_4&index=5
            switch (bank_code) {
                case "工商银行": bank_code = "1002"; break;
                case "农业银行": bank_code = "1005"; break;
                case "中国银行": bank_code = "1026"; break;
                case "建设银行": bank_code = "1003"; break;
                case "招商银行": bank_code = "1001"; break;
                case "邮储银行": bank_code = "1066"; break;
                case "交通银行": bank_code = "1020"; break;
                case "浦发银行": bank_code = "1004"; break;
                case "民生银行": bank_code = "1006"; break;
                case "兴业银行": bank_code = "1009"; break;
                case "平安银行": bank_code = "1010"; break;
                case "中信银行": bank_code = "1021"; break;
                case "华夏银行": bank_code = "1025"; break;
                case "广发银行": bank_code = "1027"; break;
                case "北京银行": bank_code = "1032"; break;
                case "宁波银行": bank_code = "1056"; break;
                default: break;
            }
            int timeOut = 10;
            WxRSA obj = new WxRSA();
            obj.getkey();
            enc_bank_no = WxRSA.EncryptCSharp(enc_bank_no, "UTF-8");
            enc_true_name = WxRSA.EncryptCSharp(enc_true_name, "UTF-8");

            WxPayData request = new WxPayData();
            request.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            request.SetValue("partner_trade_no", partner_trade_no);//订单号
            request.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));// );//随机字符串
            request.SetValue("enc_bank_no", enc_bank_no);//银行卡卡号
            request.SetValue("enc_true_name", enc_true_name);//收款方用户名
            request.SetValue("bank_code", bank_code);//开户行编码
            request.SetValue("amount", amount);//付款金额
            request.SetValue("desc", desc);//付款说明
            request.SetValue("sign", request.MakeSign());//签名
            string xml = request.ToXml();//转换xml格式

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            WxPayData result = new WxPayData();
            //将xml格式的结果转换为对象以返回
            result.FromXml(response);

            return result;
        }

        /// <summary>
        /// 查询微信付款到银行卡
        /// </summary>
        /// <param name="transferNo"></param>
        /// <param name="serialNumber"></param>
        public static string DoWxBankOrderQuery(string transferNo, string serialNumber) {
            string url = " 	https://api.mch.weixin.qq.com/mmpaysptrans/query_bank ";

            int timeOut = 10;

            WxPayData request = new WxPayData();
            request.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            request.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));// );//随机字符串
            request.SetValue("partner_trade_no", transferNo);//订单号
            request.SetValue("sign", request.MakeSign());//签名
            string xml = request.ToXml();//转换xml格式

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //WxPayData result = new WxPayData();
            ////将xml格式的结果转换为对象以返回
            //result.FromXml(response);

            return response;
        }
        #endregion
    }
}
