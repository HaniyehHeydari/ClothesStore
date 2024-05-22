using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f73ccd6-d073-4a53-beb9-5b3729d39f27");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "Baskets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7c392d8-e4b8-4e68-852d-39e47a9005b3", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ba7deba-ec65-41aa-8eb0-ed4d389ed281", "AQAAAAIAAYagAAAAEMUP4IUo/GD8AkobqFwssFiKUZ3IruJ9qUkRLkXxx1K0ybLBsHQHSJbaAzNWRaKZIQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c392d8-e4b8-4e68-852d-39e47a9005b3");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "Baskets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f73ccd6-d073-4a53-beb9-5b3729d39f27", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2675cf2-9d5f-4462-92b3-2c3a5dda7c91", "AQAAAAIAAYagAAAAEB9VbhId2Rs1aUeUS9R68npvEqo9Y1XDzDv1Oek+sqZYl2fPXhOJZV5K4mEKXZR15g==" });
        }
    }
}
