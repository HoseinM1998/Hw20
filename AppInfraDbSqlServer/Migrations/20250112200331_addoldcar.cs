using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class addoldcar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminations_Cars_CarId",
                table: "TechnicalExaminations");

            migrationBuilder.DropTable(
                name: "OldCarsCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalExaminations",
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
                newName: "TechnicalExaminations");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalExamination_CarId",
                table: "TechnicalExaminations",
                newName: "IX_TechnicalExaminations_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalExaminations",
                table: "TechnicalExaminations",
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
    }
}
