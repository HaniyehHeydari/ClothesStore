using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class EditName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c392d8-e4b8-4e68-852d-39e47a9005b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fc13af3-d988-4e6f-bd39-9ef6b8ce0595", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "f6b7b9f0-51c4-493a-b4f9-6b9e84ad4a2b", "حانیه", "حیدری", "AQAAAAIAAYagAAAAEAq1QnNd/jcGIX6IqOi/5CX+3NGVqxFSF0L3LKW9NrfPL0Wy/gqRQziBRctwxqoenQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc13af3-d988-4e6f-bd39-9ef6b8ce0595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7c392d8-e4b8-4e68-852d-39e47a9005b3", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "7ba7deba-ec65-41aa-8eb0-ed4d389ed281", "haniye", "heydari", "AQAAAAIAAYagAAAAEMUP4IUo/GD8AkobqFwssFiKUZ3IruJ9qUkRLkXxx1K0ybLBsHQHSJbaAzNWRaKZIQ==" });
        }
    }
}
