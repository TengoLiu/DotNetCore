using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.BLL;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ColumnTypeController : BaseController {
        private TengoDbContext db;
        private ColumnTypeBLL bll;

        public ColumnTypeController(TengoDbContext db, ColumnTypeBLL bll) {
            this.db = db;
            this.bll = bll;
        }

        #region Index 栏目内容列表
        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null) {
            var query = db.ColumnType.AsQueryable();
            query = query.Where(p => string.IsNullOrWhiteSpace(keyword) || (!string.IsNullOrWhiteSpace(keyword) && p.TypeName.Contains(keyword)));
            ViewData.Model = await db.GetPageListAsync(query, pageInfo.Page, pageInfo.PageSize);
            return View();
        }
        #endregion

        #region Add 新增栏目
        public IActionResult Add() {
            return View();
        }
        #endregion

        #region ApiAdd 新增栏目接口
        public async Task<IActionResult> ApiAdd(ColumnType model) {
            if (ModelState.IsValid) {
                return MyJsonResult(await bll.Insert(model));
            }

            return MyJsonResultParamInvalid();
        }
        #endregion

        #region Edit 编辑栏目
        public async Task<IActionResult> Edit(int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.ColumnType.FirstOrDefaultAsync(p => p.Id == id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewData.Model = model;
            return View();
        }
        #endregion

        #region ApiEdit 编辑栏目接口
        public async Task<IActionResult> ApiEdit(Column model) {
            try {
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
            var model = await db.ColumnType.FirstOrDefaultAsync(p => p.Id == id);
            if (model != null) {
                db.ColumnType.Remove(model);
                await db.SaveChangesAsync();
            }
            return MyJsonResultSuccess("success");
        }
        #endregion
    }
}