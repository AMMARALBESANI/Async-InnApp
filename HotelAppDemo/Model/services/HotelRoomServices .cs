using HotelAppDemo.Data;
using HotelAppDemo.Model.DTO;
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

        public async Task<HotelRoomDTO> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {
           _context.Entry(hotelRoom).State = EntityState.Added;
           await _context.SaveChangesAsync();
            HotelRoomDTO room = new HotelRoomDTO
            {
                HotelID = hotelId,
                RoomNumber = hotelRoom.RoomNumber,
                RoomID = hotelRoom.RoomId,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFrienndly,
            };


            return room;
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            return await _context.hotelRooms
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new HotelRoomDTO
                {
                    HotelID = hr.HotelId,
                    Rate = hr.Rate,
                    RoomID = hr.RoomId,
                    RoomNumber = hr.RoomNumber,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.Name,
                        Layout = hr.Room.layout,
                        Amenities = hr.Room.RoomAmenities
                            .Select(a => new AmenitiesDTO
                            {
                                ID=a.Amenity.Id,
                                Name=a.Amenity.Name,
                               
                            }).ToList()
                    }
                }).ToListAsync();
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
            await _context.SaveChangesAsync(); await _context.SaveChangesAsync();
        }

    }
}
