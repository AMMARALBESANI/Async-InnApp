using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelAppDemo.Data;
using HotelAppDemo.Model;
using HotelAppDemo.Model.Interfaces;
using HotelAppDemo.Model.DTO;

namespace HotelAppDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _HotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _HotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms/1/Rooms
        [HttpGet]
        [Route("api/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelDTO>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _HotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);
        }

        // POST: api/HotelRooms/1/Rooms
        [HttpPost]
        [Route("api/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(int hotelId, HotelRoom hr)
        {
            var hotelRoom = await _HotelRoom.AddRoomToHotel(hotelId, hr);
            return Ok(hotelRoom);
        }
        // GET: api/HotelRooms/1/Rooms/1
        [HttpGet]
        [Route("api/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> GetRoomDetails(int hotelId, int roomNumber)
        {
            var room = await _HotelRoom.RoomDetails(hotelId, roomNumber);

            return Ok(room);
        }

        // PUT: api/HotelRooms/1/Rooms/1
        [HttpPut]
        [Route("api/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hr)
        {
            var newRoom = await _HotelRoom.UpdateRoomDetails(hotelId, roomNumber, hr);
            return Ok(newRoom);
        }

        // DELETE: api/HotelRooms/5/1
        [HttpDelete]
        [Route("api/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _HotelRoom.DeleteRoomFromHotel(hotelId, roomNumber);
            return NoContent();
        }


    }
}
