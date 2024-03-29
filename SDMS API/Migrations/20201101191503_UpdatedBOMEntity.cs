﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class UpdatedBOMEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ManufacturingBillProductDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ManufacturingBillProductDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ManufacturingBillProductDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ManufacturingBillProductDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
