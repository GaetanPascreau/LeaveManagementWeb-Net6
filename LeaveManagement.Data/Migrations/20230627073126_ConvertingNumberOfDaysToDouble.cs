using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertingNumberOfDaysToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DefaultDays",
                table: "LeaveTypes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c13fb47c-f460-4e21-ae5d-6850e4041605", "AQAAAAIAAYagAAAAEJBKn31SAjTSKklovrYiMKIy+Y1VoCIY0yfjl5vAfrIFa0iXq652RMvZrSuKIvpzyQ==", "84186ce1-f6e9-45e3-8e05-388b7f63fad3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf0ae6e9-2862-468b-82f5-012c6d9a7015", "AQAAAAIAAYagAAAAELeBvp2KyYKxeHxOVbalu6iTUGWuJDd2tY2Ex0u9ZfsHdmsIdY12W73mzzW/GGOmuw==", "c6f4d5ef-f8d6-425b-a3ac-90ac4b9cf207" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3528332f-00fe-43c6-b745-6292e45c2b27", "AQAAAAIAAYagAAAAEJ3qiN+oZYlSJ5+9yJLwEtrhKwOsF59fZcfkhdkLhGwpRqZt6p3dqAIAoaM7sACStQ==", "c087c1bd-52b3-4931-937e-334c9d599524" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DefaultDays",
                table: "LeaveTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
