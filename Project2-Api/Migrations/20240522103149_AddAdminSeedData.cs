using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c81513f-540a-4b31-a195-dbb50abbf054", null, "User", "USER" },
                    { "a2a2df88-2952-408d-9c34-eca9177d92ac", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2426167f-842e-4933-ae72-d8dfe34abf78", 0, "b7b4b317-a963-476d-af6e-e6c4ef422532", "heyadrihaniyeh51@gmail.com", true, false, null, "heyadrihaniyeh51@gmail.com", "09105586224", "AQAAAAIAAYagAAAAEBBZj2OaZSeQ1gGttvkmDk772sO9X57hPUX7Iad313Zp0Tun2f62XCjsEXb8JoESWA==", null, true, "", false, "09105586224" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a2a2df88-2952-408d-9c34-eca9177d92ac", "2426167f-842e-4933-ae72-d8dfe34abf78" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c81513f-540a-4b31-a195-dbb50abbf054");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a2a2df88-2952-408d-9c34-eca9177d92ac", "2426167f-842e-4933-ae72-d8dfe34abf78" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a2df88-2952-408d-9c34-eca9177d92ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78");
        }
    }
}
