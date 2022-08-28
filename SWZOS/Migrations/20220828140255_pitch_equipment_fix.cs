using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class pitch_equipment_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "GLOBAL",
                columns: new[] { "KEY", "DESCRIPTION", "VALUE" },
                values: new object[] { "Regulations", "Regulamin korzystania z obiektu sportowego", "" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "Regulations");

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
        }
    }
}
