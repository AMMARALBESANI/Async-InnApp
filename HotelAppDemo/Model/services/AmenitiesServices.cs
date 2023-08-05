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

        /// <summary>
        /// Creates a new Amenities record in the database.
        /// </summary>
        /// <param name="amenity">The Amenities object to be created.</param>
        /// <returns>An AmenitiesDTO object representing the created Amenities record.</returns>
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

        /// <summary>
        /// Retrieves a single Amenities record from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the Amenities to retrieve.</param>
        /// <returns>An AmenitiesDTO object representing the retrieved Amenities record, or null if not found.</returns>
        public async Task<AmenitiesDTO> GetAmenity(int id)
        {
            return await _context.amenities.Select(a => new AmenitiesDTO
            {
                ID = a.Id,
                Name = a.Name,
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Retrieves a list of all Amenities records from the database.
        /// </summary>
        /// <returns>A list of AmenitiesDTO objects representing the retrieved Amenities records.</returns>
        public async Task<List<AmenitiesDTO>> GetAmenities()
        {
            return await _context.amenities.Select(a => new AmenitiesDTO
            {
                ID = a.Id,
                Name = a.Name,
            }).ToListAsync();
        }

        /// <summary>
        /// Updates an existing Amenities record in the database based on the provided id and Amenities object.
        /// </summary>
        /// <param name="id">The id of the Amenities to update.</param>
        /// <param name="amenity">The updated Amenities object.</param>
        /// <returns>An AmenitiesDTO object representing the updated Amenities record.</returns>
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

        /// <summary>
        /// Deletes an existing Amenities record from the database based on the provided id.
        /// </summary>
        /// <param name="id">The id of the Amenities to delete.</param>
        public async Task DeleteAmenities(int id)
        {
            Amenities amenity = await _context.amenities.FindAsync(id);

            _context.Entry(amenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
