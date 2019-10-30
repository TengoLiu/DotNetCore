using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.BLL {
    public class CategoryBLL : BaseBLL {

        public CategoryBLL(TengoDbContext db) : base(db) {
            SqlConnection conn = new SqlConnection("");
            SqlCommand comd = conn.CreateCommand();
        }

        public async Task<JsonResultObj> Insert(Category model) {
            if (model == null) {
                return JsonResultParamInvalid();
            }
            if (model.ParID == 0) {
                model.Level = 1;
            }
            else {
                var parent = await db.Category.FirstOrDefaultAsync(p => p.Id == model.ParID);
                if (parent == null) {
                    return JsonResultError("父结点不存在！");
                }
                model.Level = parent.Level + 1;
            }
            db.Category.Add(model);
            await db.SaveChangesAsync();
            return JsonResultSuccess("添加成功！");
        }

        public async Task<JsonResultObj> Update(Category model) {
            try {
                if (model.ParID == 0) {
                    model.Level = 1;
                }
                else {
                    var parent = await db.Category.FirstOrDefaultAsync(p => p.Id == model.ParID);
                    if (parent == null) {
                        return JsonResultError("父结点不存在！");
                    }
                    model.Level = parent.Level + 1;
                }
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Name).IsModified = true;
                db.Entry(model).Property(p => p.ParID).IsModified = true;
                db.Entry(model).Property(p => p.Level).IsModified = true;
                db.Entry(model).Property(p => p.CoverImg).IsModified = true;
                db.Entry(model).Property(p => p.Sort).IsModified = true;
                await db.SaveChangesAsync();
                return JsonResultSuccess("更新成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        public async Task<JsonResultObj> Delete(int id) {
            try {
                if (id <= 0) {
                    return JsonResultSuccess("删除成功！");
                }
                var model = await db.Category.FirstOrDefaultAsync(p => p.Id == id);
                if (model != null) {
                    db.Category.Remove(model);
                    await db.SaveChangesAsync();
                }
                return JsonResultSuccess("删除成功！");
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }
        
    }
}
