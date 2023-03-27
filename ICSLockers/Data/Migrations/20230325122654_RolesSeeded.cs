using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ba218b8-a5da-4e76-b9e8-399861861db6", "1", "SuperAdmin", "SuperAdmin" },
                    { "9b8b9c4a-1469-4315-8214-2cc13fd11505", "4", "User", "User" },
                    { "a749d49c-7e70-4ef6-bfb8-efd01388dcfd", "2", "Admin", "Admin" },
                    { "b007299a-1ec0-4630-9f80-cbe4e6d279aa", "3", "Employee", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba218b8-a5da-4e76-b9e8-399861861db6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b8b9c4a-1469-4315-8214-2cc13fd11505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a749d49c-7e70-4ef6-bfb8-efd01388dcfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b007299a-1ec0-4630-9f80-cbe4e6d279aa");
        }
    }
}
