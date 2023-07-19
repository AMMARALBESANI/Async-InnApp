using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelAppDemo.Data;
using HotelAppDemo.Model;

namespace HotelAppDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public AmenitiesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> Getamenities()
        {
          if (_context.amenities == null)
          {
              return NotFound();
          }
            return await _context.amenities.ToListAsync();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
          if (_context.amenities == null)
          {
              return NotFound();
          }
            var amenities = await _context.amenities.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
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

            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
          if (_context.amenities == null)
          {
              return Problem("Entity set 'HotelDbContext.amenities'  is null.");
          }
            _context.amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            if (_context.amenities == null)
            {
                return NotFound();
            }
            var amenities = await _context.amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            _context.amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmenitiesExists(int id)
        {
            return (_context.amenities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
