using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class out_of_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OUT_OF_SERVICE_END_DATE",
                table: "PITCHES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OUT_OF_SERVICE_REASON",
                table: "PITCHES",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OUT_OF_SERVICE_START_DATE",
                table: "PITCHES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 5,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Lejbik sportowy", "Czerwone lejbiki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 6,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Lejbik sportowy", "Niebieskie lejbiki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 7,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Lejbik sportowy", "Białe lejbiki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 8,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Lejbik sportowy", "Czarne lejbiki do gry" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OUT_OF_SERVICE_END_DATE",
                table: "PITCHES");

            migrationBuilder.DropColumn(
                name: "OUT_OF_SERVICE_REASON",
                table: "PITCHES");

            migrationBuilder.DropColumn(
                name: "OUT_OF_SERVICE_START_DATE",
                table: "PITCHES");

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 5,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Koszulka sportowa", "Czerwone koszulki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 6,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Koszulka sportowa", "Niebieskie koszulki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 7,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Koszulka sportowa", "Białe koszulki do gry" });

            migrationBuilder.UpdateData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 8,
                columns: new[] { "DESCRIPTION", "NAME" },
                values: new object[] { "Koszulka sportowa", "Czarne koszulki do gry" });
        }
    }
}
