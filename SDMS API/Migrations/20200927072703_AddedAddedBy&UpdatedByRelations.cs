using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDMS_API.Migrations
{
    public partial class AddedAddedByUpdatedByRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "VoucherMasters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "VoucherMasters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "VoucherMasters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "VoucherMasters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "ProductLedgers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "ProductLedgers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ProductLedgers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ProductLedgers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_AddedBy",
                table: "VoucherMasters",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_UpdatedBy",
                table: "VoucherMasters",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedgers_AddedBy",
                table: "ProductLedgers",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedgers_UpdatedBy",
                table: "ProductLedgers",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLedgers_Users_AddedBy",
                table: "ProductLedgers",
                column: "AddedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLedgers_Users_UpdatedBy",
                table: "ProductLedgers",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherMasters_Users_AddedBy",
                table: "VoucherMasters",
                column: "AddedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherMasters_Users_UpdatedBy",
                table: "VoucherMasters",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLedgers_Users_AddedBy",
                table: "ProductLedgers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLedgers_Users_UpdatedBy",
                table: "ProductLedgers");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherMasters_Users_AddedBy",
                table: "VoucherMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherMasters_Users_UpdatedBy",
                table: "VoucherMasters");

            migrationBuilder.DropIndex(
                name: "IX_VoucherMasters_AddedBy",
                table: "VoucherMasters");

            migrationBuilder.DropIndex(
                name: "IX_VoucherMasters_UpdatedBy",
                table: "VoucherMasters");

            migrationBuilder.DropIndex(
                name: "IX_ProductLedgers_AddedBy",
                table: "ProductLedgers");

            migrationBuilder.DropIndex(
                name: "IX_ProductLedgers_UpdatedBy",
                table: "ProductLedgers");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "VoucherMasters");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "ProductLedgers");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "ProductLedgers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductLedgers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ProductLedgers");
        }
    }
}
