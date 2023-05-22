using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5d383f4-6aa0-4735-be17-26a2a23ad96d", "0660045f-c7e7-497e-be81-e98bc3a88b9b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e3b6685-1ed7-4938-b935-042a4983d016", "6e8f2f84-ff83-435f-a213-6fd6c41605e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98de57f4-0120-47ed-adf5-dfd68c5e93f7", "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3b6685-1ed7-4938-b935-042a4983d016");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98de57f4-0120-47ed-adf5-dfd68c5e93f7");

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09ee071c-ed16-42ca-be60-a6e0b7e1ae29", null, "Administrator", "ADMINISTRATOR" },
                    { "465b590d-d7cd-4b1f-b897-de900e81ac5c", null, "Supervisor", "SUPERVISOR" },
                    { "afccf3f3-12b4-4657-b24a-6642f8e34298", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SSN", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8d30dbae-134d-4137-8e2e-ec7c96ee1d82", 0, "842a3371-83c0-408c-a8f2-a84447dc1e1f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBoiHzwRurjnh3JzuKBDmOqQeXP8wmjjAWW2PUDUcwPxtEXt4Q/wTU0CXOMkPpUPXg==", null, false, null, "7ee26c9b-cc2e-403f-b8ee-17fbc908a27f", false, "admin@localhost.com" },
                    { "3dce240b-4ce6-4202-b816-b5cc763352a7", 0, "f01fc6e2-ab6b-4c43-afc0-440497e57571", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAENByfBrJL6/sGy1PIH2YXecuNJn3Rh2wvpeGDXqp1mPO1tpTlKrUgpD21NSka//sJg==", null, false, null, "e31382d2-d27e-495d-96e3-3ac5cdb37196", false, "supervisor@localhost.com" },
                    { "cf15a7b7-1533-4357-9dbd-20cddfff903c", 0, "e742bc94-ff7b-4e10-abdf-40320ddb5e6f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEJPbVN0A+Tp+1MYV6DswtbTEe5uj3qf3/zluxUDGmVegJMgIzTESkWzUUjpQhLaGIg==", null, false, null, "853a4b4d-3404-4077-a075-95882bfc90b1", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "465b590d-d7cd-4b1f-b897-de900e81ac5c", "3dce240b-4ce6-4202-b816-b5cc763352a7" },
                    { "09ee071c-ed16-42ca-be60-a6e0b7e1ae29", "8d30dbae-134d-4137-8e2e-ec7c96ee1d82" },
                    { "afccf3f3-12b4-4657-b24a-6642f8e34298", "cf15a7b7-1533-4357-9dbd-20cddfff903c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "465b590d-d7cd-4b1f-b897-de900e81ac5c", "3dce240b-4ce6-4202-b816-b5cc763352a7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09ee071c-ed16-42ca-be60-a6e0b7e1ae29", "8d30dbae-134d-4137-8e2e-ec7c96ee1d82" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "afccf3f3-12b4-4657-b24a-6642f8e34298", "cf15a7b7-1533-4357-9dbd-20cddfff903c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3dce240b-4ce6-4202-b816-b5cc763352a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09ee071c-ed16-42ca-be60-a6e0b7e1ae29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "465b590d-d7cd-4b1f-b897-de900e81ac5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afccf3f3-12b4-4657-b24a-6642f8e34298");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c");

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
                    { "0660045f-c7e7-497e-be81-e98bc3a88b9b", 0, "1f101be0-5fad-4fee-babf-c1ccc1e7a080", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAENPtkaOXWvWIgpgGrD2oHaZuvvOdMDTMDRIXd6Q8bL8z2JBdwlUp6zLbuGxYvDxQ3w==", null, false, null, "ad551ad9-c1c7-4eba-b8ad-f3fd45602477", false, "admin@localhost.com" },
                    { "6e8f2f84-ff83-435f-a213-6fd6c41605e5", 0, "d39827cc-3901-48b8-a3ee-d4173308902d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGg+vm8b8nMf5zGRu6pG5M3dek4C9jwYhC8GMMvZaosQ46XRyPfpc8Om7G6mHBcPpQ==", null, false, null, "238b9aee-994a-4261-8586-429a049388e3", false, "user@localhost.com" },
                    { "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1", 0, "367dc0a0-b5b0-4eb9-ba34-d7848b88222e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEI6r6HTz7HS1Q91eJ3AGzhZ2mOydldx3gklrHVMVjDuiy+C4KFj8szdLHV2xT0lNXQ==", null, false, null, "031baddc-163f-4ac7-a8a7-a6fda692b1f8", false, "supervisor@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f5d383f4-6aa0-4735-be17-26a2a23ad96d", "0660045f-c7e7-497e-be81-e98bc3a88b9b" },
                    { "2e3b6685-1ed7-4938-b935-042a4983d016", "6e8f2f84-ff83-435f-a213-6fd6c41605e5" },
                    { "98de57f4-0120-47ed-adf5-dfd68c5e93f7", "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1" }
                });
        }
    }
}
