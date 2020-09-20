using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedChartofAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostOfGoodsSoldCOAId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryCOAId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleCOAId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleDiscountCOAId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleReturnCOAId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChartofAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: true),
                    IsDebit = table.Column<bool>(nullable: false),
                    ParentAccountId = table.Column<int>(nullable: true),
                    IsDetailAccount = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartofAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartofAccounts_ChartofAccounts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalTable: "ChartofAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CostOfGoodsSoldCOAId",
                table: "Products",
                column: "CostOfGoodsSoldCOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryCOAId",
                table: "Products",
                column: "InventoryCOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleCOAId",
                table: "Products",
                column: "SaleCOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleDiscountCOAId",
                table: "Products",
                column: "SaleDiscountCOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleReturnCOAId",
                table: "Products",
                column: "SaleReturnCOAId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartofAccounts_ParentAccountId",
                table: "ChartofAccounts",
                column: "ParentAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChartofAccounts_CostOfGoodsSoldCOAId",
                table: "Products",
                column: "CostOfGoodsSoldCOAId",
                principalTable: "ChartofAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChartofAccounts_InventoryCOAId",
                table: "Products",
                column: "InventoryCOAId",
                principalTable: "ChartofAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChartofAccounts_SaleCOAId",
                table: "Products",
                column: "SaleCOAId",
                principalTable: "ChartofAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChartofAccounts_SaleDiscountCOAId",
                table: "Products",
                column: "SaleDiscountCOAId",
                principalTable: "ChartofAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChartofAccounts_SaleReturnCOAId",
                table: "Products",
                column: "SaleReturnCOAId",
                principalTable: "ChartofAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChartofAccounts_CostOfGoodsSoldCOAId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChartofAccounts_InventoryCOAId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChartofAccounts_SaleCOAId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChartofAccounts_SaleDiscountCOAId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChartofAccounts_SaleReturnCOAId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ChartofAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Products_CostOfGoodsSoldCOAId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryCOAId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleCOAId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleDiscountCOAId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleReturnCOAId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CostOfGoodsSoldCOAId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryCOAId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleCOAId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleDiscountCOAId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleReturnCOAId",
                table: "Products");
        }
    }
}
