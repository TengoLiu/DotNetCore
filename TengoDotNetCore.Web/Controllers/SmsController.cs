using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TengoDotNetCore.BLL;

namespace TengoDotNetCore.Controllers {
    public class SmsController : BaseController {

        #region SendSmsCode api/submit/sendSmsCode 获取短信验证码
        [Route("api/submit/sendSmsCode")]
        public async Task<IActionResult> SendSmsCode([FromServices]SmsBLL service, string mobile = "", string sendFor = "") {
            try {
                return Json(await service.SendVerifyCode(mobile, sendFor));
            }
            catch (Exception exp) {
                return MyJsonResultError(exp);
            }
        }
        #endregion
    }
}