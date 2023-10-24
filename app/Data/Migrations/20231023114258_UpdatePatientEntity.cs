using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientStudy_Patients_PatientsId",
                table: "PatientStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientStudy",
                table: "PatientStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientsId",
                table: "PatientStudy");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "PatientsPatientId",
                table: "PatientStudy",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DoB",
                table: "Patients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientStudy",
                table: "PatientStudy",
                columns: new[] { "PatientsPatientId", "StudiesStudyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientStudy_Patients_PatientsPatientId",
                table: "PatientStudy",
                column: "PatientsPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientStudy_Patients_PatientsPatientId",
                table: "PatientStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientStudy",
                table: "PatientStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientsPatientId",
                table: "PatientStudy");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PatientsId",
                table: "PatientStudy",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientStudy",
                table: "PatientStudy",
                columns: new[] { "PatientsId", "StudiesStudyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientStudy_Patients_PatientsId",
                table: "PatientStudy",
                column: "PatientsId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
