using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ColumnController : BaseController {
        public ColumnService service;

        public ColumnController(ColumnService service) {
            this.service = service;
        }

        #region Index 栏目内容列表
        public async Task<IActionResult> Index([FromServices]TengoDbContext db, PageInfo pageInfo, string keyword = null, int typeId = 0) {
            ViewBag.Types = await service.GetTypeList();
            var query = db.Column.AsQueryable();
            query = query.Where(p => string.IsNullOrWhiteSpace(keyword) || (!string.IsNullOrWhiteSpace(keyword) && p.Title.Contains(keyword)));
            query = query.Where(p => typeId <= 0 || (p.ColumnType_Id == typeId && typeId > 0));

            ViewData.Model = await BaseService.CreatePageAsync(query, pageInfo.Page, pageInfo.PageSize);
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
            try {
                model.DoBeforeUpdate();
                if (await TryUpdateModelAsync(model)) {
                    return MyJsonResultSuccess("更新成功！");
                }
                else {
                    return MyJsonResultError("更新失败！");
                }
            }
            catch (Exception e) {
                return MyJsonResultError(e.Message);
            }
        }
        #endregion

        #region ApiDelete 删除栏目接口
        public async Task<IActionResult> ApiDelete(int id = 0) {
            return Json(await service.Delete(id));
        }
        #endregion
    }
}