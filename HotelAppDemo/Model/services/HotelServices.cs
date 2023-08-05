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

        /// <summary>
        /// Creates a new hotel record in the database.
        /// </summary>
        /// <param name="hotel">The Hotel object to be created.</param>
        /// <returns>A HotelDTO object representing the created hotel.</returns>
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

        /// <summary>
        /// Retrieves a specific hotel from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the hotel to retrieve.</param>
        /// <returns>A HotelDTO object representing the retrieved hotel, or null if not found.</returns>
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

        /// <summary>
        /// Retrieves a list of all hotels from the database.
        /// </summary>
        /// <returns>A list of HotelDTO objects representing the retrieved hotels.</returns>
        public async Task<List<HotelDTO>> GetHotels()
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
                }).ToListAsync();
        }

        /// <summary>
        /// Updates an existing hotel record in the database based on the provided id and hotel object.
        /// </summary>
        /// <param name="id">The id of the hotel to update.</param>
        /// <param name="hotel">The updated Hotel object.</param>
        /// <returns>A HotelDTO object representing the updated hotel.</returns>
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

        /// <summary>
        /// Deletes an existing hotel record from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the hotel to delete.</param>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await _context.hotel.FindAsync(id);

            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
