using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingHalfDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8904a8e7-6162-4690-8cac-04c4e49fb46c", "AQAAAAIAAYagAAAAEL/GdXndrVB/jbzBWSwCUNHC1Q2KRYNwZjj3QQ1A7e9tfJe7xMyNHQWSmE6FnlTwGA==", "656dfac6-5e0c-4364-8a11-d5ee9f6fba1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5995f09-9c77-4700-a47a-e484a3e1cf51", "AQAAAAIAAYagAAAAEHkM2lY5L8eW6aa5blmS/AFNWGZg+2w4ZMZG5jP6iUoweocl9wPIu1IHuWux2BE8Dg==", "ec566d7a-78c7-4fb3-a902-9b94161a88cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c2e361e-c599-43e3-9dab-4813a7a0a4fb", "AQAAAAIAAYagAAAAEF+4vt1I7A4MyRWLY3B1hevX1cGnHX1VXBtlGhEBdl8Tk/vZclhvMlsKyesysiKP+w==", "e7a24f25-70c5-47fb-bced-cde87568f4c0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c500cafb-0763-4885-9595-301da6c3a6e1", "AQAAAAIAAYagAAAAEMlBg6b69i6YJfHjsYExeq4nrsVwZxdty+Oc0kGba0ogVKooXDqPhiyAhJKwp94fMA==", "4ef79138-8d5d-46a8-bb75-7c2088506fb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a0ddc2-d041-4ce0-8cd4-1b6dd829ec29", "AQAAAAIAAYagAAAAEBeu0AtqxEJpBDM3iHxv2tb+MVHpYiI8hU5IDFXyqdD6W4HopVuKsYzN5mCs6xgzbw==", "e930f547-a31c-47fe-a0b2-55724e999b89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69404da5-bbf3-4b50-acee-5e121027f710", "AQAAAAIAAYagAAAAEEMMtA9gMgdIJ6xOLAxriPraVqQ0dOsaP5dMlwHez9QsSfp+6/0gPP4OCZAclAbwGQ==", "c7630637-f9aa-4481-bae8-db0b4caa166a" });
        }
    }
}
