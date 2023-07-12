using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingSupervisorIdAndEmployerToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "2cd9f354-d99b-487e-a864-b046086faed3", "Sogescot", "AQAAAAIAAYagAAAAEGlo+L6US20E3vE8ub3PVQPK19dpTJYC+1JH6EG9S12UXjx5boIF4zcgV01t3BFVWg==", "1fa2d8cd-9387-405f-a837-ce1750be3469", "8d30dbae-134d-4137-8e2e-ec7c96ee1d82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "7f3beeb9-587c-4dc5-aa61-a8231839cac8", "Sogescot", "AQAAAAIAAYagAAAAEEltYG5uBpYzZXcqPPOEkKsW/7IBXnij0x1MLP1PE0jukt57dm05COkZGgUmy/FGfw==", "bf4d9c90-dd69-4055-9fbf-e4bd2587bcd6", "8d30dbae-134d-4137-8e2e-ec7c96ee1d82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "2fb5b963-a3d3-4b9f-a138-ff2c7164eb07", "Sogescot", "AQAAAAIAAYagAAAAEDPPsUKXmR/BjL0kcTPso+nHTEKuTFCRO36WEnyxuPKBhY/9ytop3YrNvjhrzBpgCw==", "95af7e3b-e795-4f1f-9cc1-df65463a0f30", "3dce240b-4ce6-4202-b816-b5cc763352a7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "AspNetUsers");

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
    }
}
