using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class RemoveExtraColumnsFromVouchersEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherMasters_Bank_BankId",
                table: "VoucherMasters");

            migrationBuilder.DropIndex(
                name: "IX_VoucherMasters_BankId",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "VoucherDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "VoucherMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "VoucherDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_BankId",
                table: "VoucherMasters",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherMasters_Bank_BankId",
                table: "VoucherMasters",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
