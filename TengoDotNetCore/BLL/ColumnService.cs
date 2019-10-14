using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;

namespace TengoDotNetCore.BLL {
    public class ColumnService : BaseBLL {
        public ColumnService(TengoDbContext db) : base(db) { }

        public async Task<Column> Get(int id, bool includeType = false) {
            var query = db.Column.AsQueryable();
            if (includeType) {
                query = query.Include(p => p.ColumnType);
            }
            var model = await query.FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Insert(Column model) {
            try {
                model.DoBeforeInsert();
                // 判断栏目标题是否有重复
                bool isExistColumnTitle = await db.Column.AnyAsync(p => p.Title == model.Title);
                if (isExistColumnTitle) {
                    return JsonResultError("该标题已存在！");
                }
                db.Column.Add(model);
                int result = await db.SaveChangesAsync();
                if (result > 0) {
                    return JsonResultSuccess("添加成功！");
                }
                else {
                    return JsonResultError("添加失败！");
                }
            }
            catch (Exception e) {
                return JsonResultError(e);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Delete(int? id) {
            if (id == null) {
                return JsonResultSuccess("删除成功！");
            }
            var model = await db.Column.FirstOrDefaultAsync(p => p.Id == id);
            if (model != null) {
                db.Column.Remove(model);
                await db.SaveChangesAsync();
            }
            return JsonResultSuccess("删除成功！");
        }

        #region 栏目分类有关
        public async Task<List<ColumnType>> GetTypeList() {
            return await db.ColumnType.ToListAsync();
        }
        #endregion
    }
}
