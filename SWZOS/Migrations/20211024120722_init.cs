using Microsoft.EntityFrameworkCore.Migrations;

namespace SWZOS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PITCHES",
                columns: table => new
                {
                    PITCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PITCH_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE_FLAG = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PITCHES", x => x.PITCH_ID);
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
                    PASSWORD_SALT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD_HASH = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_USERS_USER_TYPE_ID",
                table: "USERS",
                column: "USER_TYPE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PITCHES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "USER_TYPES");
        }
    }
}
