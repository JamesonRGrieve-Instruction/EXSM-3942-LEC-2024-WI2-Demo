using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "name" },
                values: new object[] { -1, "Bus Driver" });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "first_name", "job_id", "last_name" },
                values: new object[,]
                {
                    { -2, "Jane", -1, "Doe" },
                    { -1, "John", -1, "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
