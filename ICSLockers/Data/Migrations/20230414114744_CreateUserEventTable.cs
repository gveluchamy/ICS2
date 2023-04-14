using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f26dce1-e61d-4158-a479-c22a0259d67e", new DateTime(2023, 4, 14, 17, 17, 44, 269, DateTimeKind.Local).AddTicks(9051), "AQAAAAIAAYagAAAAEI5aOlYCgSpA/NqJrM1lNlNGpQHPW/BkDALQB218xQz7KUXUwGMPZlkNocarMCqmEg==", "59f0f12d-8790-481d-b96a-f77c093d0030" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffaa3ec-2240-4cce-8308-17c30fc969fd", new DateTime(2023, 4, 13, 19, 20, 24, 990, DateTimeKind.Local).AddTicks(6214), "AQAAAAIAAYagAAAAEErmYxwCRz6DcMykEc9eDrw8zc31bexN5k7KztxvWZynZsHvHlr6rMQioZBsDlKdvw==", "74bdc661-2f4f-4193-970b-ed575b5ac981" });
        }
    }
}
