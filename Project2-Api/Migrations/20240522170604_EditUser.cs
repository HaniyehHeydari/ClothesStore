using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class EditUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc13af3-d988-4e6f-bd39-9ef6b8ce0595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bb11e06-36ad-47ec-8f11-7c97fe3fa3a6", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44756ed7-be21-4e6d-929c-a912682fb7c9", "AQAAAAIAAYagAAAAEAPbGjMVx20w4k2tyt0iEd0m+BwnEGpz1eM4SiMOlqX5s7v4f0VV132snGHKggLw/w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bb11e06-36ad-47ec-8f11-7c97fe3fa3a6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fc13af3-d988-4e6f-bd39-9ef6b8ce0595", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6b7b9f0-51c4-493a-b4f9-6b9e84ad4a2b", "AQAAAAIAAYagAAAAEAq1QnNd/jcGIX6IqOi/5CX+3NGVqxFSF0L3LKW9NrfPL0Wy/gqRQziBRctwxqoenQ==" });
        }
    }
}
