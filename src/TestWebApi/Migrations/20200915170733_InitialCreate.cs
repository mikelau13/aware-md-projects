using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1971, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient First 1", "Patient Last 1" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1972, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient First 2", "Patient Last 2" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1973, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient First 3", "Patient Last 3" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 4, new DateTime(1974, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient First 4", "Patient Last 4" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 5, new DateTime(1975, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient First 5", "Patient Last 5" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 1, new DateTime(2020, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 23, new DateTime(2020, 9, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "notes 18", 5 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 22, new DateTime(2020, 9, 6, 9, 45, 0, 0, DateTimeKind.Unspecified), "notes 17", 5 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 21, new DateTime(2020, 8, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), null, 5 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 20, new DateTime(2020, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "notes 20", 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 19, new DateTime(2020, 9, 21, 14, 15, 0, 0, DateTimeKind.Unspecified), "notes 19", 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 18, new DateTime(2020, 9, 11, 16, 15, 0, 0, DateTimeKind.Unspecified), "notes 18", 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 17, new DateTime(2020, 9, 6, 9, 45, 0, 0, DateTimeKind.Unspecified), "notes 17", 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 16, new DateTime(2020, 8, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), null, 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 15, new DateTime(2020, 10, 1, 15, 45, 0, 0, DateTimeKind.Unspecified), "notes 15", 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 14, new DateTime(2020, 9, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "notes 14", 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 24, new DateTime(2020, 9, 21, 14, 30, 0, 0, DateTimeKind.Unspecified), "notes 19", 5 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 13, new DateTime(2020, 9, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), "notes 13", 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 11, new DateTime(2020, 9, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), null, 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 10, new DateTime(2020, 9, 30, 15, 45, 0, 0, DateTimeKind.Unspecified), "notes 10", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 9, new DateTime(2020, 9, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "notes 09", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 8, new DateTime(2020, 9, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "notes 08", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 7, new DateTime(2020, 9, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "notes 07", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 6, new DateTime(2020, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), null, 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 5, new DateTime(2020, 9, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "notes 05", 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 4, new DateTime(2020, 9, 20, 9, 45, 0, 0, DateTimeKind.Unspecified), "notes 04", 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 3, new DateTime(2020, 9, 10, 10, 45, 0, 0, DateTimeKind.Unspecified), "notes 03", 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 2, new DateTime(2020, 9, 5, 9, 15, 0, 0, DateTimeKind.Unspecified), "notes 02", 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 12, new DateTime(2020, 9, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), "notes 12", 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "Notes", "PatientId" },
                values: new object[] { 25, new DateTime(2020, 10, 1, 16, 15, 0, 0, DateTimeKind.Unspecified), "notes 20", 5 });

            migrationBuilder.CreateIndex(
                name: "Index_AppointmentId",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "Index_PatientId",
                table: "Patients",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
