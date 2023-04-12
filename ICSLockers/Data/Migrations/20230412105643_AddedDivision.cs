using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDivision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3b265d2-a074-440f-aba0-6fe59af488ab", new DateTime(2023, 4, 12, 16, 26, 43, 217, DateTimeKind.Local).AddTicks(7657), "AQAAAAIAAYagAAAAEIfJp9HRQgC/eAl5gjKzM0zjUbdfOv/Xk0EmRcqqNMhNVnZRuUL41WznPlkXkGLrig==", "c8131236-16bc-44b0-a7da-86ef9aec8ba9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fe256e1-d817-45ca-9b24-fc4d493f33a9", new DateTime(2023, 4, 12, 12, 52, 53, 494, DateTimeKind.Local).AddTicks(7311), "AQAAAAIAAYagAAAAENY4c+KvOa8G3mSuQ+oed4gJS4mL5rnClHPMtrJI4lrKMmZumMgc1gPMGQcO8JoYkQ==", "5562afd6-147c-4a02-b360-6fa19def4722" });
        }
    }
}
