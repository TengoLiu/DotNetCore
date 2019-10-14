using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace TengoDotNetCore.Common.Utils {
    public class HttpUtils {

        /// <summary>
        /// 发送Get请求获取响应
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GET(string url, IDictionary<string, string> headers = null, string encoding = "utf-8") {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            if (headers != null && headers.Count > 0) {
                foreach (var key in headers.Keys) {
                    request.Headers.Add(key, headers[key]);
                }
            }

            //获取请求上传流
            var requestStream = request.GetRequestStream();

            //发送请求获取响应
            var response = (HttpWebResponse)request.GetResponse();

            ///获取响应流
            var responseStream = response.GetResponseStream();

            //获取服务端返回数据
            var sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            //将响应的字节数据转化成string返回
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="param">请求的参数集合，最终会拼成A=xxx&B=xxx放到报文里面去</param>
        /// <param name="encoding">请求和响应的编码</param>
        /// <param name="contentType">内容类型</param>
        /// <returns></returns>
        public static string Post(string url, NameValueCollection param, IDictionary<string, string> headers = null, string encoding = "utf-8", string contentType = "application/x-www-form-urlencoded") {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = contentType;

            if (headers != null && headers.Count > 0) {
                foreach (var key in headers.Keys) {
                    request.Headers.Add(key, headers[key]);
                }
            }

            var formData = new StringBuilder();
            if (param != null && param.Count > 0) {
                for (int i = 0; i < param.Count; i++) {
                    formData.Append("&" + HttpUtility.UrlEncode(param.Keys[i]) + "=" + HttpUtility.UrlEncode(param[i]));
                }
                //移除第一个&
                formData.Remove(0, 1);
            }

            //将报文数据转化成二进制字节
            byte[] bytesRequestData = Encoding.GetEncoding(encoding).GetBytes(formData.ToString());

            //这只请求头长度
            request.ContentLength = bytesRequestData.Length;

            //获取请求上传流
            var requestStream = request.GetRequestStream();
            //写入请求上传数据
            requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
            requestStream.Close();

            //发送请求获取响应
            var response = (HttpWebResponse)request.GetResponse();

            ///获取响应流
            var responseStream = response.GetResponseStream();

            //获取服务端返回数据
            var sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));


            //将响应的字节数据转化成string返回
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="body">直接要提交的报文体</param>
        /// <param name="encoding">请求和响应的编码</param>
        /// <param name="contentType">内容类型</param>
        /// <returns></returns>
        public static string Post(string url, string body, IDictionary<string, string> headers = null, string encoding = "utf-8", string contentType = "application/x-www-form-urlencoded") {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = contentType;

            if (headers != null && headers.Count > 0) {
                foreach (var key in headers.Keys) {
                    request.Headers.Add(key, headers[key]);
                }
            }

            //将报文数据转化成二进制字节
            byte[] bytesRequestData = Encoding.GetEncoding(encoding).GetBytes(body);

            //这只请求头长度
            request.ContentLength = bytesRequestData.Length;

            //获取请求上传流
            var requestStream = request.GetRequestStream();
            //写入请求上传数据
            requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
            requestStream.Close();

            //发送请求获取响应
            var response = (HttpWebResponse)request.GetResponse();

            ///获取响应流
            var responseStream = response.GetResponseStream();

            //获取服务端返回数据
            var sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));


            //将响应的字节数据转化成string返回
            return sr.ReadToEnd();
        }
    }
}
