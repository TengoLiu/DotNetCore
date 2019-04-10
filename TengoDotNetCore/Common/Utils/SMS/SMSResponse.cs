namespace TengoDotNetCore.Common.Utils.SMS {
    public class SMSResponse {

        /// <summary>
        /// 是否发送成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 短信平台原始响应
        /// </summary>
        public string ResStr { get; set; }
    }
}