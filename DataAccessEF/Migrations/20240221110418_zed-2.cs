using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessEF.Migrations
{
    /// <inheritdoc />
    public partial class zed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClinicalData",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCreateUser",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCreateUserNavigationId",
                table: "Problems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationDate",
                table: "Problems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_IdCreateUserNavigationId",
                table: "Problems",
                column: "IdCreateUserNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_IdCreateUserNavigationId",
                table: "Problems",
                column: "IdCreateUserNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_IdCreateUserNavigationId",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_IdCreateUserNavigationId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ClinicalData",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "IdCreateUser",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "IdCreateUserNavigationId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "OperationDate",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "Problems");
        }
    }
}
