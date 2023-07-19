using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class seedingDataOfRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "Id", "Name", "layout" },
                values: new object[,]
                {
                    { 1, "RainTrain", 2 },
                    { 2, "GreenForest", 1 },
                    { 3, "RainTrain", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
