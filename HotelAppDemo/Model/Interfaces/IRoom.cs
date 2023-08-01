﻿using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Model.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> Create (Room room);

        Task<List<RoomDTO>> GetRooms();

        Task<RoomDTO> GetRoom(int id);

        Task<RoomDTO> UpdateRoom(int id, Room room);

        Task DeleteRoom(int id);


        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmentityFromRoom(int roomId, int amenityId);


    }
}
