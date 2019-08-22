using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Service.Migrations
{
    public partial class 修改用户Model上次登录时间类型 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTime",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastTime",
                table: "User",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
