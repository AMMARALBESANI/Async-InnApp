using HotelAppDemo.Data;
using HotelAppDemo.Model.DTO;
using HotelAppDemo.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelAppDemo.Model.services
{
    public class HotelServices : IHotel
    {

        private readonly HotelDbContext _context;

        public HotelServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<HotelDTO> Create(Hotel hotel)
        {

            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();

            HotelDTO hotelDTO = new HotelDTO
            {
                ID = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAdress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
            };

            return hotelDTO;
        }
        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.hotel.Select(
                hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAdress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,
                    Rooms = hotel.HotelRooms.Select(hotelR => new HotelRoomDTO
                    {
                        HotelID = hotelR.HotelId,
                        RoomNumber = hotelR.RoomNumber,
                        Rate = hotelR.Rate,
                        PetFriendly = hotelR.PetFrienndly,
                        RoomID = hotelR.RoomId,
                        Room = new RoomDTO
                        {
                            ID = hotelR.Room.Id,
                            Name = hotelR.Room.Name,
                            Layout = hotelR.Room.layout,
                            Amenities = hotelR.Room.RoomAmenities
                            .Select(A => new AmenitiesDTO
                            {
                                ID = A.Amenity.Id,
                                Name = A.Amenity.Name
                            }).ToList()
                        }
                    }).ToList()
                }).FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            //var hotels = await _context.Hotels.ToListAsync();

            //return hotels;
            return await _context.hotel.Select(
                hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAdress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,
                    Rooms = hotel.HotelRooms.Select(hotelR => new HotelRoomDTO
                    {
                        HotelID = hotelR.HotelId,
                        RoomNumber = hotelR.RoomNumber,
                        Rate = hotelR.Rate,
                        PetFriendly = hotelR.PetFrienndly,
                        RoomID = hotelR.RoomId,
                        Room = new RoomDTO
                        {
                            ID = hotelR.Room.Id,
                            Name = hotelR.Room.Name,
                            Layout = hotelR.Room.layout,
                            Amenities = hotelR.Room.RoomAmenities
                            .Select(A => new AmenitiesDTO
                            {
                                ID = A.Amenity.Id,
                                Name = A.Amenity.Name
                            }).ToList()
                        }
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<HotelDTO> UpdateHotel(int id, Hotel hotel)
        {
            HotelDTO hotelDTO = new HotelDTO
            {
                ID = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAdress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
            };

            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return hotelDTO;
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await _context.hotel.FindAsync(id);

            _context.Entry(hotel).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

    }
}
