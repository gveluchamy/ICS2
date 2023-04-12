using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CheckOutStatus", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockerDetailId", "LockerUnitId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordEnc", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, false, "21eb08ab-7019-45cd-b57b-14a5d90037ad", "Admin", new DateTime(2023, 4, 11, 18, 50, 25, 431, DateTimeKind.Local).AddTicks(8527), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "icslocker@hotmail.com", true, "ICS", "Lockers", 0, 0, true, null, "icslocker@hotmail.com", "icslocker@hotmail.com", "IL11", "AQAAAAIAAYagAAAAEAro1phm9lX4ax0oxsd8/EBg3XHjXDy5mygNuNmoXlZ5wA0ESXsNgperifDjSUOWLg==", "9876543210", false, 987654311, "f65a8946-8646-4862-830f-0a2e6096396e", false, "icslocker@hotmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6011125-2b8d-442a-9717-b8cf5345b015", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6011125-2b8d-442a-9717-b8cf5345b015", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
