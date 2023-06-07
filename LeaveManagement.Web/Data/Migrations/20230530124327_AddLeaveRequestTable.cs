using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69c1ab77-708a-4c9d-a96e-304966daf74e", "AQAAAAIAAYagAAAAEFfPFgot1qQe+stRVROvGZV9q3cw5T7I+HCf85rHGBXxtAJiQ9/Hq41bIDPyytuG2w==", "d4c5e096-455d-4a4e-b8f0-a91e4c5bcaa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54d45118-90da-418d-a726-de9ebbddba3d", "AQAAAAIAAYagAAAAEPI5SiphEuaYowT9lEr23dkOhaIr9t7XkQQ2TQttSjf4pkxxDzBvHobc/XYpwbMlfg==", "60bef3d9-568d-4197-a10a-3c768a5e5a8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46326c7b-8cf2-45e4-aeb4-f2fbac89c6b1", "AQAAAAIAAYagAAAAEJISaS5WWfb79p//8K40VWSjWastBoOYu8LaZjrrHM9TVPs22nNHSE/8+O5Q5l/T8Q==", "e0ddd794-07df-401f-869d-a23b42d57c8e" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38a6eaed-3491-4918-ab72-40822cba7ff4", "AQAAAAIAAYagAAAAEMCLbskT6jUNWIGnPGE9qD7njY4FOXfhbSwkU0Rjvpf4UX4Dq8IMlq7+ymOGvOZHAA==", "346f6b28-49d4-40d0-b95a-57c2cfacf54a" });

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
        }
    }
}
