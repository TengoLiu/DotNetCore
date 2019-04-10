namespace TengoDotNetCore.Common.Utils.SMS {
    /// <summary>
    /// 短信发送的统一接口
    /// 若要替换短信平台，只需要实现这个接口然后在工厂类中修改指定新的实现短信实现类即可
    /// </summary>
    public interface ISMS {

        /// <summary>
        /// 返回当前使用的短信平台名称
        /// </summary>
        /// <returns></returns>
        string GetPlatform();

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        SMSResponse Send(string mobile, string content);
    }
}
