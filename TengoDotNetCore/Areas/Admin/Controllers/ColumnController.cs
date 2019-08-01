using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ColumnController : BaseController {
        public ColumnService service;

        public ColumnController(ColumnService service) {
            this.service = service;
        }

        #region 栏目内容列表
        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null, int typeId = 0) {
            ViewBag.Types = await service.GetTypeList();
            ViewData.Model = await service.PageList(pageInfo, keyword, typeId, true);
            return View();
        }
        #endregion

        #region Add 新增栏目
        public async Task<IActionResult> Add() {
            ViewBag.Types = await service.GetTypeList();
            return View();
        }
        #endregion

        #region ApiAdd 新增栏目接口
        public async Task<IActionResult> ApiAdd(Column model) {
            if (ModelState.IsValid) {
                return Json(await service.Insert(model));
            }

            return MyJsonResultParamInvalid();
        }
        #endregion

        #region Edit 编辑栏目
        public async Task<IActionResult> Edit(int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await service.Get(id, true);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewData.Model = model;
            ViewBag.Types = await service.GetTypeList();
            return View();
        }
        #endregion

        #region ApiEdit 编辑栏目接口
        public async Task<IActionResult> ApiEdit(Column model) {
            if (ModelState.IsValid) {
                return Json(await service.Update(model));
            }
            return MyJsonResultParamInvalid();
        }
        #endregion

        #region ApiDelete 删除栏目接口
        public async Task<IActionResult> ApiDelete(int id = 0) {
            return Json(await service.Delete(id));
        }
        #endregion
    }
}