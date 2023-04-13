using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDivisions : Migration
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
                    DivisionNo = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TotalLockers = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Division_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f2173f4-122a-4d64-baba-bae07096db04", new DateTime(2023, 4, 13, 19, 9, 43, 860, DateTimeKind.Local).AddTicks(139), "AQAAAAIAAYagAAAAEGV4EMc9b6TIBuGlUKHu155N0QpaSKvewi1yqC+mGfAB6QxmHWmQ+4BbiH5BQrASiA==", "9928d089-0edf-4afb-861a-630842a3ce9a" });

            migrationBuilder.CreateIndex(
                name: "IX_Division_LocationId",
                table: "Division",
                column: "LocationId");
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
