using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedSalesRelatedEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "VoucherDetails",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "SOrderMasters",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "SOrderMasters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "SOrderMasters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "SOrderMasters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "SOrderMasters",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PurchaseMasters",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ProductLedgers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SalesMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOrderId = table.Column<int>(nullable: true),
                    VoucherMasterId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPerc = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    IsPosted = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesMasters_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesMasters_SOrderMasters_SOrderId",
                        column: x => x.SOrderId,
                        principalTable: "SOrderMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesMasters_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesMasters_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesMasterId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPerc = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesMasters_SalesMasterId",
                        column: x => x.SalesMasterId,
                        principalTable: "SalesMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SOrderMasters_AddedBy",
                table: "SOrderMasters",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SOrderMasters_UpdatedBy",
                table: "SOrderMasters",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_ProductId",
                table: "SalesDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_WarehouseId",
                table: "SalesDetails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMasters_AddedBy",
                table: "SalesMasters",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMasters_CustomerId",
                table: "SalesMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMasters_SOrderId",
                table: "SalesMasters",
                column: "SOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMasters_UpdatedBy",
                table: "SalesMasters",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMasters_VoucherMasterId",
                table: "SalesMasters",
                column: "VoucherMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SOrderMasters_Users_AddedBy",
                table: "SOrderMasters",
                column: "AddedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SOrderMasters_Users_UpdatedBy",
                table: "SOrderMasters",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOrderMasters_Users_AddedBy",
                table: "SOrderMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_SOrderMasters_Users_UpdatedBy",
                table: "SOrderMasters");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "SalesMasters");

            migrationBuilder.DropIndex(
                name: "IX_SOrderMasters_AddedBy",
                table: "SOrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_SOrderMasters_UpdatedBy",
                table: "SOrderMasters");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "SOrderMasters");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "SOrderMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SOrderMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "SOrderMasters");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "VoucherDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "SOrderMasters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PurchaseMasters",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ProductLedgers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
