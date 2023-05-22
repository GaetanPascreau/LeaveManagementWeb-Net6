using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedRegisterAndSeededTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f101be0-5fad-4fee-babf-c1ccc1e7a080", "AQAAAAIAAYagAAAAENPtkaOXWvWIgpgGrD2oHaZuvvOdMDTMDRIXd6Q8bL8z2JBdwlUp6zLbuGxYvDxQ3w==", "ad551ad9-c1c7-4eba-b8ad-f3fd45602477" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d39827cc-3901-48b8-a3ee-d4173308902d", "AQAAAAIAAYagAAAAEGg+vm8b8nMf5zGRu6pG5M3dek4C9jwYhC8GMMvZaosQ46XRyPfpc8Om7G6mHBcPpQ==", "238b9aee-994a-4261-8586-429a049388e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "367dc0a0-b5b0-4eb9-ba34-d7848b88222e", "AQAAAAIAAYagAAAAEI6r6HTz7HS1Q91eJ3AGzhZ2mOydldx3gklrHVMVjDuiy+C4KFj8szdLHV2xT0lNXQ==", "031baddc-163f-4ac7-a8a7-a6fda692b1f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4dcf0d-9187-40ac-bb6a-81b1309a7c31", "AQAAAAIAAYagAAAAEK5PwANVIVoK+qnv4L9Tnw4IOoS/YwTBefGp1IxgkwWkWBuxttUzHBgq6LZ6bApB1Q==", "05ce147a-fa69-40fb-afd7-f4aef6251499" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb0b5bc4-c8ca-4513-b6e9-cad12903a5f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc50f571-2080-40e2-90d3-02ca3ff7adfb", "AQAAAAIAAYagAAAAECL8NDmuBLMiYxP8iulVlypW0/C3CkZ73XIQ4OPTiPm0sAZ8AtL3TwY6cWNOG8BRCA==", "7670f1ad-f12d-4d63-9914-876beffe589f" });
        }
    }
}
