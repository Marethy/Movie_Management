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
    public class ShowTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShowTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShowTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowTime>>> GetShowTimes()
        {
            return await _context.ShowTimes.ToListAsync();
        }

        // GET: api/ShowTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowTime>> GetShowTime(int id)
        {
            var showTime = await _context.ShowTimes.FindAsync(id);

            if (showTime == null)
            {
                return NotFound();
            }

            return showTime;
        }

        // PUT: api/ShowTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowTime(int id, ShowTime showTime)
        {
            if (id != showTime.ShowTimeId)
            {
                return BadRequest();
            }

            _context.Entry(showTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowTimeExists(id))
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

        // POST: api/ShowTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShowTime>> PostShowTime(ShowTime showTime)
        {
            _context.ShowTimes.Add(showTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowTime", new { id = showTime.ShowTimeId }, showTime);
        }

        // DELETE: api/ShowTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowTime(int id)
        {
            var showTime = await _context.ShowTimes.FindAsync(id);
            if (showTime == null)
            {
                return NotFound();
            }

            _context.ShowTimes.Remove(showTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowTimeExists(int id)
        {
            return _context.ShowTimes.Any(e => e.ShowTimeId == id);
        }
    }
}
