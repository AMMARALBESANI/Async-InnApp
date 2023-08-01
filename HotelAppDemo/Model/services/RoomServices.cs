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

        public async Task<RoomDTO> Create(Room room)
        {

            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();

            RoomDTO roomDTO = new RoomDTO
            {
                ID = room.Id,
                Name = room.Name,
                Layout = room.layout
            };

            return roomDTO;
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            //Room room = await _context.Rooms.FindAsync(id);
            //return room;

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

        public async Task<List<RoomDTO>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;

            //return await _context.Rooms.Include(ra => ra.RoomAmenities)
            //                           .ThenInclude(a => a.Amenity)
            //                           .ToListAsync();

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

        public async Task<RoomDTO> UpdateRoom(int id, Room room)
        {
            RoomDTO roomDTO = new RoomDTO
            {
                ID = room.Id,
                Name = room.Name,
                Layout = room.layout
            };

            _context.Entry(room).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return roomDTO;
        }

        public async Task DeleteRoom(int id)
        {
            Room room = await _context.room.FindAsync(id);

            _context.Entry(room).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

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

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = await _context.roomAmenities
                                            .Where(Rm => Rm.RoomId == roomId && Rm.AmenityId == amenityId)
                                            .FirstAsync();
            _context.Entry(roomAmenity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
