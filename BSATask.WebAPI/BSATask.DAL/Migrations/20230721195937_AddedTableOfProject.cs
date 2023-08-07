using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BSATask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableOfProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "Name", "TeamId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create an ASP.NET Core Web API application using one of the following architectures: REST API (controllers/services) or CQRS", "ProjectStructure", 1, 1 },
                    { 2, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Appreciative deputy, director of Parking, bazhaє to automate the routine processes of his business, through which, turning to you for help. Also, you need to create a simple program for curation", "NET Ecosystem 2023", 2, 2 },
                    { 3, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The main idea of the project is to get to know our details of how we can look like a real project, learn about how the architecture of the project is mastered, marvel at the possible configuration, try to dig into someone else's code.", "Thread", 3, 4 },
                    { 4, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make it look like twitter", "Twitter", 4, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
