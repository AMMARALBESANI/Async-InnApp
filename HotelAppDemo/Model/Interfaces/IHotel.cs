using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    /// <summary>
    /// This interface represents the basic method for the Hotel model
    /// </summary>
    public interface IHotel
    {
        //create
        Task<HotelDTO> Create(Hotel hotel);

        //get all
        Task<List<HotelDTO>> GetHotels();

        // get hotel by id
        Task<HotelDTO> GetHotel(int id);

        // update
        Task<HotelDTO> UpdateHotel(int id, Hotel hotel);

        //delete
        Task DeleteHotel(int id);

    }
}
