using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CheckOutStatus", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "LastName", "LockerUnit", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordEnc", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, false, "c30212a6-123e-42ae-bcbd-1784c1f76268", "Admin", new DateTime(2023, 4, 4, 12, 46, 58, 328, DateTimeKind.Local).AddTicks(2828), "elanchezhiyan.p@aitechindia.com", true, "Elanchezhiyan", "P", 0, true, null, "elanchezhiyan.p@aitechindia.com", "elanchezhiyan.p@aitechindia.com", "EP11", "AQAAAAIAAYagAAAAENIKqIf7dthRDTe4BwfU5L36alijzpU+8qp/IZiHfzmXoEkbSjT8eXxm0T7G7LppOw==", "9942644999", false, 987654311, "745653af-5280-4f07-aa21-3e523e08f65a", false, "elanchezhiyan.p@aitechindia.com" });

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
