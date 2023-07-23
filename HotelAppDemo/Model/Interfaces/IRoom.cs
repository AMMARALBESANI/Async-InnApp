namespace HotelAppDemo.Model.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create (Room room);

        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int id);

        Task<Room> UpdateRoom(int id, Room room);

        Task DeleteRoom(int id);


    }
}
