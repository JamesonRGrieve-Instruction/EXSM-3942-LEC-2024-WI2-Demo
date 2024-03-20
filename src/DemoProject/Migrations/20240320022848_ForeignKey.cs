using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "job_id",
                table: "person",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "FK_Person_Job",
                table: "person",
                column: "job_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Job",
                table: "person",
                column: "job_id",
                principalTable: "job",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Job",
                table: "person");

            migrationBuilder.DropIndex(
                name: "FK_Person_Job",
                table: "person");

            migrationBuilder.DropColumn(
                name: "job_id",
                table: "person");
        }
    }
}
