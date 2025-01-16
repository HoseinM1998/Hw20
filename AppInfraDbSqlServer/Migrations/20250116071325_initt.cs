using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExamination_Cars_CarId",
                table: "TechnicalExamination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExamination",
                table: "TechnicalExamination");

            migrationBuilder.RenameTable(
                name: "TechnicalExamination",
                newName: "TechnicalExaminations");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExamination_CarId",
                table: "TechnicalExaminations",
                newName: "IX_TechnicalExaminations_CarId");

            migrationBuilder.AddColumn<bool>(
                name: "IsOldCar",
                table: "TechnicalExaminations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "TechnicalExaminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "oldCarId",
                table: "TechnicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalExaminations",
                table: "TechnicalExaminations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OldCars",
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
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OldCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminations_oldCarId",
                table: "TechnicalExaminations",
                column: "oldCarId");

            migrationBuilder.CreateIndex(
                name: "IX_OldCars_CarId",
                table: "OldCars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminations_Cars_CarId",
                table: "TechnicalExaminations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminations_OldCars_oldCarId",
                table: "TechnicalExaminations",
                column: "oldCarId",
                principalTable: "OldCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminations_Cars_CarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminations_OldCars_oldCarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropTable(
                name: "OldCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExaminations",
                table: "TechnicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalExaminations_oldCarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropColumn(
                name: "IsOldCar",
                table: "TechnicalExaminations");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "TechnicalExaminations");

            migrationBuilder.DropColumn(
                name: "oldCarId",
                table: "TechnicalExaminations");

            migrationBuilder.RenameTable(
                name: "TechnicalExaminations",
                newName: "TechnicalExamination");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExaminations_CarId",
                table: "TechnicalExamination",
                newName: "IX_TechnicalExamination_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalExamination",
                table: "TechnicalExamination",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExamination_Cars_CarId",
                table: "TechnicalExamination",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
