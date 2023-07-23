namespace HotelAppDemo.Model.Interfaces
{
    public interface IHotel
    {
        //create
        Task<Hotel> Create(Hotel hotel);

        //get all
        Task<List<Hotel>> GetHotels();

        // get hotel by id
        Task<Hotel> GetHotel(int id);

        // update
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        //delete
        Task DeleteHotel(int id);

    }
}
