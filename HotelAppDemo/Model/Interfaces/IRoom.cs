using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    /// <summary>
    /// This interface represents the basic method for the room model
    /// </summary>
    public interface IRoom
    {
        Task<Room> Create (RoomDTO room);

        Task<List<RoomDTO>> GetRooms();

        Task<RoomDTO> GetRoom(int id);

        Task<RoomDTO> UpdateRoom(int id, RoomDTO room);

        Task DeleteRoom(int id);


        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmentityFromRoom(int roomId, int amenityId);


    }
}
