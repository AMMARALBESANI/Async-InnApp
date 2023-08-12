using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedClaims4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admain");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "agent", "00000000-0000-0000-0000-000000000000", "Agent", "AGENT" },
                    { "anonymoususers", "00000000-0000-0000-0000-000000000000", "AnonymousUsers", "ANONYMOUSUSERS" },
                    { "districtmanager", "00000000-0000-0000-0000-000000000000", "DistrictManager", "DISTRICTMANAGER" },
                    { "propertymanager", "00000000-0000-0000-0000-000000000000", "PropertyManager", "PROPERTYMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "agent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "anonymoususers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "districtmanager");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "propertymanager");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admain", "00000000-0000-0000-0000-000000000000", "Admain", "ADMAIN" },
                    { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" }
                });
        }
    }
}
