using AmemitiesAppDemo.Data;
using AmemitiesAppDemo.Model.Interfaces;
using HotelAppDemo.Data;
using HotelAppDemo.Model;
using HotelAppDemo.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmemitiesAppDemo.Model.services
{
    public class AmenitiesServices : IAmenities
    {


        private readonly HotelDbContext _context;

        public AmenitiesServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Amenities> Create(Amenities amenities)
        {
            _context.amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenities = await GetAmenity(id);

            _context.Entry(amenities).State = EntityState.Detached;

            await _context.SaveChangesAsync();

        }

        public async Task<List<Amenities>> GetAmenities()
        {
            var amenitiess = await _context.amenities.ToListAsync();
            return amenitiess;
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            Amenities amenities = await _context.amenities.FindAsync(id);
            return amenities;
        }

        public async Task<Amenities> UpdateAmenities(int id, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenities;
        }
    }
}
