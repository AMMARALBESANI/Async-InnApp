using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class changepetfrindlyDatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PetFrienndly",
                table: "hotelRooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PetFrienndly",
                table: "hotelRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
