﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Common;
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

        #region ApiRegister 登录接口 ----- api/user/register
        [Route("api/user/login")]
        public async Task<IActionResult> ApiLogin([FromServices]UserService service, string account, string password) {
            var res = await service.Login(account, password, HttpContext.Connection.RemoteIpAddress.ToString());
            if (res.code == 1000) {//如果登录成功，要设置Session之类的
                HttpContext.Session.Set(Constant.SESSION_USER, res.data);
            }
            return MyJsonResult(res);
        }
        #endregion

        public IActionResult Register() {
            return View();
        }

        #region ApiRegister 注册接口 ----- api/user/register
        [Route("api/user/register")]
        public async Task<IActionResult> ApiRegister([FromServices]UserService service, User model) {
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