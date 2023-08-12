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
using Microsoft.AspNetCore.Authorization;

namespace HotelAppDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms/1/Rooms
        [Authorize(Policy = "read")]
        [HttpGet("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _hotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);
        }

        // POST: api/HotelRooms/1/Rooms
        [Authorize(Policy = "create")]
        [HttpPost("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(int hotelId, HotelRoomDTO hr)
        {
            var hotelRoom = await _hotelRoom.AddRoomToHotel(hotelId, hr);
            return Ok(hotelRoom);
        }

        // GET: api/HotelRooms/1/Rooms/1
        [Authorize(Policy = "read")]
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> GetRoomDetails(int hotelId, int roomNumber)
        {
            var room = await _hotelRoom.RoomDetails(hotelId, roomNumber);
            return Ok(room);
        }

        // PUT: api/HotelRooms/1/Rooms/1
        [Authorize(Policy = "update")]
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoomDTO hr)
        {
            var newRoom = await _hotelRoom.UpdateRoomDetails(hotelId, roomNumber, hr);
            return Ok(newRoom);
        }

        // DELETE: api/HotelRooms/5/1
        [Authorize(Policy = "delete")]
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.DeleteRoomFromHotel(hotelId, roomNumber);
            return NoContent();
        }
    }
}
