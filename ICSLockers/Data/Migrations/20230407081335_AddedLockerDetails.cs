using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLockerDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LockerUnit",
                table: "AspNetUsers",
                newName: "LockerUnitId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordEnc",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LockerDetailId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LockerDetails",
                columns: table => new
                {
                    Sno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockerId = table.Column<int>(type: "int", nullable: false),
                    LockerUnitId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerDetails", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_LockerDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LockerDetails_LockerUnits_LockerUnitId",
                        column: x => x.LockerUnitId,
                        principalTable: "LockerUnits",
                        principalColumn: "LockerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LockerDetailId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83192c5b-76be-45de-871c-109b226bbeca", new DateTime(2023, 4, 7, 13, 43, 34, 990, DateTimeKind.Local).AddTicks(3742), 0, "AQAAAAIAAYagAAAAEP8dAZ7FX63l7y9wyrqLKaMx12lmfqdUU8GzRLPNBsAWycrsHypnEO4dwu+S2Pn8+g==", "e648489b-0e01-4629-8788-ae9e278ab52d" });

            migrationBuilder.CreateIndex(
                name: "IX_LockerDetails_LockerUnitId",
                table: "LockerDetails",
                column: "LockerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LockerDetails_UserId",
                table: "LockerDetails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LockerDetails");

            migrationBuilder.DropColumn(
                name: "LockerDetailId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LockerUnitId",
                table: "AspNetUsers",
                newName: "LockerUnit");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordEnc",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaf8000d-f143-4d66-842f-9776b8c495a2", new DateTime(2023, 4, 5, 12, 51, 5, 992, DateTimeKind.Local).AddTicks(1001), "AQAAAAIAAYagAAAAENDQZEuVT7n3gtF2TiJOMqdLZoepwSmFO9LCr67RYbEmA6nCT5pQ6IxLpKRGwxWqFg==", "0c4af11f-b7c1-4434-8dcc-1284507ddcbc" });
        }
    }
}
