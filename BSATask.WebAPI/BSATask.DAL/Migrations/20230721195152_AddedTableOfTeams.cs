using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BSATask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableOfTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "HeadWorks" },
                    { 2, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BinaryStudio" },
                    { 3, new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Epam" },
                    { 4, new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "AltexSoft" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
