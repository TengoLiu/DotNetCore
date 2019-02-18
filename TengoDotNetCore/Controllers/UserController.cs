using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Impl;

namespace TengoDotNetCore.Controllers {
    public class UserController : BaseController {

        /// <summary>
        /// 当前控制器私有的service对象，在构造函数中传入
        /// 在IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly IUserService service;

        public UserController(IUserService service) {
            this.service = service;
        }

        public IActionResult Index(PageInfo pageInfo) {
            ViewData.Model = service.List(pageInfo);
            return View();
        }
    }
}