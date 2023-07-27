using HotelAppDemo.Data;
using HotelAppDemo.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelAppDemo.Model.services
{
    public class HotelRoomServices : IHotelRoom
    {
        private readonly HotelDbContext _context;

        public HotelRoomServices(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {
            HotelRoom room = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = hotelRoom.RoomNumber,
                RoomId = hotelRoom.RoomId,
                Rate = hotelRoom.Rate,
                PetFrienndly = hotelRoom.PetFrienndly
            };

            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            return await _context.hotelRooms.Include(r => r.Room)
                                            .ThenInclude(hr => hr.RoomAmenities)
                                            .ThenInclude(ra => ra.Amenity)
                                            .Where(x => x.HotelId == hotelId)
                                            .ToListAsync();
        }
        public async Task<HotelRoom> RoomDetails(int hotelId, int roomNumber)
        {
            HotelRoom roomDetails = await _context.hotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            HotelRoom hotelRoom = await _context.hotelRooms.Include(r => r.Room)
                                                           .ThenInclude(am => am.RoomAmenities)
                                                           .ThenInclude(a => a.Amenity)
                                                           .Where(h => h.HotelId == roomDetails.HotelId && h.RoomId == roomDetails.RoomId)
                                                           .FirstAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoom hr)
        {
            HotelRoom roomDetails = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                RoomId = hr.RoomId,
                Rate = hr.Rate,
                PetFrienndly = hr.PetFrienndly
            };

            _context.Entry(roomDetails).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hr;
        }

        public async Task DeleteRoomFromHotel(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.hotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
