using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 添加商品与商品分类的关系 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory");

            migrationBuilder.DropIndex(
                name: "IX_GoodsCategory_GoodsID",
                table: "GoodsCategory");

            migrationBuilder.DropColumn(
                name: "GoodsID",
                table: "GoodsCategory");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Article",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article",
                column: "CategoryID",
                principalTable: "ArticleCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article");

            migrationBuilder.AddColumn<int>(
                name: "GoodsID",
                table: "GoodsCategory",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Article",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_GoodsCategory_GoodsID",
                table: "GoodsCategory",
                column: "GoodsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article",
                column: "CategoryID",
                principalTable: "ArticleCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsCategory_Goods_GoodsID",
                table: "GoodsCategory",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
