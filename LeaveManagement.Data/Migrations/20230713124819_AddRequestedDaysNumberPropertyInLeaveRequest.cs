using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestedDaysNumberPropertyInLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RequestedDaysNumber",
                table: "LeaveRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd585a2c-1106-4e87-850a-659fd3b85836", "AQAAAAIAAYagAAAAECbHkBKBMK3GmwYijJ2BjSYmexTGjMOy7WHjoAYDM10bhJpYGRqjp9maApj5QnSPQQ==", "9bea9a75-50cf-4ff6-ab53-27ff3b0d1d33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76553af3-dbaa-41fb-9f89-7a81997589eb", "AQAAAAIAAYagAAAAEItC+mmkXBtvfA3ckH1lAYgoxoVMZ3ZdcjbyAbIibGMqoPLD2m5yQpnTSaGc9uWz2A==", "1c969077-3716-435b-9d8d-d385be8208c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34a6fea6-da3e-4932-9a5c-d03fcf282619", "AQAAAAIAAYagAAAAEAdsYQ3HJo8qCpjyYWj3GRAygHPyST9fBFyKwgHO2AIvnmTwdKI9VJnK75QklAI/hg==", "a92a3ffe-ca78-43ef-8d8d-bd3ddc62c4a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDaysNumber",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cd9f354-d99b-487e-a864-b046086faed3", "AQAAAAIAAYagAAAAEGlo+L6US20E3vE8ub3PVQPK19dpTJYC+1JH6EG9S12UXjx5boIF4zcgV01t3BFVWg==", "1fa2d8cd-9387-405f-a837-ce1750be3469" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f3beeb9-587c-4dc5-aa61-a8231839cac8", "AQAAAAIAAYagAAAAEEltYG5uBpYzZXcqPPOEkKsW/7IBXnij0x1MLP1PE0jukt57dm05COkZGgUmy/FGfw==", "bf4d9c90-dd69-4055-9fbf-e4bd2587bcd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fb5b963-a3d3-4b9f-a138-ff2c7164eb07", "AQAAAAIAAYagAAAAEDPPsUKXmR/BjL0kcTPso+nHTEKuTFCRO36WEnyxuPKBhY/9ytop3YrNvjhrzBpgCw==", "95af7e3b-e795-4f1f-9cc1-df65463a0f30" });
        }
    }
}
