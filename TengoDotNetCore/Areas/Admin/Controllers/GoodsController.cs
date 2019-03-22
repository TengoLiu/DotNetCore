using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TengoDotNetCore.Controllers;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class GoodsController : BaseController {

        /// <summary>
        /// 当前控制器私有的service对象，在构造函数中传入
        /// 在IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly IGoodsService service;
        private readonly ICategoryService gcservice;

        public GoodsController(IGoodsService service, ICategoryService gcservice) {
            this.service = service;
            this.gcservice = gcservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null, string sortBy = null) {
            ViewData["keyword"] = keyword;
            ViewData.Model = await service.List(pageInfo, keyword, sortBy);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var model = await service.Detail(id, true);
            ViewData["Category"] = await gcservice.List();
            ViewData.Model = model;
            if (model == null) {
                return new NotFoundResult();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Goods model, List<int> categoryIds) {
            if (ModelState.IsValid) {
                //组装商品分类关系
                model.GoodsCategory = new List<GoodsCategory>();
                if (categoryIds != null) {
                    categoryIds.ForEach(p => {
                        model.GoodsCategory.Add(new GoodsCategory {
                            GoodsID = model.ID,
                            CategoryID = p
                        });
                    });
                }
                return JsonResult(await service.Edit(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewData["Category"] = await gcservice.List();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Goods model, List<int> categoryIds) {
            if (ModelState.IsValid) {
                if (categoryIds != null) {
                    model.GoodsCategory = new List<GoodsCategory>();
                    categoryIds.ForEach(p => {
                        model.GoodsCategory.Add(new GoodsCategory {
                            Goods = model,
                            CategoryID = p
                        });
                    });
                }
                return JsonResult(await service.Add(model));
            }
            return JsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            //对于删除来说，其实我只要执行就好了，不管它成不成功！
            return JsonResult(await service.Delete(id));
        }
    }
}