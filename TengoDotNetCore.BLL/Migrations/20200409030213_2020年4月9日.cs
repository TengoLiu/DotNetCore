using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TengoDotNetCore.BLL.Migrations
{
    public partial class _2020年4月9日 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false),
                    CoverImg = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    ParID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CoverImg = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColumnType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    CoverImg = table.Column<string>(nullable: true),
                    Albums = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    MContent = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Keywords = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryIdStr = table.Column<string>(nullable: true),
                    CategoryStr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PermissionType = table.Column<int>(nullable: false),
                    RoutePathList = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserNickName = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    GoodsAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpressFee = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RealAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
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
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMSLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    SendFor = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    ResultStr = table.Column<string>(nullable: true),
                    Success = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Account = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    NickName = table.Column<string>(maxLength: 20, nullable: false),
                    RealName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    LastIP = table.Column<string>(nullable: true),
                    LastTime = table.Column<DateTime>(nullable: false),
                    RegisterIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    ArticleTypeId = table.Column<int>(nullable: false),
                    CoverImg = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    MContent = table.Column<string>(nullable: true),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    Keywords = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleType_ArticleTypeId",
                        column: x => x.ArticleTypeId,
                        principalTable: "ArticleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ColumnTypeId = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    MImgUrl = table.Column<string>(nullable: true),
                    Href = table.Column<string>(nullable: true),
                    MHref = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    ValidStartTime = table.Column<DateTime>(nullable: false),
                    ValidEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Column_ColumnType_ColumnTypeId",
                        column: x => x.ColumnTypeId,
                        principalTable: "ColumnType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRole_ManagerPermission",
                columns: table => new
                {
                    ManagerRoleId = table.Column<int>(nullable: false),
                    ManagerPermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRole_ManagerPermission", x => new { x.ManagerRoleId, x.ManagerPermissionId });
                    table.ForeignKey(
                        name: "FK_ManagerRole_ManagerPermission_ManagerPermission_ManagerPermissionId",
                        column: x => x.ManagerPermissionId,
                        principalTable: "ManagerPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerRole_ManagerPermission_ManagerRole_ManagerRoleId",
                        column: x => x.ManagerRoleId,
                        principalTable: "ManagerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderGoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
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
                        name: "FK_OrderGoods_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Province = table.Column<string>(maxLength: 50, nullable: false),
                    Area = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Detail = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GoodsID = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => new { x.GoodsID, x.UserId });
                    table.ForeignKey(
                        name: "FK_CartItem_Goods_GoodsID",
                        column: x => x.GoodsID,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserID",
                table: "Address",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleTypeId",
                table: "Article",
                column: "ArticleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_UserId",
                table: "CartItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_ColumnTypeId",
                table: "Column",
                column: "ColumnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerRole_ManagerPermission_ManagerPermissionId",
                table: "ManagerRole_ManagerPermission",
                column: "ManagerPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_OrderId",
                table: "OrderGoods",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "ManagerRole_ManagerPermission");

            migrationBuilder.DropTable(
                name: "OrderGoods");

            migrationBuilder.DropTable(
                name: "SMSLog");

            migrationBuilder.DropTable(
                name: "ArticleType");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ColumnType");

            migrationBuilder.DropTable(
                name: "ManagerPermission");

            migrationBuilder.DropTable(
                name: "ManagerRole");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
