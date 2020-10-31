using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class EditNullableVoucherMasterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
