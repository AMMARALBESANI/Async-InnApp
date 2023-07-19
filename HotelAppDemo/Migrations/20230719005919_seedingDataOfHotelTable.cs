using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class seedingDataOfHotelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "hotel",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAdress" },
                values: new object[,]
                {
                    { 1, "Paris", "France", "Async Inn", "00560078", " Paris", "Paris-France" },
                    { 2, "Amman", "Jordan", "Async Inn", "00962788996677", " Amman", "DownTawn" },
                    { 3, "Qairo", "Egypt", "Async Inn", "0156005098", "Qairo", "SalahSalem" }
                });

           

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hotel",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
