using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace TengoDotNetCore.Service.Impl {
    public class UserService : IUserService {
        /// <summary>
        /// 当前控制器私有的TengoDbContext对象，在构造函数中传入
        /// 在StartUp里面的IOC容器注册了之后，在执行请求的时候自动就会给我们生成一个并传进来
        /// </summary>
        private readonly TengoDbContext db;

        public UserService(TengoDbContext db) {
            this.db = db;
        }

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public async Task<PageList<User>> List(PageInfo pageInfo) {
            var query = db.Users.OrderByDescending(p => p.Id);
            return await PageList<User>.CreateAsync(query, pageInfo);
        }
    }
}
