using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupervisorRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a73841e-6b23-4995-a339-6a67e59e907e", "AQAAAAIAAYagAAAAEOAXByNfpLdj/RLO9p4cqg0Qva56i/ahtltHi1vyIR8gW3KH4Q86yLpcZDBKtwrKYA==", "61a4d751-bfe6-48f4-8f12-c3674948cb03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5",
                columns: new[] { "ConcurrencyStamp", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4dcf0d-9187-40ac-bb6a-81b1309a7c31", "User", "AQAAAAIAAYagAAAAEK5PwANVIVoK+qnv4L9Tnw4IOoS/YwTBefGp1IxgkwWkWBuxttUzHBgq6LZ6bApB1Q==", "05ce147a-fa69-40fb-afd7-f4aef6251499" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1", 0, "cc50f571-2080-40e2-90d3-02ca3ff7adfb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAECL8NDmuBLMiYxP8iulVlypW0/C3CkZ73XIQ4OPTiPm0sAZ8AtL3TwY6cWNOG8BRCA==", null, false, null, "7670f1ad-f12d-4d63-9914-876beffe589f", false, "supervisor@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98de57f4-0120-47ed-adf5-dfd68c5e93f7", "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98de57f4-0120-47ed-adf5-dfd68c5e93f7", "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76420ad-4c0c-412c-95e2-4d4b05550e82", "AQAAAAIAAYagAAAAELUse28UUpI1XGVw3nQgAvDHz8cRCGOi1Esa1MkhI2oaZkGeXJmU7rJUN1gABViVDA==", "d6fa7d06-3fc1-4758-a511-e38af45b3744" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5",
                columns: new[] { "ConcurrencyStamp", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea8d1814-b0de-49bf-9aba-46601afe479e", "USer", "AQAAAAIAAYagAAAAEGA9m0QHHBNNXuRnkE/KsMBAaGctG9iXG7+NuRDDtkRFGGdrdbnfz97z+6+zi44ZDw==", "bbd133c7-1281-4882-b6ce-ad8f12b01de0" });
        }
    }
}
