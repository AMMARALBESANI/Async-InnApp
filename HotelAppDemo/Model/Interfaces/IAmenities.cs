using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    /// <summary>
    /// This interface represents the basic method for the Amenities model
    /// </summary>
    public interface IAmenities
    {
        Task<Amenities> Create(AmenitiesDTO amenities);

        Task<List<AmenitiesDTO>> GetAmenities();

        Task<AmenitiesDTO> GetAmenity(int id);

        Task<AmenitiesDTO> UpdateAmenities(int id, AmenitiesDTO amenities);

        Task DeleteAmenities(int id);
    }
}
