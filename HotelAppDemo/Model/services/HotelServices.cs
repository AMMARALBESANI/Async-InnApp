using HotelAppDemo.Data;
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
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);

            _context.Entry(hotel).State = EntityState.Detached;

            await _context.SaveChangesAsync();

        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.hotel.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.hotel.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;

        }
    }
}
