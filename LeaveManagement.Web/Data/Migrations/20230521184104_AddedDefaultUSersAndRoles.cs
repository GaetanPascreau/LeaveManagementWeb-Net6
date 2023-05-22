using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUSersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e3b6685-1ed7-4938-b935-042a4983d016", null, "User", "USER" },
                    { "98de57f4-0120-47ed-adf5-dfd68c5e93f7", null, "Supervisor", "SUPERVISOR" },
                    { "f5d383f4-6aa0-4735-be17-26a2a23ad96d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0660045f-c7e7-497e-be81-e98bc3a88b9b", 0, "8d80f8db-d639-4fe8-99f5-d36c65296b8b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAEAQ+YPZ9nm9i4b3F5bZIoJcsSsY9iWDs+RqK4M6XGy2WB1e1d3Mw/sMuUqHi4Y+W0g==", null, false, null, "3b2eb7dc-dabf-4766-9975-d71957da7c20", false, null },
                    { "6e8f2f84-ff83-435f-a213-6fd6c41605e5", 0, "c8249fa1-5655-4eb9-85d8-995bf87b108f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "USer", false, null, "USER@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAEBYEqct7T9nOuB+24dglph/RBL8DVZhVD8l+qKNxZwdas5fIZfBIhVOX+cUPGCwqNw==", null, false, null, "5e2d552a-3ed0-40ac-b7bf-97781062fd62", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f5d383f4-6aa0-4735-be17-26a2a23ad96d", "0660045f-c7e7-497e-be81-e98bc3a88b9b" },
                    { "2e3b6685-1ed7-4938-b935-042a4983d016", "6e8f2f84-ff83-435f-a213-6fd6c41605e5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98de57f4-0120-47ed-adf5-dfd68c5e93f7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5d383f4-6aa0-4735-be17-26a2a23ad96d", "0660045f-c7e7-497e-be81-e98bc3a88b9b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e3b6685-1ed7-4938-b935-042a4983d016", "6e8f2f84-ff83-435f-a213-6fd6c41605e5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3b6685-1ed7-4938-b935-042a4983d016");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d383f4-6aa0-4735-be17-26a2a23ad96d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5");
        }
    }
}
