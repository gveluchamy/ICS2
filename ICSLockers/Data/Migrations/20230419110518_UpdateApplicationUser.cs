using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockerDetailId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockerUnitId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "DivisionId", "LocationId", "LockerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69112e32-6bf0-4ce6-90f1-c5371f97f111", new DateTime(2023, 4, 19, 16, 35, 18, 243, DateTimeKind.Local).AddTicks(1401), 0, 0, 0, "AQAAAAIAAYagAAAAEPOvjUAmHiblVl7lS1biE2TRlXSl5PJRTzQTVQysIBYYuioAwQIcw+hn3yFEWeKBAA==", "b4a581c7-f182-4648-8d25-ada28b65f15d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LockerDetailId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LockerUnitId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockerDetailId", "LockerUnitId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffaa3ec-2240-4cce-8308-17c30fc969fd", new DateTime(2023, 4, 13, 19, 20, 24, 990, DateTimeKind.Local).AddTicks(6214), 0, 0, "AQAAAAIAAYagAAAAEErmYxwCRz6DcMykEc9eDrw8zc31bexN5k7KztxvWZynZsHvHlr6rMQioZBsDlKdvw==", "74bdc661-2f4f-4193-970b-ed575b5ac981" });
        }
    }
}
