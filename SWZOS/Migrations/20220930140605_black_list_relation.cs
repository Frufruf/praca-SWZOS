using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class black_list_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST");

            migrationBuilder.UpdateData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "OpenHour",
                column: "VALUE",
                value: "09:30:00");

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 3,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 4,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 5,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 6,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 7,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 8,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 30, 16, 6, 5, 166, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST");

            migrationBuilder.UpdateData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "OpenHour",
                column: "VALUE",
                value: "10:00:00");

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 3,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 4,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 5,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 6,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 7,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 8,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 9, 17, 18, 9, 38, 972, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST",
                column: "USER_ID",
                unique: true);
        }
    }
}
