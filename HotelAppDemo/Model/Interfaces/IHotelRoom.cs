using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    /// <summary>
    /// This interface represents the basic method for the HotelRoom model
    /// </summary>
    public interface IHotelRoom
    {

        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);

        Task<HotelRoomDTO> AddRoomToHotel(int hotelId, HotelRoomDTO hr);

        Task<HotelRoomDTO> RoomDetails(int hotelId, int roomNumber);

        Task<HotelRoomDTO> UpdateRoomDetails(int hotelId, int roomNumber,HotelRoomDTO hotelRoomdto);

        Task DeleteRoomFromHotel(int hotelId, int roomNumber);
    }
}
