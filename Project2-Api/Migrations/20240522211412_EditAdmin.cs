using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class EditAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8d97e7a-095a-412a-8f86-995f1eff123a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b7c8bb7-f218-4b00-b9d2-560313cbbcbf", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "8447b6aa-ae8c-4190-85f6-2e96bbc52409", "09215682923", "AQAAAAIAAYagAAAAEM5x5iG8HH9+pFB4fK8tfII7xEoaVe91Y0WirEBI9v2ZWzwLkMEKNRD1aE/ooaqgow==", "09215682923" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b7c8bb7-f218-4b00-b9d2-560313cbbcbf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8d97e7a-095a-412a-8f86-995f1eff123a", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "27e5f46e-28dc-45dd-bf52-097f93bf84cb", "09105586224", "AQAAAAIAAYagAAAAENEFNwq45JSrP5NqIJD4MDYObIWgtiuikrDDmbhSoaAx/oYc7xCVPPqL80t5K3f4Cw==", "09105586224" });
        }
    }
}
