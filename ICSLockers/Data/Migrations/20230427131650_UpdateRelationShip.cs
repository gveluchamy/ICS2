using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICSLockers.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RelationShip",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "RelationShip", "SecurityStamp" },
                values: new object[] { "36cdacd0-bdf9-4410-8dcc-6fba82e85526", new DateTime(2023, 4, 27, 18, 46, 50, 94, DateTimeKind.Local).AddTicks(6925), "AQAAAAIAAYagAAAAEEfnZEv5ibNNd+exVrNUp3uiPt2wA9n39Bptok9J49y0BRnMLqT0XWvxgtgSAsZH8A==", null, "6ef6a61f-1db6-43b5-a365-7e1680e72600" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationShip",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8b3bf4-1f32-4f13-8332-7f5d4a15767a", new DateTime(2023, 4, 25, 12, 48, 45, 395, DateTimeKind.Local).AddTicks(4859), "AQAAAAIAAYagAAAAEOEBihv2OYaqQXpOVPvYo2kcNDlISZjHuQFx4EO2t0ASpiP72xqQiXkrTsX4TVBBjg==", "c65efe7d-5ef1-4ad9-a24a-6b4ca3ec6f28" });
        }
    }
}
