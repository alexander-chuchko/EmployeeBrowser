using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BSATask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableOfTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "Name", "ProjectId", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blame it on 3 to 5 elements in skin daytime at the start of the zastosunku", null, "Create three to five models", 1, 1, 1 },
                    { 2, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Models that rotate with CRUD endpoints have the same structure as Swagger's front home (you can't change field names or you can see them instead);", null, "Implement models from past homework", 1, 2, 2 },
                    { 3, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "For work with danim, it’s better to win one of the patterns, as they were looked at during the lecture (Repository, UnitOfWork)", null, "Implementation of Repository or UnitOfWork", 2, 1, 3 },
                    { 4, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Be kind, create a new repository on Bitbucket, and do not continue to work with the existing one", null, "Created repository", 2, 1, 4 },
                    { 5, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The creations of the project are responsible for the name BSATask.WebAPI", null, "Created project", 3, 1, 5 },
                    { 6, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guess about such words, like DTO and DI", null, "Implementation of DTO and DI", 3, 1, 6 },
                    { 7, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The console client is responsible for the upgrades to work with the server via HTTP", null, "Modernization UI", 4, 1, 7 },
                    { 8, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "In the right solution (it is possible in a real repository) create a WebAPI project based on .NET 6", null, "Created WEBAPI project", 4, 0, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
