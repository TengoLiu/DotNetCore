using System;
using System.IO;
using System.Net;
using System.Text;

namespace TengoDotNetCore.Common.Utils.SMS {
    public class DuanXinWang : ISMS {

        public string GetPlatform() {
            return "短信网";
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        public SMSResponse Send(string mobile, string content) {
            var sms = new StringBuilder();
            sms.AppendFormat("name={0}", "短信网接口账号");
            sms.AppendFormat("&pwd={0}", "短信网接口密码");//登陆平台，管理中心--基本资料--接口密码（28位密文）；复制使用即可。
            sms.AppendFormat("&content={0}", content);
            sms.AppendFormat("&mobile={0}", mobile);
            sms.AppendFormat("&sign={0}", "签名");// 公司的简称或产品的简称都可以
            sms.Append("&type=pt");
            var resp = PushToWeb("http://web.duanxinwang.cc/asmx/smsservice.aspx", sms.ToString(), Encoding.UTF8);
            var msg = resp.Split(',');

            var res = new SMSResponse();
            res.Platform = GetPlatform();

            if(msg[0] == "0") {
                res.Success = true;
                res.ResStr = "提交成功：SendID=" + msg[1];
                return res;
            }
            else {
                res.Success = false;
                res.ResStr = "提交失败：错误信息=" + msg[1];
                return res;
            }
        }

        private static string PushToWeb(string weburl, string data, Encoding encode) {
            byte[] byteArray = encode.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            //接收返回信息：
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
            return aspx.ReadToEnd();
        }


    }
}