using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class permissions_and_payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS",
                table: "BLACK_LIST");

            migrationBuilder.DropIndex(
                name: "IX_PAYMENTS_RESERVATION_ID",
                table: "PAYMENTS");

            migrationBuilder.DropColumn(
                name: "IS_SETTLED",
                table: "PAYMENTS");

            migrationBuilder.RenameColumn(
                name: "DeletedFlag",
                table: "USERS",
                newName: "DELETED_FLAG");

            migrationBuilder.RenameColumn(
                name: "ActiveFlag",
                table: "USERS",
                newName: "ACTIVE_FLAG");

            migrationBuilder.RenameColumn(
                name: "FEE",
                table: "PAYMENTS",
                newName: "PAID_IN_AMMOUNT");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "BLACK_LIST",
                newName: "STATUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_BLACK_LIST_STATUS",
                table: "BLACK_LIST",
                newName: "IX_BLACK_LIST_STATUS_ID");

            migrationBuilder.AddColumn<double>(
                name: "ADVANCE_PAYMENT",
                table: "PAYMENTS",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FULL_FEE",
                table: "PAYMENTS",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PAYMENT_STATUS_ID",
                table: "PAYMENTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USER_ID",
                table: "PAYMENTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS_ID",
                table: "BLACK_LIST",
                column: "STATUS_ID",
                principalTable: "BLACK_LIST_STATUS",
                principalColumn: "BLACK_LIST_STATUS_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAYMENTS_PAYMENTS_STATUS_PAYMENT_STATUS_ID",
                table: "PAYMENTS",
                column: "PAYMENT_STATUS_ID",
                principalTable: "PAYMENTS_STATUS",
                principalColumn: "PAYMENT_STATUS_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS_ID",
                table: "BLACK_LIST");

            migrationBuilder.DropForeignKey(
                name: "FK_PAYMENTS_PAYMENTS_STATUS_PAYMENT_STATUS_ID",
                table: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "PAYMENTS_STATUS");

            migrationBuilder.DropTable(
                name: "RESERVATIONS_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "USER_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "PERMISSIONS");

            migrationBuilder.DropIndex(
                name: "IX_PAYMENTS_PAYMENT_STATUS_ID",
                table: "PAYMENTS");

            migrationBuilder.DropIndex(
                name: "IX_PAYMENTS_RESERVATION_ID",
                table: "PAYMENTS");

            migrationBuilder.DropColumn(
                name: "ADVANCE_PAYMENT",
                table: "PAYMENTS");

            migrationBuilder.DropColumn(
                name: "FULL_FEE",
                table: "PAYMENTS");

            migrationBuilder.DropColumn(
                name: "PAYMENT_STATUS_ID",
                table: "PAYMENTS");

            migrationBuilder.DropColumn(
                name: "USER_ID",
                table: "PAYMENTS");

            migrationBuilder.RenameColumn(
                name: "DELETED_FLAG",
                table: "USERS",
                newName: "DeletedFlag");

            migrationBuilder.RenameColumn(
                name: "ACTIVE_FLAG",
                table: "USERS",
                newName: "ActiveFlag");

            migrationBuilder.RenameColumn(
                name: "PAID_IN_AMMOUNT",
                table: "PAYMENTS",
                newName: "FEE");

            migrationBuilder.RenameColumn(
                name: "STATUS_ID",
                table: "BLACK_LIST",
                newName: "STATUS");

            migrationBuilder.RenameIndex(
                name: "IX_BLACK_LIST_STATUS_ID",
                table: "BLACK_LIST",
                newName: "IX_BLACK_LIST_STATUS");

            migrationBuilder.AddColumn<bool>(
                name: "IS_SETTLED",
                table: "PAYMENTS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_RESERVATION_ID",
                table: "PAYMENTS",
                column: "RESERVATION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BLACK_LIST_BLACK_LIST_STATUS_STATUS",
                table: "BLACK_LIST",
                column: "STATUS",
                principalTable: "BLACK_LIST_STATUS",
                principalColumn: "BLACK_LIST_STATUS_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
