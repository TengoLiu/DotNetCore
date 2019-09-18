using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class AddressService : BaseService<Address> {
        public AddressService(TengoDbContext db) : base(db) { }

        public override async Task<Address> Get(Expression<Func<Address, bool>> where, params Expression<Func<Address, Property>>[] includes) {
            return await CreateQueryable(db.Address, where, includes).FirstOrDefaultAsync();
        }

        public override async Task<List<Address>> GetList(Expression<Func<Address, bool>> where, params Expression<Func<Address, Property>>[] includes) {
            return await CreateQueryable(db.Address, where, includes).ToListAsync();
        }

        public override async Task<List<Address>> GetList(Expression<Func<Address, bool>> where, int rowCount, params Expression<Func<Address, Property>>[] includes) {
            return await CreateQueryable(db.Address, where, includes).Take(rowCount).ToListAsync();
        }

        public override async Task<PageList<Address>> GetPageList(int page, int pageSize, Expression<Func<Address, bool>> where, params Expression<Func<Address, Property>>[] includes) {
            return await CreatePageAsync(CreateQueryable(db.Address, where, includes), page, pageSize);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<JsonResultObj> Insert(Address model) {
            try {
                model.DoBeforeInsert();
                db.Address.Add(model);
                await db.SaveChangesAsync();
                return JsonResultSuccess("添加成功！");
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
        public async Task<JsonResultObj> Update(Address model) {
            try {
                model.DoBeforeUpdate();
                //标明哪些字段变动了
                db.Entry(model).Property(p => p.Phone).IsModified = true;
                db.Entry(model).Property(p => p.Province).IsModified = true;
                db.Entry(model).Property(p => p.Area).IsModified = true;
                db.Entry(model).Property(p => p.City).IsModified = true;
                db.Entry(model).Property(p => p.Detail).IsModified = true;
                db.Entry(model).Property(p => p.Tag).IsModified = true;
                db.Entry(model).Property(p => p.IsDefault).IsModified = true;
                db.Entry(model).Property(p => p.UpdateTime).IsModified = true;
                await db.SaveChangesAsync();
                return JsonResultSuccess("更新成功！");
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
            var model = await db.Address.SingleOrDefaultAsync(p => p.Id == id);
            if (model != null) {
                db.Address.Remove(model);
                await db.SaveChangesAsync();
            }
            return JsonResultSuccess("删除成功！");
        }


    }
}
