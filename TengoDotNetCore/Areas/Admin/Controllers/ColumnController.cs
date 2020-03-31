using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ColumnController : BaseController {
        private TengoDbContext db;
 
        public ColumnController(TengoDbContext db) {
            this.db = db;
        }

        #region Index 栏目内容列表
        public async Task<IActionResult> Index(PageInfo pageInfo, string keyword = null, int typeId = 0) {
            ViewBag.Types = await db.ColumnType.ToListAsync();
            var query = db.Column.AsQueryable();
            query = query.Where(p => string.IsNullOrWhiteSpace(keyword) || (!string.IsNullOrWhiteSpace(keyword) && p.Title.Contains(keyword)));
            query = query.Where(p => typeId <= 0 || (p.ColumnTypeId == typeId && typeId > 0));

            ViewData.Model = await db.GetPageListAsync(query, pageInfo.Page, pageInfo.PageSize);
            return View();
        }
        #endregion

        #region Add 新增栏目
        public async Task<IActionResult> Add() {
            ViewBag.Types = await db.ColumnType.ToListAsync();
            return View();
        }
        #endregion

        #region ApiAdd 新增栏目接口
        public async Task<IActionResult> ApiAdd(Column model) {
            if (ModelState.IsValid) {
                model.AddTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                db.Column.Add(model);
                await db.SaveChangesAsync();
                return MyJsonResultSuccess("添加成功！");
            }

            return MyJsonResultParamInvalid();
        }
        #endregion

        #region Edit 编辑栏目
        public async Task<IActionResult> Edit(int id = 0) {
            if (id <= 0) {
                return new NotFoundResult();
            }
            var model = await db.Column.Include(p => p.ColumnType).FirstOrDefaultAsync(p => p.Id == id);
            if (model == null) {
                return new NotFoundResult();
            }
            ViewData.Model = model;
            ViewBag.Types = await db.ColumnType.ToListAsync();
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
            var column = await db.Column.FirstOrDefaultAsync(p => p.Id == id);
            if (column != null) {
                db.Column.Remove(column);
                await db.SaveChangesAsync();
            }
            return MyJsonResultSuccess("success");
        }
        #endregion
    }
}