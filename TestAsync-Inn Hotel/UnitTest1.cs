
using HotelAppDemo.Model.services;
using TestAsync_Inn_Hotel;



namespace HotelDemoTest
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async Task Can_enroll_and_drop_a_Room()
        {
            // Arrange
            var room = await CreateAndSaveTestRoom();
            var amenity = await CreateAndSaveTestAmenity();

            var roomAmenity = new RoomServices(_db);

            // Act
            await roomAmenity.AddAmenityToRoom(room.Id, amenity.Id);

            // Assert
            var actualRoom = await roomAmenity.GetRoom(room.Id);

            Assert.Contains(actualRoom.Amenities, a => a.ID == amenity.Id);

            // Act
            await roomAmenity.RemoveAmentityFromRoom(room.Id, amenity.Id);

            // Assert
            actualRoom = await roomAmenity.GetRoom(room.Id);

            Assert.DoesNotContain(actualRoom.Amenities, a => a.ID == amenity.Id);
        }
    }
}