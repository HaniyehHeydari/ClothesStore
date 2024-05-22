using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNameDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c81513f-540a-4b31-a195-dbb50abbf054");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Baskets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Baskets",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Baskets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f73ccd6-d073-4a53-beb9-5b3729d39f27", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "b2675cf2-9d5f-4462-92b3-2c3a5dda7c91", "haniye", "heydari", "AQAAAAIAAYagAAAAEB9VbhId2Rs1aUeUS9R68npvEqo9Y1XDzDv1Oek+sqZYl2fPXhOJZV5K4mEKXZR15g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId1",
                table: "Baskets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId1",
                table: "Baskets",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId1",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId1",
                table: "Baskets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f73ccd6-d073-4a53-beb9-5b3729d39f27");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Baskets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c81513f-540a-4b31-a195-dbb50abbf054", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2426167f-842e-4933-ae72-d8dfe34abf78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7b4b317-a963-476d-af6e-e6c4ef422532", "AQAAAAIAAYagAAAAEBBZj2OaZSeQ1gGttvkmDk772sO9X57hPUX7Iad313Zp0Tun2f62XCjsEXb8JoESWA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
