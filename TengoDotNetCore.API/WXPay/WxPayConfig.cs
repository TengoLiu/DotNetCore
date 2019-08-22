namespace TengoDotNetCore.API.WXPay {
    /// <summary>
    /// 这是微信支付配置的类，参数需要配置一下
    /// </summary>
    public class WxPayConfig {
        //=======【基本信息设置】=====================================
        /* 微信公众号信息配置
        * APPID：绑定支付的APPID（必须配置）
        * MCHID：商户号（必须配置）
        * KEY：商户支付密钥，参考开户邮件设置（必须配置）
        * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        */
        public static readonly string APPID;
        public static readonly string MCHID;
        public static readonly string MCHNAME;
        public static readonly string KEY;
        public static readonly string APPSECRET;

        //=======【证书路径设置】===================================== 
        /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）*/
        public static readonly string SSLCERT_PATH;
        public static readonly string SSLCERT_PASSWORD;
        public static readonly string RSACERT_PATH;


        //=======【支付结果通知url】===================================== 
        /* 支付结果通知回调url，用于商户接收支付结果,无论是PC还是JSAPI还是H5微信支付，通知回调的地址是可以同一个的，因为回调的内容都是一样的 */
        public static readonly string NOTIFY_URL;

        //=======【商户系统后台机器IP】===================================== 
        /* 此参数可手动配置也可在程序中自动获取*/
        public static readonly string IP;


        //=======【代理服务器设置】===================================
        /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）*/
        public static readonly string PROXY_URL;

        //=======【上报信息配置】===================================
        /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报 */
        public static readonly int REPORT_LEVENL;

        //=======【日志级别】===================================
        /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息 */
        public static readonly int LOG_LEVENL;

    }
}
