using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class iniit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminations_OldCars_oldCarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalExaminations_oldCarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropColumn(
                name: "IsOldCar",
                table: "TechnicalExaminations");

            migrationBuilder.DropColumn(
                name: "oldCarId",
                table: "TechnicalExaminations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOldCar",
                table: "TechnicalExaminations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "oldCarId",
                table: "TechnicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminations_oldCarId",
                table: "TechnicalExaminations",
                column: "oldCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminations_OldCars_oldCarId",
                table: "TechnicalExaminations",
                column: "oldCarId",
                principalTable: "OldCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
