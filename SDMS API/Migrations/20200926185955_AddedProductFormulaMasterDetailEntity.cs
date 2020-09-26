using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedProductFormulaMasterDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductFormulaMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFormulaMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFormulaMaster_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFormulaDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaMasterId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFormulaDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFormulaDetail_ProductFormulaMaster_FormulaMasterId",
                        column: x => x.FormulaMasterId,
                        principalTable: "ProductFormulaMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFormulaDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFormulaDetail_FormulaMasterId",
                table: "ProductFormulaDetail",
                column: "FormulaMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFormulaDetail_ProductId",
                table: "ProductFormulaDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFormulaMaster_ProductId",
                table: "ProductFormulaMaster",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFormulaDetail");

            migrationBuilder.DropTable(
                name: "ProductFormulaMaster");
        }
    }
}
