using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 给商品添加一些属性 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImg",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MContent",
                table: "Goods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "CoverImg",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "MContent",
                table: "Goods");
        }
    }
}
