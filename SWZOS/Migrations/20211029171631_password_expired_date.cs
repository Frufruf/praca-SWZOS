using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SWZOS.Migrations
{
    public partial class password_expired_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordExpirationDate",
                table: "USERS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordExpirationDate",
                table: "USERS");
        }
    }
}
