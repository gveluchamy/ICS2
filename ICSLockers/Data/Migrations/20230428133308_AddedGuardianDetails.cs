using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGuardianDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    RelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LockerId = table.Column<int>(type: "int", nullable: false),
                    RelationShip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_Guardians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0288be88-5e3f-4a93-8049-49bb81767ab1", new DateTime(2023, 4, 28, 19, 3, 8, 747, DateTimeKind.Local).AddTicks(3405), "AQAAAAIAAYagAAAAEALUJX+0UrjiXOshTVncYhPsIiAajcBcn8BKRjh+SL544+pBJ5YlV7WjpCpbcQYhYA==", "025f6f48-e69a-419c-aa7e-bef8abffcab3" });

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_UserId",
                table: "Guardians",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8b3bf4-1f32-4f13-8332-7f5d4a15767a", new DateTime(2023, 4, 25, 12, 48, 45, 395, DateTimeKind.Local).AddTicks(4859), "AQAAAAIAAYagAAAAEOEBihv2OYaqQXpOVPvYo2kcNDlISZjHuQFx4EO2t0ASpiP72xqQiXkrTsX4TVBBjg==", "c65efe7d-5ef1-4ad9-a24a-6b4ca3ec6f28" });
        }
    }
}
