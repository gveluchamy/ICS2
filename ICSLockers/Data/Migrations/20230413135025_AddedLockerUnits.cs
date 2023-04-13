using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLockerUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedLockers",
                table: "Division",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locker",
                columns: table => new
                {
                    LockerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locker", x => x.LockerId);
                    table.ForeignKey(
                        name: "FK_Locker_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffaa3ec-2240-4cce-8308-17c30fc969fd", new DateTime(2023, 4, 13, 19, 20, 24, 990, DateTimeKind.Local).AddTicks(6214), "AQAAAAIAAYagAAAAEErmYxwCRz6DcMykEc9eDrw8zc31bexN5k7KztxvWZynZsHvHlr6rMQioZBsDlKdvw==", "74bdc661-2f4f-4193-970b-ed575b5ac981" });

            migrationBuilder.CreateIndex(
                name: "IX_Locker_DivisionId",
                table: "Locker",
                column: "DivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locker");

            migrationBuilder.DropColumn(
                name: "UsedLockers",
                table: "Division");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f2173f4-122a-4d64-baba-bae07096db04", new DateTime(2023, 4, 13, 19, 9, 43, 860, DateTimeKind.Local).AddTicks(139), "AQAAAAIAAYagAAAAEGV4EMc9b6TIBuGlUKHu155N0QpaSKvewi1yqC+mGfAB6QxmHWmQ+4BbiH5BQrASiA==", "9928d089-0edf-4afb-861a-630842a3ce9a" });
        }
    }
}
