using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class EditAdminn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b7c8bb7-f218-4b00-b9d2-560313cbbcbf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f91fb77f-7973-4bc8-996e-3f55de1e0513", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f7b38f3-d035-4f50-9349-bd56959e615b", "AQAAAAIAAYagAAAAEBDHNGINNj+RO2vsuR/Ecnw74peJVTVzatoFqseO+ZnlEeuRzfgh2twltzsS5juARw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91fb77f-7973-4bc8-996e-3f55de1e0513");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b7c8bb7-f218-4b00-b9d2-560313cbbcbf", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8447b6aa-ae8c-4190-85f6-2e96bbc52409", "AQAAAAIAAYagAAAAEM5x5iG8HH9+pFB4fK8tfII7xEoaVe91Y0WirEBI9v2ZWzwLkMEKNRD1aE/ooaqgow==" });
        }
    }
}
