using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BSATask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableOfUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1994, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "che.al@ukr.net", "Kevin", "Taylor", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(1987, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "shevneva787@gmail.com", "Sophie", "Harris", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(1988, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "aslanov@gmail.com", "Lily", "Lewis", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(1992, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicols@gmail.com", "Grace", "King", new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(1995, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jack@gmail.com", "Scarlett", "Young", new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(1996, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "biden@ukr.net", "Ellie", "Moore", new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(1990, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "llll@ukr.net", "Paige", "Walker", new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(1998, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "lok@ukr.net", "Maddison", "Smith", new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
