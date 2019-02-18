using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.Data {
    public class TengoDbContext : DbContext {

        public TengoDbContext(DbContextOptions<TengoDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
    }
}
