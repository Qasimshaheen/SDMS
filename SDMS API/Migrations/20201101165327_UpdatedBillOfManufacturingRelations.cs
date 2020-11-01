using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class UpdatedBillOfManufacturingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillProductDetail_BillDetailId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingBillExpenses_BillDetailId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropColumn(
                name: "BillDetailId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "ManufacturingBillExpenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillExpenses_BillId",
                table: "ManufacturingBillExpenses",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillExpenses",
                column: "BillId",
                principalTable: "ManufacturingBillMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingBillExpenses_BillId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.AddColumn<int>(
                name: "BillDetailId",
                table: "ManufacturingBillExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingBillExpenses_BillDetailId",
                table: "ManufacturingBillExpenses",
                column: "BillDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillProductDetail_BillDetailId",
                table: "ManufacturingBillExpenses",
                column: "BillDetailId",
                principalTable: "ManufacturingBillProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
