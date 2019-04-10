using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 给商品添加分类关系 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsID",
                table: "GoodsCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsCategory_GoodsID",
                table: "GoodsCategory",
                column: "GoodsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory");

            migrationBuilder.DropIndex(
                name: "IX_GoodsCategory_GoodsID",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "GoodsID",
                table: "GoodsCategory");
        }
    }
}
