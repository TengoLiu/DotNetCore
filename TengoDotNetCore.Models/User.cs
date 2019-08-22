using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {

    public class User : BaseModel {

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 注册来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 上次登录的IP
        /// </summary>
        public string LastIP { get; set; }
        /// <summary>
        /// 上次登录的时间
        /// </summary>
        public string LastTime { get; set; }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegisterIP { get; set; }
    }
}
