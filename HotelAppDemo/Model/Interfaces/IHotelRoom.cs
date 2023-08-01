using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    public interface IHotelRoom
    {

        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);

        Task<HotelRoomDTO> AddRoomToHotel(int hotelId, HotelRoom hr);

        Task<HotelRoomDTO> RoomDetails(int hotelId, int roomNumber);

        Task<HotelRoomDTO> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoom hr);

        Task DeleteRoomFromHotel(int hotelId, int roomNumber);
    }
}
