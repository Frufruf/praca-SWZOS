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
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.ITEM_ID);
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
                name: "PERMISSIONS",
                columns: table => new
                {
                    PERMISSION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DELETED_FLAG = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.PERMISSION_ID);
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
                name: "PITCHES",
                columns: table => new
                {
                    PITCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE_FLAG = table.Column<bool>(type: "bit", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
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
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
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
                name: "USER_PERMISSIONS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PERMISSION_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PERMISSIONS", x => new { x.USER_ID, x.PERMISSION_ID });
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_PERMISSIONS_PERMISSION_ID",
                        column: x => x.PERMISSION_ID,
                        principalTable: "PERMISSIONS",
                        principalColumn: "PERMISSION_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_USERS_USER_ID",
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
                table: "PITCH_TYPES",
                columns: new[] { "PITCH_TYPE_ID", "PITCH_TYPE_NAME", "PITCH_TYPE_PRICE" },
                values: new object[,]
                {
                    { 1, "Boisko piłkarskie", 0m },
                    { 2, "Boisko do koszykówki", 0m },
                    { 3, "Boisko do siatkówki", 0m },
                    { 4, "Kort tenisowy", 0m }
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

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_STATUS_ID",
                table: "BLACK_LIST",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST",
                column: "USER_ID",
                unique: true);

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
                name: "IX_USER_PERMISSIONS_PERMISSION_ID",
                table: "USER_PERMISSIONS",
                column: "PERMISSION_ID");

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
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "RESERVATIONS_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "USER_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "BLACK_LIST_STATUS");

            migrationBuilder.DropTable(
                name: "PAYMENTS_STATUS");

            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "RESERVATIONS");

            migrationBuilder.DropTable(
                name: "PERMISSIONS");

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
