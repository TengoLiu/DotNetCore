using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class ChangeProduct2Goods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "GoodsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_GoodsId");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Goods_GoodsId",
                table: "CartItems",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Goods_GoodsId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.RenameColumn(
                name: "GoodsId",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_GoodsId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
