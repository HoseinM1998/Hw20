using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OldCars_Cars_CarId",
                table: "OldCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OldCars",
                table: "OldCars");

            migrationBuilder.RenameTable(
                name: "OldCars",
                newName: "TechnicalExamination");

            migrationBuilder.RenameIndex(
                name: "IX_OldCars_CarId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExamination_Cars_CarId",
                table: "TechnicalExamination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExamination",
                table: "TechnicalExamination");

            migrationBuilder.RenameTable(
                name: "TechnicalExamination",
                newName: "OldCars");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExamination_CarId",
                table: "OldCars",
                newName: "IX_OldCars_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OldCars",
                table: "OldCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OldCars_Cars_CarId",
                table: "OldCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
