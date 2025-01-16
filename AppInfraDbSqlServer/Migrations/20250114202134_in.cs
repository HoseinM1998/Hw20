using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalExamination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalExamination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalExamination_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarEnum", "Model" },
                values: new object[,]
                {
                    { 1, 1, "206 تیپ2" },
                    { 2, 1, "206 تیپ5" },
                    { 3, 1, "پارس" },
                    { 4, 1, "405 slx" },
                    { 5, 1, "تارا" },
                    { 6, 1, "دنا" },
                    { 7, 1, "رانا" },
                    { 8, 1, "207" },
                    { 9, 2, "پراید 111" },
                    { 10, 2, "پراید 131" },
                    { 11, 2, "کوییک" },
                    { 12, 2, "کوییک ار" },
                    { 13, 2, "کوییک اس" },
                    { 14, 2, "کوییک جی ایکس" },
                    { 15, 2, "ساینا" },
                    { 16, 2, "ساینا اس" },
                    { 17, 2, "شاهین" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Phone", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "12345@", "09913466961", 1, "Admin" },
                    { 2, "12345@", "03103905561", 1, "Admin2" },
                    { 3, "12345@", "03103905561", 1, "User" },
                    { 4, "12345@", "03103905561", 1, "User2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExamination_CarId",
                table: "TechnicalExamination",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalExamination");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
