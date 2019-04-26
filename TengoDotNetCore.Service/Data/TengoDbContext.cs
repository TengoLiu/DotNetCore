using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.Service.Data {
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

        /// <summary>
        /// 短信发送记录
        /// </summary>
        public DbSet<SMSLog> SMSLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //创建购物车Item的联合主键
            modelBuilder.Entity<CartItem>().HasKey(p => new { p.Goods_ID, p.User_Id });
        }
    }
}
