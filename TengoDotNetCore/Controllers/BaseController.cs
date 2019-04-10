using System;
using TengoDotNetCore.Common;
using TengoDotNetCore.Common.Utils.SMS;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.Controllers {
    public class BaseController : MyControllerBase {

        public BaseController(TengoDbContext db) : base(db) { }

        #region SmsSend 发送短信
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="sender">短信发送者对象，需要在控制器内注入得到后再传过来</param>
        /// <param name="mobile">手机号码</param>
        /// <param name="content">短信内容</param>
        /// <param name="sendFor">发送目的，你为什么要短信？比如注册、忘记密码,同时也可以让注册和忘记密码短信互不干扰</param>
        /// <param name="sendFor">短信验证码，如果是发的短信验证码，就记录一下</param>
        protected bool SmsSend(ISMS sender, string mobile, string content, string sendFor, string smsCode = "") {
            var sendRes = sender.Send(mobile, content);
            var log = new SMSLog() {
                AddTime = DateTime.Now,
                Code = smsCode,
                Content = content,
                Mobile = mobile,
                Platform = sendRes.Platform,
                ResultStr = sendRes.ResStr,
                SendFor = sendFor,
                Success = sendRes.Success,
                UpdateTime = DateTime.Now
            };
            db.SMSLog.Add(log);
            db.SaveChanges();
            return sendRes.Success;
        }
        #endregion
    }
}