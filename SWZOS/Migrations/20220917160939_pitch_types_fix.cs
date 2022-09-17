using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class pitch_types_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 2,
                columns: new[] { "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[] { "Kort tenisowy", 50m });

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 3,
                column: "PITCH_TYPE_NAME",
                value: "Boisko do koszykówki");

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 4,
                columns: new[] { "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[] { "Boisko do siatkówki", 80m });

            migrationBuilder.InsertData(
                table: "PITCH_TYPE_EQUIPMENT",
                columns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                values: new object[,]
                {
                    { 4, 2 },
                    { 9, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "PITCH_TYPE_EQUIPMENT",
                keyColumns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 2,
                columns: new[] { "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[] { "Boisko do koszykówki", 80m });

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 3,
                column: "PITCH_TYPE_NAME",
                value: "Boisko do siatkówki");

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 4,
                columns: new[] { "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[] { "Kort tenisowy", 50m });

            migrationBuilder.InsertData(
                table: "PITCH_TYPE_EQUIPMENT",
                columns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 9, 4 }
                });

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 3,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 4,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 5,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 6,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 7,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 8,
                column: "PASSWORD_EXPIRATION_DATE",
                value: new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7196));
        }
    }
}
