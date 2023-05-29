using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3dce240b-4ce6-4202-b816-b5cc763352a7");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cc1815e-65bb-4044-abf9-e113b4829ff2", "AQAAAAIAAYagAAAAEFp5P8I9xZVK75icUVU5//YlWXVPHkYJgx8tFdfm+kEbJ8rAMEh7EUFouptM+zor/g==", "a6e9e6e3-7953-4224-88d4-bbb1e963df3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9a64cad-2fb5-4014-a949-060f6cdd5de6", "AQAAAAIAAYagAAAAEEkQQG1D/Omj1bgJ/umQPjLjakdQimFQH3LBQj9LJ0xIYH4Fkn7u8r9iju/Fo4wGwQ==", "95bbde63-d50c-4451-acf4-6ca1161e1b86" });

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "3dce240b-4ce6-4202-b816-b5cc763352a7", 0, "38a6eaed-3491-4918-ab72-40822cba7ff4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMCLbskT6jUNWIGnPGE9qD7njY4FOXfhbSwkU0Rjvpf4UX4Dq8IMlq7+ymOGvOZHAA==", null, false, null, "346f6b28-49d4-40d0-b95a-57c2cfacf54a", false, "supervisor@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "842a3371-83c0-408c-a8f2-a84447dc1e1f", "AQAAAAIAAYagAAAAEBoiHzwRurjnh3JzuKBDmOqQeXP8wmjjAWW2PUDUcwPxtEXt4Q/wTU0CXOMkPpUPXg==", "7ee26c9b-cc2e-403f-b8ee-17fbc908a27f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e742bc94-ff7b-4e10-abdf-40320ddb5e6f", "AQAAAAIAAYagAAAAEJPbVN0A+Tp+1MYV6DswtbTEe5uj3qf3/zluxUDGmVegJMgIzTESkWzUUjpQhLaGIg==", "853a4b4d-3404-4077-a075-95882bfc90b1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3dce240b-4ce6-4202-b816-b5cc763352a7", 0, "f01fc6e2-ab6b-4c43-afc0-440497e57571", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAENByfBrJL6/sGy1PIH2YXecuNJn3Rh2wvpeGDXqp1mPO1tpTlKrUgpD21NSka//sJg==", null, false, null, "e31382d2-d27e-495d-96e3-3ac5cdb37196", false, "supervisor@localhost.com" });
        }
    }
}
