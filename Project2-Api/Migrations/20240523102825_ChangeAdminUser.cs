using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22524faa-67ba-4d56-b25e-e11cf5f2b8a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f91fb77f-7973-4bc8-996e-3f55de1e0513", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "1f7b38f3-d035-4f50-9349-bd56959e615b", "heyadrihaniyeh51@gmail.com", "heyadrihaniyeh51@gmail.com", "09215682923", "AQAAAAIAAYagAAAAEBDHNGINNj+RO2vsuR/Ecnw74peJVTVzatoFqseO+ZnlEeuRzfgh2twltzsS5juARw==", "09215682923" });
        }
    }
}
