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
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenties;

        public AmenitiesController(IAmenities amenties)
        {
            _amenties = amenties;
        }

        // GET: api/Amenities
        [Authorize(Policy = "create")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesDTO>>> Getamenities()
        {
            var amenities = await _amenties.GetAmenities();

            return Ok(amenities);
        }

        // GET: api/Amenities/5
        [Authorize(Policy = "create")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesDTO>> GetAmenities(int id)
        {
            var amenties = await _amenties.GetAmenity(id);
            return amenties;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, AmenitiesDTO amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            var modifiedAmenity = await _amenties.UpdateAmenities(id,amenities);

            return Ok(modifiedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = "create")]
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(AmenitiesDTO amenities)
        {
            var newAmenity = await _amenties.Create(amenities);

            return Ok(newAmenity);
        }

        // DELETE: api/Amenities/5
        [Authorize(Policy = "delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            await _amenties.DeleteAmenities(id);
            return NoContent();
        }

        
    }
}
