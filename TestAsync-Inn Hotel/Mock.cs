

using HotelAppDemo.Data;
using HotelAppDemo.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestAsync_Inn_Hotel
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HotelDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HotelDbContext(
                new DbContextOptionsBuilder<HotelDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { Name = "RoomTest", layout = 1 };
            _db.room.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.Id); // Sanity check
            return room;
        }

        protected async Task<Amenities> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenities { Name = "AmenityTest" };
            _db.amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.Id); // Sanity check
            return amenity;
        }
    }
}
