using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Logs;

namespace TengoDotNetCore.Data {
    public class TengoDbContext : DbContext {

        public TengoDbContext(DbContextOptions<TengoDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<GoodsCategory> GoodsCategory { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<ArticleCategory> ArticleCategory { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public DbSet<Album> Album { get; set; }

        /// <summary>
        /// 短信发送记录
        /// </summary>
        public DbSet<SMSLog> SMSLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            #region 添加商品和分类之间的多对多关系
            modelBuilder.Entity<GoodsCategory>()
                .HasKey(t => new { t.GoodsID, t.CategoryID });

            modelBuilder.Entity<GoodsCategory>()
                .HasOne(gc => gc.Goods)
                .WithMany(p => p.GoodsCategory)
                .HasForeignKey(g => g.GoodsID);

            modelBuilder.Entity<GoodsCategory>()
                .HasOne(gc => gc.Category)
                .WithMany(c => c.GoodsCategory)
                .HasForeignKey(c => c.CategoryID);
            #endregion
        }
    }
}
