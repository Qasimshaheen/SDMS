using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedPurchaseAndManufacturingEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaMasterId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true),
                    WarehouseId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingMasters_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingMasters_ProductFormulaMaster_FormulaMasterId",
                        column: x => x.FormulaMasterId,
                        principalTable: "ProductFormulaMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingMasters_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturingMasters_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturingMasters_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    VoucherMasterId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPerc = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 80, nullable: true),
                    IsPosted = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingMasterId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingDetails_ManufacturingMasters_ManufacturingMasterId",
                        column: x => x.ManufacturingMasterId,
                        principalTable: "ManufacturingMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseMasterId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_PurchaseMasters_PurchaseMasterId",
                        column: x => x.PurchaseMasterId,
                        principalTable: "PurchaseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingRawDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingDetailMasterId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: true),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingRawDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingRawDetails_ManufacturingDetails_ManufacturingDetailMasterId",
                        column: x => x.ManufacturingDetailMasterId,
                        principalTable: "ManufacturingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingRawDetails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingDetails_ManufacturingMasterId",
                table: "ManufacturingDetails",
                column: "ManufacturingMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingDetails_ProductId",
                table: "ManufacturingDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingMasters_AddedBy",
                table: "ManufacturingMasters",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingMasters_FormulaMasterId",
                table: "ManufacturingMasters",
                column: "FormulaMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingMasters_ProductId",
                table: "ManufacturingMasters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingMasters_UpdatedBy",
                table: "ManufacturingMasters",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingMasters_WarehouseId",
                table: "ManufacturingMasters",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingRawDetails_ManufacturingDetailMasterId",
                table: "ManufacturingRawDetails",
                column: "ManufacturingDetailMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingRawDetails_WarehouseId",
                table: "ManufacturingRawDetails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ProductId",
                table: "PurchaseDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseMasterId",
                table: "PurchaseDetails",
                column: "PurchaseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_AddedBy",
                table: "PurchaseMasters",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_UpdatedBy",
                table: "PurchaseMasters",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_VendorId",
                table: "PurchaseMasters",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_VoucherMasterId",
                table: "PurchaseMasters",
                column: "VoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_WarehouseId",
                table: "PurchaseMasters",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturingRawDetails");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "ManufacturingDetails");

            migrationBuilder.DropTable(
                name: "PurchaseMasters");

            migrationBuilder.DropTable(
                name: "ManufacturingMasters");
        }
    }
}
