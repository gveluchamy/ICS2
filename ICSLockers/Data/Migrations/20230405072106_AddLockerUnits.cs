using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLockerUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LockerUnits",
                columns: table => new
                {
                    LockerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockerUnitNo = table.Column<int>(type: "int", nullable: false),
                    TotalLocker = table.Column<int>(type: "int", nullable: false),
                    UsedLocker = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerUnits", x => x.LockerId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaf8000d-f143-4d66-842f-9776b8c495a2", new DateTime(2023, 4, 5, 12, 51, 5, 992, DateTimeKind.Local).AddTicks(1001), "AQAAAAIAAYagAAAAENDQZEuVT7n3gtF2TiJOMqdLZoepwSmFO9LCr67RYbEmA6nCT5pQ6IxLpKRGwxWqFg==", "0c4af11f-b7c1-4434-8dcc-1284507ddcbc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LockerUnits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c30212a6-123e-42ae-bcbd-1784c1f76268", new DateTime(2023, 4, 4, 12, 46, 58, 328, DateTimeKind.Local).AddTicks(2828), "AQAAAAIAAYagAAAAENIKqIf7dthRDTe4BwfU5L36alijzpU+8qp/IZiHfzmXoEkbSjT8eXxm0T7G7LppOw==", "745653af-5280-4f07-aa21-3e523e08f65a" });
        }
    }
}
