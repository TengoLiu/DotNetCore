﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Service.Base;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service {
    public class AddressService : BaseService {
        public AddressService(TengoDbContext db) : base(db) { }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Address> Get(int id) {
            var model = await db.Address.FirstOrDefaultAsync(p => p.Id == id);
            return model;
        }

        /// <summary>
        /// 获取用户的收货地址列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Address>> GetAll(int userId) {
            return await db.Address.Where(p => p.User_ID == userId).ToListAsync();
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
