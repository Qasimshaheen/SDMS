using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedManufacturingBillEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMaster_Users_AddedBy",
                table: "ManufacturingBillMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMaster_ManufacturingMasters_ManufacturingId",
                table: "ManufacturingBillMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMaster_Users_UpdatedBy",
                table: "ManufacturingBillMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMaster_VoucherMasters_VoucherMasterId",
                table: "ManufacturingBillMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillProductDetail_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillProductDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillProductDetail_Products_ProductId",
                table: "ManufacturingBillProductDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingBillProductDetail",
                table: "ManufacturingBillProductDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingBillMaster",
                table: "ManufacturingBillMaster");

            migrationBuilder.RenameTable(
                name: "ManufacturingBillProductDetail",
                newName: "ManufacturingBillProductDetails");

            migrationBuilder.RenameTable(
                name: "ManufacturingBillMaster",
                newName: "ManufacturingBillMasters");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillProductDetail_ProductId",
                table: "ManufacturingBillProductDetails",
                newName: "IX_ManufacturingBillProductDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillProductDetail_BillId",
                table: "ManufacturingBillProductDetails",
                newName: "IX_ManufacturingBillProductDetails_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMaster_VoucherMasterId",
                table: "ManufacturingBillMasters",
                newName: "IX_ManufacturingBillMasters_VoucherMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMaster_UpdatedBy",
                table: "ManufacturingBillMasters",
                newName: "IX_ManufacturingBillMasters_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMaster_ManufacturingId",
                table: "ManufacturingBillMasters",
                newName: "IX_ManufacturingBillMasters_ManufacturingId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMaster_AddedBy",
                table: "ManufacturingBillMasters",
                newName: "IX_ManufacturingBillMasters_AddedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingBillProductDetails",
                table: "ManufacturingBillProductDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingBillMasters",
                table: "ManufacturingBillMasters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMasters_BillId",
                table: "ManufacturingBillExpenses",
                column: "BillId",
                principalTable: "ManufacturingBillMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMasters_Users_AddedBy",
                table: "ManufacturingBillMasters",
                column: "AddedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMasters_ManufacturingMasters_ManufacturingId",
                table: "ManufacturingBillMasters",
                column: "ManufacturingId",
                principalTable: "ManufacturingMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMasters_Users_UpdatedBy",
                table: "ManufacturingBillMasters",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMasters_VoucherMasters_VoucherMasterId",
                table: "ManufacturingBillMasters",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillProductDetails_ManufacturingBillMasters_BillId",
                table: "ManufacturingBillProductDetails",
                column: "BillId",
                principalTable: "ManufacturingBillMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillProductDetails_Products_ProductId",
                table: "ManufacturingBillProductDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMasters_BillId",
                table: "ManufacturingBillExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMasters_Users_AddedBy",
                table: "ManufacturingBillMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMasters_ManufacturingMasters_ManufacturingId",
                table: "ManufacturingBillMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMasters_Users_UpdatedBy",
                table: "ManufacturingBillMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillMasters_VoucherMasters_VoucherMasterId",
                table: "ManufacturingBillMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillProductDetails_ManufacturingBillMasters_BillId",
                table: "ManufacturingBillProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingBillProductDetails_Products_ProductId",
                table: "ManufacturingBillProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingBillProductDetails",
                table: "ManufacturingBillProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingBillMasters",
                table: "ManufacturingBillMasters");

            migrationBuilder.RenameTable(
                name: "ManufacturingBillProductDetails",
                newName: "ManufacturingBillProductDetail");

            migrationBuilder.RenameTable(
                name: "ManufacturingBillMasters",
                newName: "ManufacturingBillMaster");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillProductDetails_ProductId",
                table: "ManufacturingBillProductDetail",
                newName: "IX_ManufacturingBillProductDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillProductDetails_BillId",
                table: "ManufacturingBillProductDetail",
                newName: "IX_ManufacturingBillProductDetail_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMasters_VoucherMasterId",
                table: "ManufacturingBillMaster",
                newName: "IX_ManufacturingBillMaster_VoucherMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMasters_UpdatedBy",
                table: "ManufacturingBillMaster",
                newName: "IX_ManufacturingBillMaster_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMasters_ManufacturingId",
                table: "ManufacturingBillMaster",
                newName: "IX_ManufacturingBillMaster_ManufacturingId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingBillMasters_AddedBy",
                table: "ManufacturingBillMaster",
                newName: "IX_ManufacturingBillMaster_AddedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingBillProductDetail",
                table: "ManufacturingBillProductDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingBillMaster",
                table: "ManufacturingBillMaster",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillExpenses_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillExpenses",
                column: "BillId",
                principalTable: "ManufacturingBillMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMaster_Users_AddedBy",
                table: "ManufacturingBillMaster",
                column: "AddedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMaster_ManufacturingMasters_ManufacturingId",
                table: "ManufacturingBillMaster",
                column: "ManufacturingId",
                principalTable: "ManufacturingMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMaster_Users_UpdatedBy",
                table: "ManufacturingBillMaster",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillMaster_VoucherMasters_VoucherMasterId",
                table: "ManufacturingBillMaster",
                column: "VoucherMasterId",
                principalTable: "VoucherMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillProductDetail_ManufacturingBillMaster_BillId",
                table: "ManufacturingBillProductDetail",
                column: "BillId",
                principalTable: "ManufacturingBillMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingBillProductDetail_Products_ProductId",
                table: "ManufacturingBillProductDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
