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
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenties;

        public AmenitiesController(IAmenities amenties)
        {
            _amenties = amenties;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesDTO>>> Getamenities()
        {
            var amenities = await _amenties.GetAmenities();

            return Ok(amenities);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesDTO>> GetAmenities(int id)
        {
            var amenties = await _amenties.GetAmenity(id);
            return amenties;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }

            AmenitiesDTO modifiedAmenity = await _amenties.UpdateAmenities(id,amenities);

            return Ok(modifiedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenitiesDTO>> PostAmenities(Amenities amenities)
        {
            AmenitiesDTO newAmenity = await _amenties.Create(amenities);

            return Ok(newAmenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            await _amenties.DeleteAmenities(id);
            return NoContent();
        }

        
    }
}
