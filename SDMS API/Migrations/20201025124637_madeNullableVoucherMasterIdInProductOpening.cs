using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class madeNullableVoucherMasterIdInProductOpening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
