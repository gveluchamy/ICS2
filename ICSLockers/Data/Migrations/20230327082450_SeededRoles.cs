using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56f268c4-a571-44fd-ab0d-e9423b5db174", "2", "Staff", "Staff" },
                    { "81eb9446-1392-4f6c-be83-03b1d4175c04", "3", "User", "User" },
                    { "aa317cb1-95fb-45aa-8a82-699779abed25", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f268c4-a571-44fd-ab0d-e9423b5db174");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81eb9446-1392-4f6c-be83-03b1d4175c04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa317cb1-95fb-45aa-8a82-699779abed25");
        }
    }
}
