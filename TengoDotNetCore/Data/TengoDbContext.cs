using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.BLL.Data {
    public class TengoDbContext : DbContext {

        public TengoDbContext(DbContextOptions<TengoDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<ArticleType> ArticleType { get; set; }

        public DbSet<Column> Column { get; set; }

        public DbSet<ColumnType> ColumnType { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 短信发送记录
        /// </summary>
        public DbSet<SMSLog> SMSLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //创建购物车Item的联合主键
            modelBuilder.Entity<CartItem>().HasKey(p => new { p.Goods_ID, p.User_Id });
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
        /// 重写SaveChanges方法，主要是为了写入添加时间和更新时间
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
