using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class PitchTypeEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaximumQuantityPerReservation",
                table: "EQUIPMENT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PITCH_TYPE_EQUIPMENT",
                columns: table => new
                {
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PITCH_TYPE_EQUIPMENT", x => new { x.PITCH_TYPE_ID, x.EQUIPMENT_ID });
                    table.ForeignKey(
                        name: "FK_PITCH_TYPE_EQUIPMENT_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "ITEM_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PITCH_TYPE_EQUIPMENT_PITCH_TYPES_PITCH_TYPE_ID",
                        column: x => x.PITCH_TYPE_ID,
                        principalTable: "PITCH_TYPES",
                        principalColumn: "PITCH_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EQUIPMENT",
                columns: new[] { "ITEM_ID", "DESCRIPTION", "MaximumQuantityPerReservation", "NAME", "PRICE", "QUANTITY" },
                values: new object[,]
                {
                    { 1, "Piłka do piłki nożnej o rozmiarze 5", 9, "Piłka do piłki nożnej", 3m, 20 },
                    { 2, "Piłka do koszykówki", 10, "Piłka do koszykówki", 3m, 35 },
                    { 3, "Piłka do siatkówki", 10, "Piłka do siatkówki", 1.5m, 35 },
                    { 4, "Piłka do tenisa", 30, "Piłka do tenisa", 0m, 200 },
                    { 5, "Koszulka sportowa", 18, "Czerwone koszulki do gry", 1.5m, 40 },
                    { 6, "Koszulka sportowa", 18, "Niebieskie koszulki do gry", 1.5m, 40 },
                    { 7, "Koszulka sportowa", 18, "Białe koszulki do gry", 1.5m, 40 },
                    { 8, "Koszulka sportowa", 18, "Czarne koszulki do gry", 1.5m, 40 },
                    { 9, "Rakieta do gry w tenisa", 4, "Rakieta tenisowa", 10m, 24 }
                });

            migrationBuilder.InsertData(
                table: "PITCHES",
                columns: new[] { "PITCH_ID", "ACTIVE_FLAG", "DESCRIPTION", "PITCH_TYPE_ID" },
                values: new object[,]
                {
                    { 1, true, "Boisko do piłki nożnej", 1 },
                    { 2, true, "Boisko do piłki nożnej", 1 },
                    { 3, true, "Boisko do koszykówki", 3 },
                    { 4, true, "Boisko do koszykówki", 3 },
                    { 5, true, "Boisko do koszykówki", 3 },
                    { 6, true, "Boisko do siatkówki", 4 },
                    { 7, true, "Boisko do siatkówki", 4 },
                    { 8, true, "Boisko do siatkówki", 4 },
                    { 9, true, "Kort tenisowy", 2 },
                    { 10, true, "Kort tenisowy", 2 },
                    { 11, true, "Kort tenisowy", 2 },
                    { 12, true, "Kort tenisowy", 2 },
                    { 13, true, "Kort tenisowy", 2 },
                    { 14, true, "Kort tenisowy", 2 }
                });

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 1,
                column: "PITCH_TYPE_PRICE",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 2,
                column: "PITCH_TYPE_PRICE",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 3,
                column: "PITCH_TYPE_PRICE",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 4,
                column: "PITCH_TYPE_PRICE",
                value: 50m);

            migrationBuilder.CreateIndex(
                name: "IX_PITCH_TYPE_EQUIPMENT_EQUIPMENT_ID",
                table: "PITCH_TYPE_EQUIPMENT",
                column: "EQUIPMENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PITCH_TYPE_EQUIPMENT");

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EQUIPMENT",
                keyColumn: "ITEM_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PITCHES",
                keyColumn: "PITCH_ID",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "MaximumQuantityPerReservation",
                table: "EQUIPMENT");

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 1,
                column: "PITCH_TYPE_PRICE",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 2,
                column: "PITCH_TYPE_PRICE",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 3,
                column: "PITCH_TYPE_PRICE",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "PITCH_TYPES",
                keyColumn: "PITCH_TYPE_ID",
                keyValue: 4,
                column: "PITCH_TYPE_PRICE",
                value: 0m);
        }
    }
}
