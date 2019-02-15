using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Source");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastIP",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastTime",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterIP",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastIP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RealName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisterIP",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Users",
                newName: "Name");
        }
    }
}
