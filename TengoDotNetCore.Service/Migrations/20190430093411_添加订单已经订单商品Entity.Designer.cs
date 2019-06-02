﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TengoDotNetCore.Service.Data;

namespace TengoDotNetCore.Service.Migrations
{
    [DbContext(typeof(TengoDbContext))]
    [Migration("20190430093411_添加订单已经订单商品Entity")]
    partial class 添加订单已经订单商品Entity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TengoDotNetCore.Models.Address", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int>("User_ID");

                    b.HasKey("Id");

                    b.HasIndex("User_ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("ArticleType_Id");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Content");

                    b.Property<string>("CoverImg");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Keywords")
                        .HasMaxLength(128);

                    b.Property<string>("LinkUrl");

                    b.Property<string>("MContent");

                    b.Property<int>("Sort");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("ArticleType_Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.ArticleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("CoverImg");

                    b.Property<int>("Sort");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("ArticleType");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.CartItem", b =>
                {
                    b.Property<int>("Goods_ID");

                    b.Property<int>("User_Id");

                    b.Property<int>("Qty");

                    b.Property<bool>("Selected");

                    b.HasKey("Goods_ID", "User_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("CoverImg");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ParID");

                    b.Property<int>("Sort");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("ColumnType_Id");

                    b.Property<string>("Href");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("MHref");

                    b.Property<string>("MImgUrl");

                    b.Property<int>("Sort");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdateTime");

                    b.Property<DateTime>("ValidEndTime");

                    b.Property<DateTime>("ValidStartTime");

                    b.HasKey("Id");

                    b.HasIndex("ColumnType_Id");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.ColumnType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("ColumnType");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Albums");

                    b.Property<string>("CategoryIdStr");

                    b.Property<string>("CategoryStr");

                    b.Property<string>("Content");

                    b.Property<string>("CoverImg");

                    b.Property<string>("Description");

                    b.Property<string>("Keywords");

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

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Logs.SMSLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Code");

                    b.Property<string>("Content");

                    b.Property<string>("Mobile");

                    b.Property<string>("Platform");

                    b.Property<string>("ResultStr");

                    b.Property<string>("SendFor");

                    b.Property<bool>("Success");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SMSLog");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddrArea");

                    b.Property<string>("AddrCity");

                    b.Property<string>("AddrDetail");

                    b.Property<string>("AddrPhone");

                    b.Property<string>("AddrProvince");

                    b.Property<decimal>("ExpressFee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ExpressNo");

                    b.Property<string>("ExpressSendName");

                    b.Property<decimal>("GoodsAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("IsSend");

                    b.Property<string>("Message");

                    b.Property<string>("Orgin");

                    b.Property<bool>("PayStatus");

                    b.Property<DateTime>("PayTime");

                    b.Property<int>("PaymentID");

                    b.Property<string>("PaymentName");

                    b.Property<string>("Remark");

                    b.Property<DateTime>("SendTime");

                    b.Property<string>("SerialNumber");

                    b.Property<int>("Status");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserID");

                    b.Property<int>("UserName");

                    b.Property<int>("UserNickName");

                    b.Property<int>("UserPhone");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.OrderGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("CoverImg");

                    b.Property<int>("GoodId");

                    b.Property<string>("GoodsName");

                    b.Property<int>("Order_Id");

                    b.Property<decimal>("OrginalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Qty");

                    b.Property<decimal>("RealPrice")
                        .HasColumnType("decimal(18, 5)");

                    b.Property<string>("Specifications");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("OrderGoods");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.User", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Address", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Article", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.ArticleType", "ArticleType")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleType_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TengoDotNetCore.Models.CartItem", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("Goods_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TengoDotNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TengoDotNetCore.Models.Column", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.ColumnType", "ColumnType")
                        .WithMany()
                        .HasForeignKey("ColumnType_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TengoDotNetCore.Models.OrderGoods", b =>
                {
                    b.HasOne("TengoDotNetCore.Models.Order", "Order")
                        .WithMany("GoodsList")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
