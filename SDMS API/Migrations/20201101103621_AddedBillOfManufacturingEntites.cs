using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedBillOfManufacturingEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingBillMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingId = table.Column<int>(nullable: true),
                    VoucherMasterId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    RawMaterialCost = table.Column<decimal>(nullable: false),
                    ExpenseCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingBillMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillMaster_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillMaster_ManufacturingMasters_ManufacturingId",
                        column: x => x.ManufacturingId,
                        principalTable: "ManufacturingMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillMaster_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillMaster_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingBillProductDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    BatchNo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingBillProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillProductDetail_ManufacturingBillMaster_BillId",
                        column: x => x.BillId,
                        principalTable: "ManufacturingBillMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillProductDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingBillExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillDetailId = table.Column<int>(nullable: false),
                    COAId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingBillExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillExpenses_ManufacturingBillProductDetail_BillDetailId",
                        column: x => x.BillDetailId,
                        principalTable: "ManufacturingBillProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingBillExpenses_ChartofAccounts_COAId",
                        column: x => x.COAId,
                        principalTable: "ChartofAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillExpenses_BillDetailId",
                table: "ManufacturingBillExpenses",
                column: "BillDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillExpenses_COAId",
                table: "ManufacturingBillExpenses",
                column: "COAId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillMaster_AddedBy",
                table: "ManufacturingBillMaster",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillMaster_ManufacturingId",
                table: "ManufacturingBillMaster",
                column: "ManufacturingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillMaster_UpdatedBy",
                table: "ManufacturingBillMaster",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillMaster_VoucherMasterId",
                table: "ManufacturingBillMaster",
                column: "VoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillProductDetail_BillId",
                table: "ManufacturingBillProductDetail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillProductDetail_ProductId",
                table: "ManufacturingBillProductDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturingBillExpenses");

            migrationBuilder.DropTable(
                name: "ManufacturingBillProductDetail");

            migrationBuilder.DropTable(
                name: "ManufacturingBillMaster");
        }
    }
}
