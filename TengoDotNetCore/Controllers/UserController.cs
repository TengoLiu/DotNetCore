using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Controllers {
    public class UserController : BaseController {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        #region ApiRegister 注册接口 ----- api/user/register
        [Route("api/user/login")]
        public async Task<IActionResult> ApiLogin([FromServices]UserService service, [FromServices]IHttpContextAccessor accessor, string account, string password) {
            var logRes = await service.Login(account, password, accessor.HttpContext.Connection.RemoteIpAddress.ToString());
            if (logRes.code == 1000) {//如果登录成功，要设置Session之类的
                
            }
            return MyJsonResult(logRes);
        }
        #endregion

        public IActionResult Register() {
            return View();
        }

        #region ApiRegister 注册接口 ----- api/user/register
        [Route("api/user/register")]
        public async Task<IActionResult> ApiRegister([FromServices]UserService service, [FromServices]IHttpContextAccessor accessor, User model) {
            if (ModelState.IsValid) {
                //获取IP真的麻烦........
                model.RegisterIP = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                return MyJsonResult(await service.Insert(model));
            }
            else {
                return MyJsonResultParamInvalid();
            }
        }
        #endregion
    }
}