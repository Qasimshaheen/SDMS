using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedCodeColumntoManufacturingMasterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ManufacturingMasters",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ManufacturingMasters");
        }
    }
}
