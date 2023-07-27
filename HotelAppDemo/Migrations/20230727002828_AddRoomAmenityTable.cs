using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomAmenityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roomAmenities",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AmenitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomAmenities", x => new { x.AmenitiesId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_roomAmenities_amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roomAmenities_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roomAmenities_RoomId",
                table: "roomAmenities",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roomAmenities");
        }
    }
}
