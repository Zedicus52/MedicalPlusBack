using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessEF.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    IdDifficulty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.IdDifficulty);
                });

            migrationBuilder.CreateTable(
                name: "FIOs",
                columns: table => new
                {
                    IdFio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIOes", x => x.IdFio);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    IdGender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.IdGender);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: true),
                    IdFio = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_FIOs",
                        column: x => x.IdFio,
                        principalTable: "FIOs",
                        principalColumn: "IdFio");
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: true),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.IdLog);
                    table.ForeignKey(
                        name: "FK_Logs_Actions",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction");
                    table.ForeignKey(
                        name: "FK_Logs_Users",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    IdProblem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdDifficulty = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MicroDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacroDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.IdProblem);
                    table.ForeignKey(
                        name: "FK_Problems_Difficulties",
                        column: x => x.IdDifficulty,
                        principalTable: "Difficulties",
                        principalColumn: "IdDifficulty");
                    table.ForeignKey(
                        name: "FK_Problems_Users",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProblem = table.Column<int>(type: "int", nullable: true),
                    IdGender = table.Column<int>(type: "int", nullable: true),
                    IdFio = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patients_FIOs",
                        column: x => x.IdFio,
                        principalTable: "FIOs",
                        principalColumn: "IdFio");
                    table.ForeignKey(
                        name: "FK_Patients_Genders",
                        column: x => x.IdGender,
                        principalTable: "Genders",
                        principalColumn: "IdGender");
                    table.ForeignKey(
                        name: "FK_Patients_Problems",
                        column: x => x.IdProblem,
                        principalTable: "Problems",
                        principalColumn: "IdProblem");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IdAction",
                table: "Logs",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IdUser",
                table: "Logs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdFio",
                table: "Patients",
                column: "IdFio");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdGender",
                table: "Patients",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdProblem",
                table: "Patients",
                column: "IdProblem");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_IdDifficulty",
                table: "Problems",
                column: "IdDifficulty");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_IdUser",
                table: "Problems",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdFio",
                table: "Users",
                column: "IdFio");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FIOs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
