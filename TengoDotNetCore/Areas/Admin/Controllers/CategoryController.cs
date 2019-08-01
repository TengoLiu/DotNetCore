using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {

    [Area("Admin")]
    public class CategoryController : BaseController {
        public GoodsService service;

        public CategoryController(GoodsService service) {
            this.service = service;
        }

        public async Task<IActionResult> Index() {
            ViewData.Model = await service.GetCategoryList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.Category = await service.GetCategoryList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category model) {
            if (ModelState.IsValid) {
                return Json(await service.InsertCategory(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id=0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await service.GetCategory((int)id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewBag.Category = await service.GetCategoryList();
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model) {
            if (ModelState.IsValid) {
                return Json(await service.UpdateCategory(model));
            }
            return MyJsonResultParamInvalid();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id=0) {
            return Json(await service.DeleteCategory(id));
        }
    }
}