using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class UpdatedProductledgerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInOut",
                table: "ProductLedgers");

            migrationBuilder.AddColumn<bool>(
                name: "IsOut",
                table: "ProductLedgers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOut",
                table: "ProductLedgers");

            migrationBuilder.AddColumn<bool>(
                name: "IsInOut",
                table: "ProductLedgers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
