 using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TengoDotNetCore.Common.BaseModels;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Admin;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.BLL.Data {
    public class TengoDbContext : DbContext {

        public static void Init(IServiceCollection services, string connection) {
            //注册DbContext到容器中，后面如果哪个地方要使用的话，就能直接给其注入了
            services.AddDbContext<TengoDbContext>(options => {
                //官方说明：在查询中使用row_number（）而不是offset/fetch。此方法向后兼容到SQL Server 2005。
                //第二个参数如果不写，那么如果是SQLSERVER2008的话，skip.take分页将无法使用，会有兼容问题
                //呵呵，到.net core3.0开始，居然不支持用skip和take对Sqlserver2008做分页了，简直......
                //抱歉，那我只能放弃使用Sqlserver了，转mysql！
                options.UseSqlServer(connection, a => a.UseRowNumberForPaging());

                //然而，转Mysql也并没有那么顺利，居然无法自动初始化数据库，难道还要我手工自己创建？
                //还是说，用回.net core2.2 ？
                //options.UseMySql(connection);
            });
        }

        public TengoDbContext(DbContextOptions<TengoDbContext> options) : base(options) { }

        #region 实体集定义
        public DbSet<User> User { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<ArticleType> ArticleType { get; set; }

        public DbSet<Column> Column { get; set; }

        public DbSet<ColumnType> ColumnType { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// 短信发送记录
        /// </summary>
        public DbSet<SMSLog> SMSLog { get; set; }

        public DbSet<ManagerRole> ManagerRole { get; set; }

        public DbSet<ManagerPermission> ManagerPermission { get; set; }

        public DbSet<ManagerRole_ManagerPermission> ManagerRole_ManagerPermission { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //创建购物车Item的联合主键
            modelBuilder.Entity<CartItem>().HasKey(p => new { p.GoodsID, p.UserId });

            modelBuilder.Entity<ManagerRole_ManagerPermission>().HasKey(p => new { p.ManagerRoleId, p.ManagerPermissionId });
        }

        /// <summary>
        /// 重写SaveChanges方法，主要是为了写入添加时间和更新时间
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges() {
            DoBeforeSaveChanges();
            return base.SaveChanges();
        }

        /// <summary>
        /// 重写SaveChangesAsync方法，主要是为了写入添加时间和更新时间
        /// </summary>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            DoBeforeSaveChanges();
            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// 在SaveChanges前调用，对新增或修改的实体做一些改动
        /// </summary>
        public void DoBeforeSaveChanges() {
            //先找出变化了的所有实体
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            //然后遍历这些变化了的实体，给它们写上添加时间和更新时间
            foreach (var entity in entities) {
                var baseModel = (BaseModel)entity.Entity;

                //如果是新增的实体的话，那么写入添加时间
                if (entity.State == EntityState.Added) {
                    baseModel.AddTime = DateTime.Now;
                }

                //更新时间是一定要写的
                baseModel.UpdateTime = DateTime.Now;
            }
        }
    }
}
