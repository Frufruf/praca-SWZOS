using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class payment_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GLOBAL",
                table: "GLOBAL");

            migrationBuilder.DropColumn(
                name: "GLOBAL_ID",
                table: "GLOBAL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GLOBAL",
                table: "GLOBAL",
                column: "KEY");

            migrationBuilder.InsertData(
                table: "GLOBAL",
                columns: new[] { "KEY", "DESCRIPTION", "VALUE" },
                values: new object[,]
                {
                    { "CloseHour", "Godzina zamknięcia obiektu", "23:00:00" },
                    { "HomePageDescription", "Tekst wyświetlany na stronie głównej aplikacji", "" },
                    { "OpenHour", "Godzina otwarcia obiektu", "10:00:00" }
                });

            migrationBuilder.InsertData(
                table: "PAYMENTS_STATUS",
                columns: new[] { "PAYMENT_STATUS_ID", "NAME" },
                values: new object[,]
                {
                    { 1, "NotPaid" },
                    { 2, "Paid" },
                    { 3, "Delayed" },
                    { 4, "Overpaid" },
                    { 5, "Canceled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GLOBAL",
                table: "GLOBAL");

            migrationBuilder.DeleteData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "CloseHour");

            migrationBuilder.DeleteData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "HomePageDescription");

            migrationBuilder.DeleteData(
                table: "GLOBAL",
                keyColumn: "KEY",
                keyValue: "OpenHour");

            migrationBuilder.DeleteData(
                table: "PAYMENTS_STATUS",
                keyColumn: "PAYMENT_STATUS_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PAYMENTS_STATUS",
                keyColumn: "PAYMENT_STATUS_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PAYMENTS_STATUS",
                keyColumn: "PAYMENT_STATUS_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PAYMENTS_STATUS",
                keyColumn: "PAYMENT_STATUS_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PAYMENTS_STATUS",
                keyColumn: "PAYMENT_STATUS_ID",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "GLOBAL_ID",
                table: "GLOBAL",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GLOBAL",
                table: "GLOBAL",
                column: "GLOBAL_ID");
        }
    }
}
