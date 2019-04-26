using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models.Logs {
    /// <summary>
    /// 短信发送记录
    /// </summary>
    public class SMSLog : BaseModel {

        /// <summary>
        /// 发送目的
        /// 比如注册、忘记密码等
        /// </summary>
        public string SendFor { get; set; }

        /// <summary>
        /// 发送的手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 短信内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 发送到短信平台响应的结果
        /// </summary>
        public string ResultStr { get; set; }

        /// <summary>
        /// 是否发送成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 短信验证码,可有可无
        /// </summary>
        public string Code { get; set; }
    }
}