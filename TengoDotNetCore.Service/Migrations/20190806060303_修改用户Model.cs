using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Service.Migrations
{
    public partial class 修改用户Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "User",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "User",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
