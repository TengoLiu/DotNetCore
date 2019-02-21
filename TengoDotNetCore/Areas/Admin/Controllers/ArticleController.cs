using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ArticleController : BaseController {
        /// <summary>
        /// 当前控制器私有的service对象，在构造函数中传入
        /// 在IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly IArticleService service;

        public ArticleController(IArticleService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index(PageInfo pageInfo, string sortBy = "") {
            pageInfo.PageSize = 100;
            ViewData.Model = await service.List(pageInfo, sortBy);
            return View();
        }

        public async Task<IActionResult> Edit(int? id) {
            var article = await service.Detail(id);
            ViewData.Model = article;
            if (article == null) {
                return new NotFoundResult();
            }
            return View();
        }
    }
}