using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admain",
                column: "NormalizedName",
                value: "ADMAIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "NormalizedName",
                value: "USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admain",
                column: "NormalizedName",
                value: "admain");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "NormalizedName",
                value: "user");
        }
    }
}
