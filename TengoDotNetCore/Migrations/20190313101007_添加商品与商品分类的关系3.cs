using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 添加商品与商品分类的关系3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsCategory",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "CoverImg",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "GoodsCategory");

            migrationBuilder.RenameColumn(
                name: "Sort",
                table: "GoodsCategory",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "ParID",
                table: "GoodsCategory",
                newName: "GoodsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsCategory",
                table: "GoodsCategory",
                columns: new[] { "GoodsID", "CategoryID" });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    ParID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    CoverImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsCategory_CategoryID",
                table: "GoodsCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsCategory_Category_CategoryID",
                table: "GoodsCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsCategory_Category_CategoryID",
                table: "GoodsCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsCategory",
                table: "GoodsCategory");

            migrationBuilder.DropIndex(
                name: "IX_GoodsCategory_CategoryID",
                table: "GoodsCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "GoodsCategory",
                newName: "Sort");

            migrationBuilder.RenameColumn(
                name: "GoodsID",
                table: "GoodsCategory",
                newName: "ParID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "GoodsCategory",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "GoodsCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CoverImg",
                table: "GoodsCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "GoodsCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GoodsCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "GoodsCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsCategory",
                table: "GoodsCategory",
                column: "ID");
        }
    }
}
