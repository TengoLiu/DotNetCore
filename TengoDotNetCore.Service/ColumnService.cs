using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class ColumnService : BaseService {
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
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Update(Column model) {
            try {
                // 判断栏目标题是否有重复
                bool isExistColumnTitle = await db.Column.AnyAsync(p => p.Title == model.Title && p.Id != model.Id);
                if (isExistColumnTitle) {
                    return JsonResultError("该标题已存在！");
                }

                var oldModel = db.Column.FirstOrDefault(p => p.Id == model.Id);
                oldModel.ColumnType_Id = model.ColumnType_Id;
                oldModel.Status = model.Status;
                oldModel.Title = model.Title.Trim();
                oldModel.ImgUrl = model.ImgUrl;
                oldModel.MImgUrl = model.MImgUrl;
                oldModel.Href = model.Href;
                oldModel.MHref = model.MHref;
                oldModel.Sort = model.Sort;
                oldModel.ValidStartTime = model.ValidStartTime;
                oldModel.ValidEndTime = model.ValidEndTime;
                oldModel.DoBeforeUpdate();
                int result = await db.SaveChangesAsync();
                if (result > 0) {
                    return JsonResultSuccess("更新成功！");
                }
                else {
                    return JsonResultError("更新失败！");
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

        public async Task<PageList<Column>> PageList(PageInfo pageInfo, string keyword = null, int typeId = 0, bool includeType = false) {
            var query = db.Column.AsQueryable();
            if (includeType) {
                query = query.Include(p => p.ColumnType);
            }
            if (!string.IsNullOrWhiteSpace(keyword)) {
                query = query.Where(p => p.Title.Contains(keyword));
            }
            if (typeId > 0) {
                query = query.Where(p => p.ColumnType_Id == typeId);
            }
            return await CreatePageAsync(query, pageInfo);
        }

        #region 栏目分类有关
        public async Task<List<ColumnType>> GetTypeList() {
            return await db.ColumnType.ToListAsync();
        }
        #endregion
    }
}
