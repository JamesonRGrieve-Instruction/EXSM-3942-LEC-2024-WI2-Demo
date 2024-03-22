using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "classroom",
                columns: new[] { "id", "room_number" },
                values: new object[] { -2, 102 });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "class_id", "first_name", "last_name" },
                values: new object[,]
                {
                    { -3, -1, "Tom", "Doe" },
                    { -6, -2, "Paul", "Doe" },
                    { -5, -2, "Joe", "Doe" },
                    { -4, -2, "Bob", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "classroom",
                keyColumn: "id",
                keyValue: -2);
        }
    }
}
