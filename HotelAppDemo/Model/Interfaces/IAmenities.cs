using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    public interface IAmenities
    {
        Task<AmenitiesDTO> Create(Amenities amenities);

        Task<List<AmenitiesDTO>> GetAmenities();

        Task<AmenitiesDTO> GetAmenity(int id);

        Task<AmenitiesDTO> UpdateAmenities(int id, Amenities amenities);

        Task DeleteAmenities(int id);
    }
}
