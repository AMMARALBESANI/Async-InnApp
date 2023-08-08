using HotelAppDemo.Data;
using HotelAppDemo.Model.DTO;
using HotelAppDemo.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelAppDemo.Model.services
{
    public class RoomServices : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomServices(HotelDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Room record in the database.
        /// </summary>
        /// <param name="room">The Room object to be created.</param>
        /// <returns>A RoomDTO object representing the created Room.</returns>
        public async Task<Room> Create(RoomDTO roomdto)
        {
            

            var room = new Room
            {
                Id = roomdto.ID,
                Name = roomdto.Name,
                layout = roomdto.Layout
            };
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }

        /// <summary>
        /// Retrieves a specific Room from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the Room to retrieve.</param>
        /// <returns>A RoomDTO object representing the retrieved Room, or null if not found.</returns>
        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.room.Select(r => new RoomDTO
            {
                ID = r.Id,
                Name = r.Name,
                Layout = r.layout,
                Amenities = r.RoomAmenities.Select(a => new AmenitiesDTO
                {
                    ID = a.Amenity.Id,
                    Name = a.Amenity.Name
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Retrieves a list of all Rooms from the database.
        /// </summary>
        /// <returns>A list of RoomDTO objects representing the retrieved Rooms.</returns>
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.room.Select(r => new RoomDTO
            {
                ID = r.Id,
                Name = r.Name,
                Layout = r.layout,
                Amenities = r.RoomAmenities.Select(a => new AmenitiesDTO
                {
                    ID = a.Amenity.Id,
                    Name = a.Amenity.Name
                }).ToList()
            }).ToListAsync();
        }

        /// <summary>
        /// Updates an existing Room record in the database based on the provided id and Room object.
        /// </summary>
        /// <param name="id">The id of the Room to update.</param>
        /// <param name="room">The updated Room object.</param>
        /// <returns>A RoomDTO object representing the updated Room.</returns>
        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO roomdto)
        {
            Room room = new Room
            {
               Id = roomdto.ID,
                Name = roomdto.Name,
                layout = roomdto.Layout
            };

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return roomdto;
        }

        /// <summary>
        /// Deletes an existing Room record from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the Room to delete.</param>
        public async Task DeleteRoom(int id)
        {
            Room room = await _context.room.FindAsync(id);

            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds an Amenity to a Room in the database.
        /// </summary>
        /// <param name="roomId">The id of the Room to which the Amenity will be added.</param>
        /// <param name="amenityId">The id of the Amenity to add.</param>
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an Amenity from a Room in the database.
        /// </summary>
        /// <param name="roomId">The id of the Room from which the Amenity will be removed.</param>
        /// <param name="amenityId">The id of the Amenity to remove.</param>
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = await _context.roomAmenities
                                            .Where(Rm => Rm.RoomId == roomId && Rm.AmenityId == amenityId)
                                            .FirstAsync();
            _context.Entry(roomAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
