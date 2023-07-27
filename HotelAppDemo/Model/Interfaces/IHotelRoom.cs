namespace HotelAppDemo.Model.Interfaces
{
    public interface IHotelRoom
    {

        Task<List<HotelRoom>> GetHotelRooms(int hotelId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hr);

        Task<HotelRoom> RoomDetails(int hotelId, int roomNumber);

        Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoom hr);

        Task DeleteRoomFromHotel(int hotelId, int roomNumber);
    }
}
