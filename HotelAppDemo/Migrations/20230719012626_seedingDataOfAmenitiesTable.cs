using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class seedingDataOfAmenitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ac" },
                    { 2, "CoffeMaker" },
                    { 3, "Sawna" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "amenities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
