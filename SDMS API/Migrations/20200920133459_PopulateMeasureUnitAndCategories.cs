using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class PopulateMeasureUnitAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO MeasureUnits (Name) VALUES ('Pcs');
                INSERT INTO MeasureUnits (Name) VALUES ('Kg');

                INSERT INTO ProductCategories (Name) VALUES ('Pillow');
                INSERT INTO ProductCategories (Name) VALUES ('Comforter');
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
