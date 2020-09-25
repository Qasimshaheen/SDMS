using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedProductOpeningBalanceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOpeningBalanceMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherMasterId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOpeningBalanceMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOpeningBalanceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOBMId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOpeningBalanceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOpeningBalanceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOpeningBalanceDetails_ProductOpeningBalanceMasters_ProductOBMId",
                        column: x => x.ProductOBMId,
                        principalTable: "ProductOpeningBalanceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOpeningBalanceDetails_ProductId",
                table: "ProductOpeningBalanceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOpeningBalanceDetails_ProductOBMId",
                table: "ProductOpeningBalanceDetails",
                column: "ProductOBMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOpeningBalanceMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                column: "VoucherMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOpeningBalanceDetails");

            migrationBuilder.DropTable(
                name: "ProductOpeningBalanceMasters");
        }
    }
}
