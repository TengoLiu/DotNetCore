using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.Service.Migrations
{
    public partial class 添加订单已经订单商品Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<int>(nullable: false),
                    UserNickName = table.Column<int>(nullable: false),
                    UserPhone = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    GoodsAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpressFee = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Orgin = table.Column<string>(nullable: true),
                    PaymentID = table.Column<int>(nullable: false),
                    PaymentName = table.Column<string>(nullable: true),
                    PayTime = table.Column<DateTime>(nullable: false),
                    PayStatus = table.Column<bool>(nullable: false),
                    ExpressSendName = table.Column<string>(nullable: true),
                    ExpressNo = table.Column<string>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    AddrProvince = table.Column<string>(nullable: true),
                    AddrCity = table.Column<string>(nullable: true),
                    AddrArea = table.Column<string>(nullable: true),
                    AddrDetail = table.Column<string>(nullable: true),
                    AddrPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderGoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Order_Id = table.Column<int>(nullable: false),
                    GoodId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    OrginalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RealPrice = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    CoverImg = table.Column<string>(nullable: true),
                    Specifications = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderGoods_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_Order_Id",
                table: "OrderGoods",
                column: "Order_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderGoods");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
