using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLACK_LIST_STATUS",
                columns: table => new
                {
                    BLACK_LIST_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLACK_LIST_STATUS", x => x.BLACK_LIST_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT",
                columns: table => new
                {
                    ITEM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MAX_QUANTITY_PER_RESERVATION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.ITEM_ID);
                });

            migrationBuilder.CreateTable(
                name: "GLOBAL",
                columns: table => new
                {
                    KEY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLOBAL", x => x.KEY);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS_STATUS",
                columns: table => new
                {
                    PAYMENT_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS_STATUS", x => x.PAYMENT_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "PITCH_TYPES",
                columns: table => new
                {
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PITCH_TYPE_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PITCH_TYPE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PITCH_TYPES", x => x.PITCH_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_TYPES",
                columns: table => new
                {
                    USER_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TYPES", x => x.USER_TYPE_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "PITCHES",
                columns: table => new
                {
                    PITCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE_FLAG = table.Column<bool>(type: "bit", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    OUT_OF_SERVICE_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OUT_OF_SERVICE_END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OUT_OF_SERVICE_REASON = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PITCHES", x => x.PITCH_ID);
                    table.ForeignKey(
                        name: "FK_PITCHES_PITCH_TYPES_PITCH_TYPE_ID",
                        column: x => x.PITCH_TYPE_ID,
                        principalTable: "PITCH_TYPES",
                        principalColumn: "PITCH_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PASSWORD_SALT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD_EXPIRATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTIVE_FLAG = table.Column<bool>(type: "bit", nullable: false),
                    DELETED_FLAG = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USERS_USER_TYPES_USER_TYPE_ID",
                        column: x => x.USER_TYPE_ID,
                        principalTable: "USER_TYPES",
                        principalColumn: "USER_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BLACK_LIST",
                columns: table => new
                {
                    BLACK_LIST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    REASON = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLACK_LIST", x => x.BLACK_LIST_ID);
                    table.ForeignKey(
                        name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "BLACK_LIST_STATUS",
                        principalColumn: "BLACK_LIST_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BLACK_LIST_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESERVATIONS",
                columns: table => new
                {
                    RESERVATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PITCH_ID = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DURATION = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVATIONS", x => x.RESERVATION_ID);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_PITCHES_PITCH_ID",
                        column: x => x.PITCH_ID,
                        principalTable: "PITCHES",
                        principalColumn: "PITCH_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    PAYMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RESERVATION_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    FULL_FEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ADVANCE_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PAID_IN_AMMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PAYMENT_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_PAYMENTS_STATUS_PAYMENT_STATUS_ID",
                        column: x => x.PAYMENT_STATUS_ID,
                        principalTable: "PAYMENTS_STATUS",
                        principalColumn: "PAYMENT_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_RESERVATIONS_RESERVATION_ID",
                        column: x => x.RESERVATION_ID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "RESERVATION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESERVATIONS_EQUIPMENT",
                columns: table => new
                {
                    RESERVATION_EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RESERVATION_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVATIONS_EQUIPMENT", x => x.RESERVATION_EQUIPMENT_ID);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_EQUIPMENT_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "ITEM_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_EQUIPMENT_RESERVATIONS_RESERVATION_ID",
                        column: x => x.RESERVATION_ID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "RESERVATION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BLACK_LIST_STATUS",
                columns: new[] { "BLACK_LIST_STATUS_ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Waiting for approval" },
                    { 2, "Approved" },
                    { 3, "Rejected" },
                    { 4, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "EQUIPMENT",
                columns: new[] { "ITEM_ID", "DESCRIPTION", "MAX_QUANTITY_PER_RESERVATION", "NAME", "PRICE", "QUANTITY" },
                values: new object[,]
                {
                    { 1, "Piłka do piłki nożnej o rozmiarze 5", 9, "Piłka do piłki nożnej", 3m, 20 },
                    { 2, "Piłka do koszykówki", 10, "Piłka do koszykówki", 3m, 35 },
                    { 3, "Piłka do siatkówki", 10, "Piłka do siatkówki", 1.5m, 35 },
                    { 4, "Piłka do tenisa", 30, "Piłka do tenisa", 0m, 200 },
                    { 5, "Lejbik sportowy", 18, "Czerwone lejbiki do gry", 1.5m, 40 },
                    { 6, "Lejbik sportowy", 18, "Niebieskie lejbiki do gry", 1.5m, 40 },
                    { 7, "Lejbik sportowy", 18, "Białe lejbiki do gry", 1.5m, 40 },
                    { 8, "Lejbik sportowy", 18, "Czarne lejbiki do gry", 1.5m, 40 },
                    { 9, "Rakieta do gry w tenisa", 4, "Rakieta tenisowa", 10m, 24 }
                });

            migrationBuilder.InsertData(
                table: "GLOBAL",
                columns: new[] { "KEY", "DESCRIPTION", "VALUE" },
                values: new object[,]
                {
                    { "CloseHour", "Godzina zamknięcia obiektu", "23:00:00" },
                    { "HomePageDescription", "Tekst wyświetlany na stronie głównej aplikacji", "" },
                    { "OpenHour", "Godzina otwarcia obiektu", "09:30:00" },
                    { "Regulations", "Regulamin korzystania z obiektu sportowego", "" }
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

            migrationBuilder.InsertData(
                table: "PITCH_TYPES",
                columns: new[] { "PITCH_TYPE_ID", "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[,]
                {
                    { 1, "Boisko piłkarskie", 120m },
                    { 2, "Kort tenisowy", 50m },
                    { 3, "Boisko do koszykówki", 80m },
                    { 4, "Boisko do siatkówki", 80m }
                });

            migrationBuilder.InsertData(
                table: "USER_TYPES",
                columns: new[] { "USER_TYPE_ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" },
                    { 3, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "PITCHES",
                columns: new[] { "PITCH_ID", "ACTIVE_FLAG", "DESCRIPTION", "OUT_OF_SERVICE_END_DATE", "OUT_OF_SERVICE_REASON", "OUT_OF_SERVICE_START_DATE", "PITCH_TYPE_ID" },
                values: new object[,]
                {
                    { 1, true, "Boisko do piłki nożnej", null, null, null, 1 },
                    { 2, true, "Boisko do piłki nożnej", null, null, null, 1 },
                    { 3, true, "Boisko do koszykówki", null, null, null, 3 },
                    { 4, true, "Boisko do koszykówki", null, null, null, 3 },
                    { 5, true, "Boisko do koszykówki", null, null, null, 3 },
                    { 6, true, "Boisko do siatkówki", null, null, null, 4 },
                    { 7, true, "Boisko do siatkówki", null, null, null, 4 },
                    { 8, true, "Boisko do siatkówki", null, null, null, 4 },
                    { 9, true, "Kort tenisowy", null, null, null, 2 },
                    { 10, true, "Kort tenisowy", null, null, null, 2 },
                    { 11, true, "Kort tenisowy", null, null, null, 2 },
                    { 12, true, "Kort tenisowy", null, null, null, 2 },
                    { 13, true, "Kort tenisowy", null, null, null, 2 },
                    { 14, true, "Kort tenisowy", null, null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "PITCH_TYPE_EQUIPMENT",
                columns: new[] { "EQUIPMENT_ID", "PITCH_TYPE_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 4, 2 },
                    { 9, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 3, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "USER_ID", "ACTIVE_FLAG", "DELETED_FLAG", "LOGIN", "EMAIL_ADDRESS", "NAME", "PASSWORD_EXPIRATION_DATE", "PASSWORD_HASH", "PASSWORD_SALT", "PHONE_NUMBER", "SURNAME", "USER_TYPE_ID" },
                values: new object[,]
                {
                    { 2, true, false, "employee_a", "employee_a@swzos.pl", "Jan", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2206), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Śliwa", 2 },
                    { 3, true, false, "employee_b", "employee_b@swzos.pl", "Grzegorz", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2234), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Nowak", 2 },
                    { 4, true, false, "dzony_a", "dzony_a@swzos.pl", "Łukasz", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2236), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Piotrowski", 3 },
                    { 5, true, false, "dzony_b", "dzony_b@swzos.pl", "Michał", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2237), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Skórka", 3 },
                    { 6, true, false, "dzony_c", "dzony_c@swzos.pl", "Piotr", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2239), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Koza", 3 },
                    { 7, true, false, "dzony_d", "dzony_d@swzos.pl", "Krzysztof", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2240), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Pałka", 3 },
                    { 8, true, false, "dzony_e", "dzony_e@swzos.pl", "Filip", new DateTime(2024, 7, 15, 12, 59, 19, 562, DateTimeKind.Local).AddTicks(2260), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Wilczek", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_STATUS_ID",
                table: "BLACK_LIST",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_PAYMENT_STATUS_ID",
                table: "PAYMENTS",
                column: "PAYMENT_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_RESERVATION_ID",
                table: "PAYMENTS",
                column: "RESERVATION_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PITCH_TYPE_EQUIPMENT_EQUIPMENT_ID",
                table: "PITCH_TYPE_EQUIPMENT",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PITCHES_PITCH_TYPE_ID",
                table: "PITCHES",
                column: "PITCH_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_PITCH_ID",
                table: "RESERVATIONS",
                column: "PITCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_USER_ID",
                table: "RESERVATIONS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_EQUIPMENT_EQUIPMENT_ID",
                table: "RESERVATIONS_EQUIPMENT",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_EQUIPMENT_RESERVATION_ID",
                table: "RESERVATIONS_EQUIPMENT",
                column: "RESERVATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_USER_TYPE_ID",
                table: "USERS",
                column: "USER_TYPE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLACK_LIST");

            migrationBuilder.DropTable(
                name: "GLOBAL");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "PITCH_TYPE_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "RESERVATIONS_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "BLACK_LIST_STATUS");

            migrationBuilder.DropTable(
                name: "PAYMENTS_STATUS");

            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "RESERVATIONS");

            migrationBuilder.DropTable(
                name: "PITCHES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "PITCH_TYPES");

            migrationBuilder.DropTable(
                name: "USER_TYPES");
        }
    }
}
