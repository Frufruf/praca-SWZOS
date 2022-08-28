using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWZOS.Migrations
{
    public partial class users_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "USER_ID", "ACTIVE_FLAG", "DELETED_FLAG", "LOGIN", "EMAIL_ADDRESS", "NAME", "PASSWORD_EXPIRATION_DATE", "PASSWORD_HASH", "PASSWORD_SALT", "PHONE_NUMBER", "SURNAME", "USER_TYPE_ID" },
                values: new object[,]
                {
                    { 1, true, false, "kbrydak", "krzysztof.brydak@gmail.com", "Krzysztof", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7136), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Brydak", 1 },
                    { 2, true, false, "employee_a", "employee_a@swzos.pl", "Jan", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7176), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Śliwa", 2 },
                    { 3, true, false, "employee_b", "employee_b@swzos.pl", "Grzegorz", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7180), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Nowak", 2 },
                    { 4, true, false, "dzony_a", "dzony_a@swzos.pl", "Łukasz", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7183), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Piotrowski", 3 },
                    { 5, true, false, "dzony_b", "dzony_b@swzos.pl", "Michał", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7186), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Skórka", 3 },
                    { 6, true, false, "dzony_c", "dzony_c@swzos.pl", "Piotr", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7189), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Koza", 3 },
                    { 7, true, false, "dzony_d", "dzony_d@swzos.pl", "Krzysztof", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7193), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Pałka", 3 },
                    { 8, true, false, "dzony_e", "dzony_e@swzos.pl", "Filip", new DateTime(2023, 8, 28, 16, 18, 21, 575, DateTimeKind.Local).AddTicks(7196), "2pXiCfz7Auwsjm27jcVR5+tI2siy3pu1M+MxmBzFbsc=", "GwsT98hcHRzddN0OB4/CPbnHSqwz+Y2W8C1sVh4da9s=", null, "Wilczek", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "USER_ID",
                keyValue: 8);
        }
    }
}
