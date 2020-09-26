using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedProductLedgerEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TransNo = table.Column<string>(maxLength: 20, nullable: true),
                    IsInOut = table.Column<bool>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true),
                    WarehouseId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLedgers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLedgers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedgers_ProductId",
                table: "ProductLedgers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedgers_WarehouseId",
                table: "ProductLedgers",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLedgers");
        }
    }
}
