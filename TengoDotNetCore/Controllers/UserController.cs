using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.BLL;
using TengoDotNetCore.Common;
using TengoDotNetCore.Common.Sessions;
using TengoDotNetCore.Filters;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Controllers {
    public class UserController : BaseController {

        #region Index 个人中心页面
        [UserFilter]
        public IActionResult Index() {
            return View();
        }
        #endregion

        #region Login 登录页面
        public IActionResult Login() {
            return View();
        }
        #endregion

        #region ApiRegister 登录接口 ----- api/user/register
        [Route("api/user/login")]
        public async Task<IActionResult> ApiLogin([FromServices]UserBLL service, string account, string password) {
            var res = await service.Login(account, password, HttpContext.Connection.RemoteIpAddress.ToString());
            if (res.code == 1000) {//如果登录成功，要设置Session之类的
                HttpContext.Session.Set(Constant.SESSION_USER, res.data);
            }
            return MyJsonResult(res);
        }
        #endregion

        #region Register 注册页面
        public IActionResult Register() {
            return View();
        }
        #endregion

        #region ApiRegister 注册接口 ----- api/user/register
        [Route("api/user/register")]
        public async Task<IActionResult> ApiRegister([FromServices]UserBLL service, User model) {
            if (ModelState.IsValid) {
                model.RegisterIP = HttpContext.Connection.RemoteIpAddress.ToString();
                var res = await service.Insert(model);
                if (res.code == 1000) {//如果注册成功，要设置Session之类的
                    HttpContext.Session.Set(Constant.SESSION_USER, res.data);
                }
                return MyJsonResult(res);
            }
            else {
                return MyJsonResultParamInvalid();
            }
        }
        #endregion
    }
}