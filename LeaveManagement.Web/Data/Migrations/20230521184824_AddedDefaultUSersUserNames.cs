using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUSersUserNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c76420ad-4c0c-412c-95e2-4d4b05550e82", true, "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELUse28UUpI1XGVw3nQgAvDHz8cRCGOi1Esa1MkhI2oaZkGeXJmU7rJUN1gABViVDA==", "d6fa7d06-3fc1-4758-a511-e38af45b3744", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ea8d1814-b0de-49bf-9aba-46601afe479e", true, "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGA9m0QHHBNNXuRnkE/KsMBAaGctG9iXG7+NuRDDtkRFGGdrdbnfz97z+6+zi44ZDw==", "bbd133c7-1281-4882-b6ce-ad8f12b01de0", "user@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0660045f-c7e7-497e-be81-e98bc3a88b9b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8d80f8db-d639-4fe8-99f5-d36c65296b8b", false, null, "AQAAAAIAAYagAAAAEAQ+YPZ9nm9i4b3F5bZIoJcsSsY9iWDs+RqK4M6XGy2WB1e1d3Mw/sMuUqHi4Y+W0g==", "3b2eb7dc-dabf-4766-9975-d71957da7c20", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e8f2f84-ff83-435f-a213-6fd6c41605e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c8249fa1-5655-4eb9-85d8-995bf87b108f", false, null, "AQAAAAIAAYagAAAAEBYEqct7T9nOuB+24dglph/RBL8DVZhVD8l+qKNxZwdas5fIZfBIhVOX+cUPGCwqNw==", "5e2d552a-3ed0-40ac-b7bf-97781062fd62", null });
        }
    }
}
