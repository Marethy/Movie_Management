using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TheatersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Theaters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theater>>> GetTheaters()
        {
            return await _context.Theaters.ToListAsync();
        }

        // GET: api/Theaters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theater>> GetTheater(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);

            if (theater == null)
            {
                return NotFound();
            }

            return theater;
        }

        // PUT: api/Theaters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheater(int id, Theater theater)
        {
            if (id != theater.TheaterID)
            {   
                return BadRequest();
            }

            _context.Entry(theater).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheaterExists(id))
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

        // POST: api/Theaters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theater>> PostTheater(Theater theater)
        {
            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheater", new { id = theater.TheaterID }, theater);
        }

        // DELETE: api/Theaters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheaterExists(int id)
        {
            return _context.Theaters.Any(e => e.TheaterID == id);
        }
    }
}
