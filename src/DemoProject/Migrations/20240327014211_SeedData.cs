using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "program",
                columns: new[] { "id", "name" },
                values: new object[] { -1, "Fullstack Web Application Development" });

            migrationBuilder.InsertData(
                table: "semester",
                columns: new[] { "id", "end_date", "name", "start_date" },
                values: new object[] { -1, new DateOnly(2024, 4, 26), "Winter 2024", new DateOnly(2024, 1, 8) });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "birthdate", "firstname", "lastname", "student_id" },
                values: new object[] { -1, new DateOnly(1990, 1, 1), "John", "Doe", null });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "id", "code", "name", "program_id" },
                values: new object[] { -1, "EXSM3931", "Introduction to Web Development", -1 });

            migrationBuilder.InsertData(
                table: "section",
                columns: new[] { "id", "course_id", "days_offered", "semester_id", "time_offered" },
                values: new object[] { -1, -1, "MR", -1, new TimeOnly(19, 0, 0) });

            migrationBuilder.InsertData(
                table: "enrollment",
                columns: new[] { "id", "grade", "section_id", "student_id" },
                values: new object[] { -1, null, -1, -1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "enrollment",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "section",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "course",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "semester",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "program",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
