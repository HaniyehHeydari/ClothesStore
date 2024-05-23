using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dedf8bb-7c79-4ebe-abcb-72eb7864de3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8d97e7a-095a-412a-8f86-995f1eff123a", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27e5f46e-28dc-45dd-bf52-097f93bf84cb", "AQAAAAIAAYagAAAAENEFNwq45JSrP5NqIJD4MDYObIWgtiuikrDDmbhSoaAx/oYc7xCVPPqL80t5K3f4Cw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8d97e7a-095a-412a-8f86-995f1eff123a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2dedf8bb-7c79-4ebe-abcb-72eb7864de3e", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75025f24-b5ce-4adb-9731-b60f5bb51343", "AQAAAAIAAYagAAAAEDtZen0RGv5KOCzu+ovCHkR33NQCoX4aJGNy6YsTzj/1q+eKyPGb6tJeprFs3oJl/w==" });
        }
    }
}
