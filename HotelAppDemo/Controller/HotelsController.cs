﻿using System;
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
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> Gethotel()
        {

            var hotels = await _hotel.GetHotels();

            return Ok(hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            HotelDTO hotel = await _hotel.GetHotel(id);

            return Ok(hotel);


        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }
            HotelDTO modifiedHotel = await _hotel.UpdateHotel(id, hotel);

            return Ok(modifiedHotel);

        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotel(Hotel hotel)
        {
            HotelDTO newHotel = await _hotel.Create(hotel);

            return Ok(newHotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }

        
    }
}
