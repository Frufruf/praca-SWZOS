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
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.ITEM_ID);
                });

            migrationBuilder.CreateTable(
                name: "PITCH_TYPES",
                columns: table => new
                {
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PitchTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    PRICE = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
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
                    EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PASSWORD_SALT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD_EXPIRATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    DeletedFlag = table.Column<bool>(type: "bit", nullable: false)
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
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    REASON = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLACK_LIST", x => x.BLACK_LIST_ID);
                    table.ForeignKey(
                        name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS",
                        column: x => x.STATUS,
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
                    PRICE = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
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
                    FEE = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
                    IS_SETTLED = table.Column<bool>(type: "bit", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_RESERVATIONS_RESERVATION_ID",
                        column: x => x.RESERVATION_ID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "RESERVATION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_STATUS",
                table: "BLACK_LIST",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_BLACK_LIST_USER_ID",
                table: "BLACK_LIST",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_RESERVATION_ID",
                table: "PAYMENTS",
                column: "RESERVATION_ID");

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
                name: "IX_USERS_USER_TYPE_ID",
                table: "USERS",
                column: "USER_TYPE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLACK_LIST");

            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "BLACK_LIST_STATUS");

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
