using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExamination_Car_CarId",
                table: "TechnicalExamination");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExamination_TechnicalExamination_TechnicalExaminationId",
                table: "TechnicalExamination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExamination",
                table: "TechnicalExamination");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalExamination_TechnicalExaminationId",
                table: "TechnicalExamination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TechnicalExaminationId",
                table: "TechnicalExamination");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TechnicalExamination",
                newName: "TechnicalExaminations");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExamination_CarId",
                table: "TechnicalExaminations",
                newName: "IX_TechnicalExaminations_CarId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "TechnicalExaminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalExaminations",
                table: "TechnicalExaminations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OldCarsCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalExaminationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldCarsCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OldCarsCars_TechnicalExaminations_TechnicalExaminationId",
                        column: x => x.TechnicalExaminationId,
                        principalTable: "TechnicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OldCarsCars_TechnicalExaminationId",
                table: "OldCarsCars",
                column: "TechnicalExaminationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminations_Cars_CarId",
                table: "TechnicalExaminations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminations_Cars_CarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropTable(
                name: "OldCarsCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExaminations",
                table: "TechnicalExaminations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "TechnicalExaminations");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TechnicalExaminations",
                newName: "TechnicalExamination");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExaminations_CarId",
                table: "TechnicalExamination",
                newName: "IX_TechnicalExamination_CarId");

            migrationBuilder.AddColumn<int>(
                name: "TechnicalExaminationId",
                table: "TechnicalExamination",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalExamination",
                table: "TechnicalExamination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExamination_TechnicalExaminationId",
                table: "TechnicalExamination",
                column: "TechnicalExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExamination_Car_CarId",
                table: "TechnicalExamination",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExamination_TechnicalExamination_TechnicalExaminationId",
                table: "TechnicalExamination",
                column: "TechnicalExaminationId",
                principalTable: "TechnicalExamination",
                principalColumn: "Id");
        }
    }
}
