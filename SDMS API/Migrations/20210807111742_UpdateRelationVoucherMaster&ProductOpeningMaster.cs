using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class UpdateRelationVoucherMasterProductOpeningMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductOpeningBalanceMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters",
                column: "VoucherMasterId");

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

            migrationBuilder.DropIndex(
                name: "IX_ProductOpeningBalanceMasters_VoucherMasterId",
                table: "ProductOpeningBalanceMasters");
        }
    }
}
