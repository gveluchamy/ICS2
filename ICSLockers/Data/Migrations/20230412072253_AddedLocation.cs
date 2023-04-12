using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDivision = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fe256e1-d817-45ca-9b24-fc4d493f33a9", new DateTime(2023, 4, 12, 12, 52, 53, 494, DateTimeKind.Local).AddTicks(7311), "AQAAAAIAAYagAAAAENY4c+KvOa8G3mSuQ+oed4gJS4mL5rnClHPMtrJI4lrKMmZumMgc1gPMGQcO8JoYkQ==", "5562afd6-147c-4a02-b360-6fa19def4722" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21eb08ab-7019-45cd-b57b-14a5d90037ad", new DateTime(2023, 4, 11, 18, 50, 25, 431, DateTimeKind.Local).AddTicks(8527), "AQAAAAIAAYagAAAAEAro1phm9lX4ax0oxsd8/EBg3XHjXDy5mygNuNmoXlZ5wA0ESXsNgperifDjSUOWLg==", "f65a8946-8646-4862-830f-0a2e6096396e" });
        }
    }
}
