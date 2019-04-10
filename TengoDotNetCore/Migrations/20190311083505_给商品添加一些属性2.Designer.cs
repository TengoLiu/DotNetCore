﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TengoDotNetCore.Data;

namespace TengoDotNetCore.Migrations
{
    [DbContext(typeof(TengoDbContext))]
    [Migration("20190311083505_给商品添加一些属性2")]
    partial class 给商品添加一些属性2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TengoDotNetCore.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Area");

                    b.Property<string>("City");

                    b.Property<string>("Detail");

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Phone");

                    b.Property<string>("Province");

                    b.Property<string>("Tag");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CoverImg");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Keywords")
                        .HasMaxLength(128);

                    b.Property<string>("MContent");

                    b.Property<int>("Sort");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.ArticleCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("CoverImg");

                    b.Property<int>("Sort");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("ArticleCategory");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.CartItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int?>("GoodsID");

                    b.Property<int>("Qty");

                    b.Property<bool>("Selected");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GoodsID");

                    b.HasIndex("UserID");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Goods", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Content");

                    b.Property<string>("CoverImg");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Keywords")
                        .HasMaxLength(128);

                    b.Property<string>("MContent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NameEn");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Sort");

                    b.Property<int>("Status");

                    b.Property<int>("Stock");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Email");

                    b.Property<string>("LastIP");

                    b.Property<string>("LastTime");

                    b.Property<string>("NickName");

                    b.Property<string>("Phone");

                    b.Property<string>("RealName");

                    b.Property<string>("RegisterIP");

                    b.Property<string>("Source");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Address", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Article", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.ArticleCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.CartItem", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsID");

                    b.HasOne("TengoDotNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
