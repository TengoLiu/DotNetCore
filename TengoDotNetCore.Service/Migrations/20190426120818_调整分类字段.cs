using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Service.Migrations
{
    public partial class 调整分类字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryJson",
                table: "Goods",
                newName: "CategoryStr");

            migrationBuilder.AddColumn<string>(
                name: "CategoryIdStr",
                table: "Goods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIdStr",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "CategoryStr",
                table: "Goods",
                newName: "CategoryJson");
        }
    }
}
