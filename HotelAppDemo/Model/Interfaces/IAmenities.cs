namespace HotelAppDemo.Model.Interfaces
{
    public interface IAmenities
    {
        Task<Amenities> Create(Amenities amenities);

        Task<List<Amenities>> GetAmenities();

        Task<Amenities> GetAmenity(int id);

        Task<Amenities> UpdateAmenities(int id, Amenities amenities);

        Task DeleteAmenities(int id);
    }
}
