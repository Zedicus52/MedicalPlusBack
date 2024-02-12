using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessEF.Migrations
{
    /// <inheritdoc />
    public partial class zed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGenderNavigationIdGender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdGenderNavigationIdGender",
                table: "AspNetUsers",
                column: "IdGenderNavigationIdGender");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_IdGenderNavigationIdGender",
                table: "AspNetUsers",
                column: "IdGenderNavigationIdGender",
                principalTable: "Genders",
                principalColumn: "IdGender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_IdGenderNavigationIdGender",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdGenderNavigationIdGender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdGender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdGenderNavigationIdGender",
                table: "AspNetUsers");
        }
    }
}
