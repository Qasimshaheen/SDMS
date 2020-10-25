using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedWarehouseFieldInProductOpeningDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "ProductOpeningBalanceDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOpeningBalanceDetails_WarehouseId",
                table: "ProductOpeningBalanceDetails",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOpeningBalanceDetails_Warehouses_WarehouseId",
                table: "ProductOpeningBalanceDetails",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOpeningBalanceDetails_Warehouses_WarehouseId",
                table: "ProductOpeningBalanceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductOpeningBalanceDetails_WarehouseId",
                table: "ProductOpeningBalanceDetails");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "ProductOpeningBalanceDetails");
        }
    }
}
