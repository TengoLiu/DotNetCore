﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Migrations
{
    public partial class 添加文章与分类的关系 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article");

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

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Article",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ArticleCategory_CategoryID",
                table: "Article",
                column: "CategoryID",
                principalTable: "ArticleCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
