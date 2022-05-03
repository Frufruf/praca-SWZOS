using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class temp_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PASSWORD_TEMP",
                table: "USERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PASSWORD_TEMP",
                table: "USERS");
        }
    }
}
