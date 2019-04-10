using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 给商品添加一些属性2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Goods",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Goods",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Goods",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Goods");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Goods",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
