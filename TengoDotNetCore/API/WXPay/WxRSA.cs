using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace TengoDotNetCore.API.WXPay {
    public class WxRSA {
        /// <summary>
        /// 获取公匙
        /// </summary>
        /// <returns></returns>
        public string getkey() {
            WxPayData data = new WxPayData();
            WxPayData result = Micropay(data);
            XElement root = XElement.Parse(result.ToXml());
            string pub_key = root.Element("pub_key").Value;
            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory;    //设置当前目录  
            if(System.IO.Directory.Exists(CurDir)) { System.IO.Directory.CreateDirectory(CurDir); }//该路径不存在时，在当前文件目录下创建文件夹"导出.."  

            //不存在该文件时先创建  
            String filePath = CurDir;
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(filePath + WxPayConfig.RSACERT_PATH, false);     //文件已覆盖方式添加内容  
            file1.Write(pub_key);//保存数据到文件  
            file1.Close(); //关闭文件  
            file1.Dispose();
            return root.ToString();
        }
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publicKeyCSharp"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncryptCSharp(string data, string encoding = "UTF-8") {
            RsaKeyParameters pubkey;
            using(var sr = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + WxPayConfig.RSACERT_PATH)) {
                var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(sr);
                pubkey = (RsaKeyParameters)pemReader.ReadObject();
            }
            var cipher = (BufferedAsymmetricBlockCipher)CipherUtilities.GetCipher("RSA/ECB/OAEPWITHSHA-1ANDMGF1PADDING");
            cipher.Init(true, pubkey);
            var message = Encoding.UTF8.GetBytes(data);
            var output = Encrypt(message, cipher);
            return Convert.ToBase64String(output);
        }
        public static byte[] Encrypt(byte[] message, BufferedAsymmetricBlockCipher cipher) {
            using(var buffer = new MemoryStream()) {
                using(var transform = new BufferedCipherTransform(cipher))
                using(var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                using(var messageStream = new MemoryStream(message))
                    messageStream.CopyTo(stream);
                return buffer.ToArray();
            }
        }


        /// <summary>    
        /// RSA公钥格式转换， 
        /// </summary>    
        /// <param name="publicKey">pem公钥</param>    
        /// <returns></returns>    
        public static string RSAPublicKeyJava2DotNet(string publicKey) {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
               Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
               Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }
        public static WxPayData Micropay(WxPayData inputObj, int timeOut = 10) {
            string url = "https://fraud.mch.weixin.qq.com/risk/getpublickey";

            inputObj.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口以提交数据到API

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }
    }
}