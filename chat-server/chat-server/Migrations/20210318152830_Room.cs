using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chat_server.Migrations
{
    public partial class Room : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "Date",
                value: new DateTime(2021, 3, 18, 15, 28, 30, 365, DateTimeKind.Utc).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "Date",
                value: new DateTime(2021, 3, 18, 15, 28, 30, 366, DateTimeKind.Utc).AddTicks(2472));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "Date",
                value: new DateTime(2021, 3, 18, 15, 28, 18, 941, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "Date",
                value: new DateTime(2021, 3, 18, 15, 28, 18, 942, DateTimeKind.Utc).AddTicks(1813));
        }
    }
}
