using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddBankOpeningBalanceEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceDetail_BankAccoountDetails_BankAccountDetailId",
                table: "BankOpeningBalanceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceDetail_BankOpeningBalanceMaster_BankOBMId",
                table: "BankOpeningBalanceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankOpeningBalanceMaster",
                table: "BankOpeningBalanceMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankOpeningBalanceDetail",
                table: "BankOpeningBalanceDetail");

            migrationBuilder.RenameTable(
                name: "BankOpeningBalanceMaster",
                newName: "BankOpeningBalanceMasters");

            migrationBuilder.RenameTable(
                name: "BankOpeningBalanceDetail",
                newName: "BankOpeningBalanceDetails");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceMaster_VoucherMasterId",
                table: "BankOpeningBalanceMasters",
                newName: "IX_BankOpeningBalanceMasters_VoucherMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceDetail_BankOBMId",
                table: "BankOpeningBalanceDetails",
                newName: "IX_BankOpeningBalanceDetails_BankOBMId");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceDetail_BankAccountDetailId",
                table: "BankOpeningBalanceDetails",
                newName: "IX_BankOpeningBalanceDetails_BankAccountDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankOpeningBalanceMasters",
                table: "BankOpeningBalanceMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankOpeningBalanceDetails",
                table: "BankOpeningBalanceDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceDetails_BankAccoountDetails_BankAccountDetailId",
                table: "BankOpeningBalanceDetails",
                column: "BankAccountDetailId",
                principalTable: "BankAccoountDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceDetails_BankOpeningBalanceMasters_BankOBMId",
                table: "BankOpeningBalanceDetails",
                column: "BankOBMId",
                principalTable: "BankOpeningBalanceMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceDetails_BankAccoountDetails_BankAccountDetailId",
                table: "BankOpeningBalanceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceDetails_BankOpeningBalanceMasters_BankOBMId",
                table: "BankOpeningBalanceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BankOpeningBalanceMasters_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankOpeningBalanceMasters",
                table: "BankOpeningBalanceMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankOpeningBalanceDetails",
                table: "BankOpeningBalanceDetails");

            migrationBuilder.RenameTable(
                name: "BankOpeningBalanceMasters",
                newName: "BankOpeningBalanceMaster");

            migrationBuilder.RenameTable(
                name: "BankOpeningBalanceDetails",
                newName: "BankOpeningBalanceDetail");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                newName: "IX_BankOpeningBalanceMaster_VoucherMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceDetails_BankOBMId",
                table: "BankOpeningBalanceDetail",
                newName: "IX_BankOpeningBalanceDetail_BankOBMId");

            migrationBuilder.RenameIndex(
                name: "IX_BankOpeningBalanceDetails_BankAccountDetailId",
                table: "BankOpeningBalanceDetail",
                newName: "IX_BankOpeningBalanceDetail_BankAccountDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankOpeningBalanceMaster",
                table: "BankOpeningBalanceMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankOpeningBalanceDetail",
                table: "BankOpeningBalanceDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceDetail_BankAccoountDetails_BankAccountDetailId",
                table: "BankOpeningBalanceDetail",
                column: "BankAccountDetailId",
                principalTable: "BankAccoountDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceDetail_BankOpeningBalanceMaster_BankOBMId",
                table: "BankOpeningBalanceDetail",
                column: "BankOBMId",
                principalTable: "BankOpeningBalanceMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankOpeningBalanceMaster_VoucherMasters_VoucherMasterId",
                table: "BankOpeningBalanceMaster",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
