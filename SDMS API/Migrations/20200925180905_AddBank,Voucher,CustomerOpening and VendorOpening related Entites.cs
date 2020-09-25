using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddBankVoucherCustomerOpeningandVendorOpeningrelatedEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OpeningAdvance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OpeningBalance",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OpeningReceipt",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OpeningAdvance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OpeningBalance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OpeningReceipt",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    VoucherType = table.Column<string>(maxLength: 2, nullable: true),
                    Narration = table.Column<string>(maxLength: 50, nullable: true),
                    TotalDebit = table.Column<decimal>(nullable: true),
                    TotalCredit = table.Column<decimal>(nullable: true),
                    IsPosted = table.Column<bool>(nullable: false),
                    ChequeDate = table.Column<DateTime>(nullable: true),
                    ChequeNo = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherMasters_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccoountDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(maxLength: 50, nullable: true),
                    COAId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    BankAccountTypeId = table.Column<int>(nullable: false),
                    AccountTitle = table.Column<string>(maxLength: 50, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccoountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccoountDetails_BankAccountTypes_BankAccountTypeId",
                        column: x => x.BankAccountTypeId,
                        principalTable: "BankAccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccoountDetails_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccoountDetails_ChartofAccounts_COAId",
                        column: x => x.COAId,
                        principalTable: "ChartofAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOpeningBalanceMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherMasterId = table.Column<int>(maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOpeningBalanceMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendorOpeningBalanceMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherMasterId = table.Column<int>(maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorOpeningBalanceMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendorOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherMasterId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(maxLength: 20, nullable: true),
                    VendorId = table.Column<int>(nullable: true),
                    COAId = table.Column<int>(nullable: false),
                    IsDebit = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_ChartofAccounts_COAId",
                        column: x => x.COAId,
                        principalTable: "ChartofAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_VoucherMasters_VoucherMasterId",
                        column: x => x.VoucherMasterId,
                        principalTable: "VoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOpeningBalanceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOBMId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(maxLength: 20, nullable: false),
                    OpeningBalance = table.Column<decimal>(nullable: false),
                    OpeningReceipt = table.Column<decimal>(nullable: false),
                    OpeningAdvance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOpeningBalanceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOpeningBalanceDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOpeningBalanceDetails_CustomerOpeningBalanceMasters_CustomerOBMId",
                        column: x => x.CustomerOBMId,
                        principalTable: "CustomerOpeningBalanceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendorOpeningBalanceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorOBMasterId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    OpeningBalance = table.Column<decimal>(nullable: false),
                    OpeningReceipt = table.Column<decimal>(nullable: false),
                    OpeningAdvance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorOpeningBalanceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendorOpeningBalanceDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendorOpeningBalanceDetails_vendorOpeningBalanceMasters_VendorOBMasterId",
                        column: x => x.VendorOBMasterId,
                        principalTable: "vendorOpeningBalanceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccoountDetails_BankAccountTypeId",
                table: "BankAccoountDetails",
                column: "BankAccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccoountDetails_BankId",
                table: "BankAccoountDetails",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccoountDetails_COAId",
                table: "BankAccoountDetails",
                column: "COAId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerId",
                table: "CustomerOpeningBalanceDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpeningBalanceDetails_CustomerOBMId",
                table: "CustomerOpeningBalanceDetails",
                column: "CustomerOBMId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpeningBalanceMasters_VoucherMasterId",
                table: "CustomerOpeningBalanceMasters",
                column: "VoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_vendorOpeningBalanceDetails_CustomerId",
                table: "vendorOpeningBalanceDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_vendorOpeningBalanceDetails_VendorOBMasterId",
                table: "vendorOpeningBalanceDetails",
                column: "VendorOBMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_vendorOpeningBalanceMasters_VoucherMasterId",
                table: "vendorOpeningBalanceMasters",
                column: "VoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_COAId",
                table: "VoucherDetails",
                column: "COAId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_CustomerId",
                table: "VoucherDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_VendorId",
                table: "VoucherDetails",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_VoucherMasterId",
                table: "VoucherDetails",
                column: "VoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_BankId",
                table: "VoucherMasters",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccoountDetails");

            migrationBuilder.DropTable(
                name: "CustomerOpeningBalanceDetails");

            migrationBuilder.DropTable(
                name: "vendorOpeningBalanceDetails");

            migrationBuilder.DropTable(
                name: "VoucherDetails");

            migrationBuilder.DropTable(
                name: "BankAccountTypes");

            migrationBuilder.DropTable(
                name: "CustomerOpeningBalanceMasters");

            migrationBuilder.DropTable(
                name: "vendorOpeningBalanceMasters");

            migrationBuilder.DropTable(
                name: "VoucherMasters");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.AddColumn<decimal>(
                name: "Advance",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningAdvance",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningBalance",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningReceipt",
                table: "Vendors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Advance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningAdvance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningBalance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningReceipt",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
