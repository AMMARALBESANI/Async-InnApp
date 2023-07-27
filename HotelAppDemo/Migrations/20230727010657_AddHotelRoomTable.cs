using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomAmenities_amenities_AmenitiesId",
                table: "roomAmenities");

            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "roomAmenities",
                newName: "AmenityId");

            migrationBuilder.CreateTable(
                name: "hotelRooms",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PetFrienndly = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRooms", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_hotelRooms_hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotelRooms_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotelRooms_RoomId",
                table: "hotelRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_roomAmenities_amenities_AmenityId",
                table: "roomAmenities",
                column: "AmenityId",
                principalTable: "amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomAmenities_amenities_AmenityId",
                table: "roomAmenities");

            migrationBuilder.DropTable(
                name: "hotelRooms");

            migrationBuilder.RenameColumn(
                name: "AmenityId",
                table: "roomAmenities",
                newName: "AmenitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_roomAmenities_amenities_AmenitiesId",
                table: "roomAmenities",
                column: "AmenitiesId",
                principalTable: "amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
