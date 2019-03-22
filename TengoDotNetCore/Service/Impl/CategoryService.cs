using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Abs;

namespace TengoDotNetCore.Service.Impl {

    public class CategoryService : AbsService, ICategoryService {

        public CategoryService(TengoDbContext db) : base(db) {
        }

        public async Task<JsonResultObj> Add(Category model) {
            model.AddTime = DateTime.Now;
            if (model.ParID == 0) {
                model.Level = 1;
            }
            else {
                var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                if (parent == null) {
                    return Error("父结点不存在！");
                }
                model.Level = parent.Level + 1;
            }
            db.Category.Add(model);
            await db.SaveChangesAsync();
            return Success("添加成功！");
        }

        public async Task<JsonResultObj> Delete(int? id) {
            try {
                if (id == null) {
                    return Success("删除成功！");
                }
                var model = await db.Category.SingleOrDefaultAsync(p => p.ID == id);
                if (model != null) {
                    db.Category.Remove(model);
                    await db.SaveChangesAsync();
                }
                return Success("删除成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<Category> Detail(int? id) {
            if (id == null || id <= 0) {
                return null;
            }
            var model = await db.Category.ToAsyncEnumerable().FirstOrDefault(p => p.ID == id);
            return model;
        }

        public async Task<JsonResultObj> Edit(Category model) {
            try {
                if (model.ParID == 0) {
                    model.Level = 1;
                }
                else {
                    var parent = await db.Category.FirstOrDefaultAsync(p => p.ID == model.ParID);
                    if (parent == null) {
                        return Error("父结点不存在！");
                    }
                    model.Level = parent.Level + 1;
                }
                model.AddTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Name).IsModified = true;
                db.Entry(model).Property(p => p.ParID).IsModified = true;
                db.Entry(model).Property(p => p.Level).IsModified = true;
                db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                db.Entry(model).Property(p => p.Sort).IsModified = true;
                await db.SaveChangesAsync();
                return Success("更新成功！");
            }
            catch (Exception e) {
                return Error(e);
            }
        }

        public async Task<List<Category>> List() {
            return await db.Category.ToAsyncEnumerable().ToList();
        }

    }
}
