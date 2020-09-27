using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedSalesOrderEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SOrderMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPerc = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOrderMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOrderMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPerc = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOrderDetails_SOrderMasters_SOrderId",
                        column: x => x.SOrderId,
                        principalTable: "SOrderMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SOrderDetails_ProductId",
                table: "SOrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SOrderDetails_SOrderId",
                table: "SOrderDetails",
                column: "SOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SOrderMasters_CustomerId",
                table: "SOrderMasters",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SOrderDetails");

            migrationBuilder.DropTable(
                name: "SOrderMasters");
        }
    }
}
