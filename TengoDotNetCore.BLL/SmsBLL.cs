using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Common.Utils.SMS;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.BLL {
    public class SmsBLL : BaseBLL {
        private ISMS smsSender;

        public SmsBLL(TengoDbContext db, ISMS smsSender) : base(db) {
            this.smsSender = smsSender;
        }

        /// <summary>
        /// 发送验证码短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="sendFor"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> SendVerifyCode(string mobile, string sendFor) {
            //手机号不能为空
            if (string.IsNullOrWhiteSpace(mobile)) {
                return JsonResultError("请输入手机号！");
            }

            //验证手机号合法性
            if (!Regex.IsMatch(mobile, Constant.REGEX_PHONE)) {
                return JsonResultError("请输入正确的手机号码！");
            }
            ///短信发送目的允许的白名单
            var smsSendForAllowList = new string[] { "注册", "忘记密码" };

            if (!smsSendForAllowList.Contains(sendFor)) {
                return JsonResultError("短信发送目的非法！");
            }

            var smsLog = await db.SMSLog
                        .OrderByDescending(p => p.Id)
                        .FirstOrDefaultAsync(p => p.Mobile == mobile && p.SendFor == sendFor);

            //如果是正式环境的话，那么验证码是随机生成4位数，如果是测试环境，验证码就是1
#if DEBUG
            int smsCode = 1;
#else
            int smsCode = new Random().Next(1000, 9999);
#endif
            var msg = "您的验证码是：" + smsCode + "，请不要把验证码透露给他人。如非本人操作，可不用理会！";

            //如果没有发过验证码的话，那极好的，马上发
            if (smsLog == null) {
                var res = smsSender.Send(mobile, msg);
                if (res.Success) {
                    db.SMSLog.Add(new SMSLog {
                        AddTime = DateTime.Now,
                        Code = smsCode.ToString(),
                        Content = msg,
                        Mobile = mobile,
                        Platform = smsSender.GetPlatform(),
                        ResultStr = res.ResStr,
                        SendFor = sendFor,
                        Success = res.Success,
                        UpdateTime = DateTime.Now
                    });
                    await db.SaveChangesAsync();
                    return JsonResultSuccess("验证码发送成功！", 90);
                }
            }
            else {
                //如果发过验证码的话，要判断时间间隔是否够90秒
                var ts = DateTime.Now - smsLog.AddTime;
                if (ts.TotalSeconds < 90) {
                    return JsonResultError("您已经获取过验证码,请" + (90 - (int)ts.TotalSeconds) + "秒后再获取!", (90 - (int)ts.TotalSeconds));
                }
                else {
                    var res = smsSender.Send(mobile, msg);
                    if (res.Success) {
                        db.SMSLog.Add(new SMSLog {
                            AddTime = DateTime.Now,
                            Code = smsCode.ToString(),
                            Content = msg,
                            Mobile = mobile,
                            Platform = smsSender.GetPlatform(),
                            ResultStr = res.ResStr,
                            SendFor = sendFor,
                            Success = res.Success,
                            UpdateTime = DateTime.Now
                        });
                        await db.SaveChangesAsync();
                        return JsonResultSuccess("验证码发送成功！", 90);
                    }
                }
            }
            return JsonResultError("请确定你输入的信息正确，确认正确后重新输入，若再次出现改错误，请联系客服，谢谢....");
        }
    }
}
