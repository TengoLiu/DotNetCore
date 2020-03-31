using System;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Common.Utils.SMS;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.BLL.Base {
    public class BaseBLL {
        /// <summary>
        /// DbContext对象
        /// </summary>
        protected readonly TengoDbContext db;

        public BaseBLL(TengoDbContext db) {
            this.db = db;
        }

        #region 事务相关方法
        /// <summary>
        /// 开启事务
        /// </summary>
        protected void TrnsactionBegin() {

        }

        /// <summary>
        /// 提交事务
        /// </summary>
        protected void TrnsactionCommit() {

        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        protected void TrnsactionRollback() {

        }
        #endregion

        #region 返回JSON相关的方法
        protected JsonResultObj JsonResult(JsonResultObj jsonObj) {
            return jsonObj;
        }

        protected JsonResultObj JsonResultSuccess(string msg) {
            return new JsonResultObj {
                code = 1000,
                msg = msg,
                data = null
            };
        }

        protected JsonResultObj JsonResultSuccess(string msg, object obj) {
            return new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            };
        }

        protected JsonResultObj JsonResultError(Exception e) {
            return new JsonResultObj {
                code = 999,
                msg = e.Message
            };
        }

        protected JsonResultObj JsonResultError(string msg) {
            return new JsonResultObj {
                code = 999,
                msg = msg
            };
        }

        protected JsonResultObj JsonResultError(string msg, object obj) {
            return new JsonResultObj {
                code = 1000,
                msg = msg,
                data = obj
            };
        }

        protected JsonResultObj JsonResultParamInvalid() {
            return new JsonResultObj {
                code = 1001,
                msg = "您提交的参数缺失或者有误，请检查输入的信息是否完整。",
            };
        }
        #endregion

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
