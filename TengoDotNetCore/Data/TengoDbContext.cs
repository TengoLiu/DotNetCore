using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Data {
    public class TengoDbContext : DbContext {

        public TengoDbContext(DbContextOptions<TengoDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<ArticleCategory> ArticleCategory { get; set; }

        public DbSet<CartItem> CartItem { get; set; }
    }
}
