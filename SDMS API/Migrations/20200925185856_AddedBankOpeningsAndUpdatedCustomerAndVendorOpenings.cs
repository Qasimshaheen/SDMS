using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedBankOpeningsAndUpdatedCustomerAndVendorOpenings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendorOpeningBalanceDetails_Customers_CustomerId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.DropIndex(
                name: "IX_vendorOpeningBalanceDetails_CustomerId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerId",
                table: "CustomerOpeningBalanceDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "vendorOpeningBalanceDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankOpeningBalanceMaster",
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
                    table.PrimaryKey("PK_BankOpeningBalanceMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankOpeningBalanceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankOBMId = table.Column<int>(nullable: false),
                    BankAccountDetailId = table.Column<int>(nullable: true),
                    OpeningBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankOpeningBalanceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankOpeningBalanceDetail_BankAccoountDetails_BankAccountDetailId",
                        column: x => x.BankAccountDetailId,
                        principalTable: "BankAccoountDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankOpeningBalanceDetail_BankOpeningBalanceMaster_BankOBMId",
                        column: x => x.BankOBMId,
                        principalTable: "BankOpeningBalanceMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vendorOpeningBalanceDetails_VendorId",
                table: "vendorOpeningBalanceDetails",
                column: "VendorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerId",
                table: "CustomerOpeningBalanceDetails",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankOpeningBalanceDetail_BankAccountDetailId",
                table: "BankOpeningBalanceDetail",
                column: "BankAccountDetailId",
                unique: true,
                filter: "[BankAccountDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankOpeningBalanceDetail_BankOBMId",
                table: "BankOpeningBalanceDetail",
                column: "BankOBMId");

            migrationBuilder.CreateIndex(
                name: "IX_BankOpeningBalanceMaster_VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                column: "VoucherMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_vendorOpeningBalanceDetails_Vendors_VendorId",
                table: "vendorOpeningBalanceDetails",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendorOpeningBalanceDetails_Vendors_VendorId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.DropTable(
                name: "BankOpeningBalanceDetail");

            migrationBuilder.DropTable(
                name: "BankOpeningBalanceMaster");

            migrationBuilder.DropIndex(
                name: "IX_vendorOpeningBalanceDetails_VendorId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerId",
                table: "CustomerOpeningBalanceDetails");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "vendorOpeningBalanceDetails");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "vendorOpeningBalanceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vendorOpeningBalanceDetails_CustomerId",
                table: "vendorOpeningBalanceDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerId",
                table: "CustomerOpeningBalanceDetails",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_vendorOpeningBalanceDetails_Customers_CustomerId",
                table: "vendorOpeningBalanceDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
