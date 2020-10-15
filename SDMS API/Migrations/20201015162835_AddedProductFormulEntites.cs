using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedProductFormulEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingMasters_ProductFormulaMaster_FormulaMasterId",
                table: "ManufacturingMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaDetail_ProductFormulaMaster_FormulaMasterId",
                table: "ProductFormulaDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaDetail_Products_ProductId",
                table: "ProductFormulaDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaMaster_Products_ProductId",
                table: "ProductFormulaMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFormulaMaster",
                table: "ProductFormulaMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFormulaDetail",
                table: "ProductFormulaDetail");

            migrationBuilder.RenameTable(
                name: "ProductFormulaMaster",
                newName: "ProductFormulaMasters");

            migrationBuilder.RenameTable(
                name: "ProductFormulaDetail",
                newName: "ProductFormulaDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaMaster_ProductId",
                table: "ProductFormulaMasters",
                newName: "IX_ProductFormulaMasters_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaDetail_ProductId",
                table: "ProductFormulaDetails",
                newName: "IX_ProductFormulaDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaDetail_FormulaMasterId",
                table: "ProductFormulaDetails",
                newName: "IX_ProductFormulaDetails_FormulaMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFormulaMasters",
                table: "ProductFormulaMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFormulaDetails",
                table: "ProductFormulaDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingMasters_ProductFormulaMasters_FormulaMasterId",
                table: "ManufacturingMasters",
                column: "FormulaMasterId",
                principalTable: "ProductFormulaMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaDetails_ProductFormulaMasters_FormulaMasterId",
                table: "ProductFormulaDetails",
                column: "FormulaMasterId",
                principalTable: "ProductFormulaMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaDetails_Products_ProductId",
                table: "ProductFormulaDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaMasters_Products_ProductId",
                table: "ProductFormulaMasters",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingMasters_ProductFormulaMasters_FormulaMasterId",
                table: "ManufacturingMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaDetails_ProductFormulaMasters_FormulaMasterId",
                table: "ProductFormulaDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaDetails_Products_ProductId",
                table: "ProductFormulaDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormulaMasters_Products_ProductId",
                table: "ProductFormulaMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFormulaMasters",
                table: "ProductFormulaMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFormulaDetails",
                table: "ProductFormulaDetails");

            migrationBuilder.RenameTable(
                name: "ProductFormulaMasters",
                newName: "ProductFormulaMaster");

            migrationBuilder.RenameTable(
                name: "ProductFormulaDetails",
                newName: "ProductFormulaDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaMasters_ProductId",
                table: "ProductFormulaMaster",
                newName: "IX_ProductFormulaMaster_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaDetails_ProductId",
                table: "ProductFormulaDetail",
                newName: "IX_ProductFormulaDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFormulaDetails_FormulaMasterId",
                table: "ProductFormulaDetail",
                newName: "IX_ProductFormulaDetail_FormulaMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFormulaMaster",
                table: "ProductFormulaMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFormulaDetail",
                table: "ProductFormulaDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingMasters_ProductFormulaMaster_FormulaMasterId",
                table: "ManufacturingMasters",
                column: "FormulaMasterId",
                principalTable: "ProductFormulaMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaDetail_ProductFormulaMaster_FormulaMasterId",
                table: "ProductFormulaDetail",
                column: "FormulaMasterId",
                principalTable: "ProductFormulaMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaDetail_Products_ProductId",
                table: "ProductFormulaDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormulaMaster_Products_ProductId",
                table: "ProductFormulaMaster",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
