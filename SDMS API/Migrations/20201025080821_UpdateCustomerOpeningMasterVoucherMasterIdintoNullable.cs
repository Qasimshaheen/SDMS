using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class UpdateCustomerOpeningMasterVoucherMasterIdintoNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "CustomerOpeningBalanceMasters");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "CustomerOpeningBalanceMasters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "CustomerOpeningBalanceMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "CustomerOpeningBalanceMasters");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "CustomerOpeningBalanceMasters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "CustomerOpeningBalanceMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
