using HotelAppDemo.Data;
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
        public async Task<Room> Create(Room room)
        {
            _context.room.Add(room);

            await _context.SaveChangesAsync();

            return room;
        }

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Detached;

            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
           Room room = await _context.room.FindAsync(id);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        { 
            var rooms = await _context.room.ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
