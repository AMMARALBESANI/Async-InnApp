
using HotelAppDemo.Data;
using HotelAppDemo.Model;
using HotelAppDemo.Model.DTO;
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
        public async Task<AmenitiesDTO> Create(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;

            await _context.SaveChangesAsync();

            AmenitiesDTO amenityDto = new AmenitiesDTO
            {
                ID = amenity.Id,
                Name = amenity.Name
            };

            return amenityDto;
        }
        public async Task<AmenitiesDTO> GetAmenity(int id)
        {
            //Amenity amenity = await _context.Amenities.FindAsync(id);

            //return amenity;

            return await _context.amenities.Select(a => new AmenitiesDTO
            {
                ID = a.Id,
                Name = a.Name,

            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<AmenitiesDTO>> GetAmenities()
        {
            //var amenities = await _context.Amenities.ToListAsync();

            //return amenities;

            return await _context.amenities.Select(a => new AmenitiesDTO
            {
                ID = a.Id,
                Name = a.Name,

            }).ToListAsync();
        }

        public async Task<AmenitiesDTO> UpdateAmenities(int id, Amenities amenity)
        {
            AmenitiesDTO amenityDto = new AmenitiesDTO
            {
                ID = amenity.Id,
                Name = amenity.Name
            };
            _context.Entry(amenity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return amenityDto;
        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenity = await _context.amenities.FindAsync(id);

            _context.Entry(amenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

    }
}
