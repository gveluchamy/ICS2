using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "865d7c89-436d-43a3-946b-f36896d64ccf", "3", "User", "User" },
                    { "b6011125-2b8d-442a-9717-b8cf5345b015", "1", "Admin", "Admin" },
                    { "c76d8f8d-9e53-433c-b8e3-96fddb7ac25b", "2", "Staff", "Staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "865d7c89-436d-43a3-946b-f36896d64ccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6011125-2b8d-442a-9717-b8cf5345b015");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76d8f8d-9e53-433c-b8e3-96fddb7ac25b");
        }
    }
}
