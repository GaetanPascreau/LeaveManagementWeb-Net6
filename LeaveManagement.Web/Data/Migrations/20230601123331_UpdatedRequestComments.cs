using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRequestComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dce240b-4ce6-4202-b816-b5cc763352a7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afce6d53-2f4a-48f6-8132-a2167fd914c5", "AQAAAAIAAYagAAAAEHrSRVbGcGZykp1jmsl9HqMrqpqSw4/CpNu/LcYSvDePbXqdhflez3HYKiRengCX1Q==", "1f4ba507-ee2e-4958-be9d-1e7d23e6765c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1b5239f-0658-49f3-aaf5-0d2466e034c4", "AQAAAAIAAYagAAAAEJh+KmeZ1kLwDuyJfOKR85hYmosH1UDAyBo97sr1MV/Bi+93WgEWrT7T+EhHjHYRqA==", "2dd16ea0-b128-4bf5-930c-f3bdbb083842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5c8a834-871b-42b8-9057-5cdcb503aeaf", "AQAAAAIAAYagAAAAEJ7siSfgWe7+VCzy2wcwJ2aXNebL4SN8pvlW2tVrSzZYDu7rFLNt53awzOk4px92iA==", "71ac70c8-ae31-474f-97be-71d30f5b19e3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
