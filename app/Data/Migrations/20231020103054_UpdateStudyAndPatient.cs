using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudyAndPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Patients_PatientId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Studies_Studies_StudyId",
                table: "Studies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studies",
                table: "Studies");

            migrationBuilder.DropIndex(
                name: "IX_Studies_StudyId",
                table: "Studies");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Studies");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "StudyId",
                table: "Studies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studies",
                table: "Studies",
                column: "StudyId");

            migrationBuilder.CreateTable(
                name: "PatientStudy",
                columns: table => new
                {
                    PatientsId = table.Column<int>(type: "integer", nullable: false),
                    StudiesStudyId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientStudy", x => new { x.PatientsId, x.StudiesStudyId });
                    table.ForeignKey(
                        name: "FK_PatientStudy_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientStudy_Studies_StudiesStudyId",
                        column: x => x.StudiesStudyId,
                        principalTable: "Studies",
                        principalColumn: "StudyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientStudy_StudiesStudyId",
                table: "PatientStudy",
                column: "StudiesStudyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studies",
                table: "Studies");

            migrationBuilder.AlterColumn<int>(
                name: "StudyId",
                table: "Studies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Studies",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Patients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studies",
                table: "Studies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Studies_StudyId",
                table: "Studies",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientId",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Patients_PatientId",
                table: "Patients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Studies_Studies_StudyId",
                table: "Studies",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id");
        }
    }
}
