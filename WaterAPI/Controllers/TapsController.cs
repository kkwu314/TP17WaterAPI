using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterAPI.Models;

namespace WaterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapsController : ControllerBase
    {
        private readonly tp17Context _context;

        public TapsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/Taps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tap>>> GetTaps()
        {
            return await _context.Taps.ToListAsync();
        }

        // GET: api/Taps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tap>> GetTap(int id)
        {
            var tap = await _context.Taps.FindAsync(id);

            if (tap == null)
            {
                return NotFound();
            }

            return tap;
        }

        // PUT: api/Taps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTap(int id, Tap tap)
        {
            if (id != tap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TapExists(id))
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

        // POST: api/Taps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tap>> PostTap(Tap tap)
        {
            _context.Taps.Add(tap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTap", new { id = tap.Id }, tap);
        }

        // DELETE: api/Taps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTap(int id)
        {
            var tap = await _context.Taps.FindAsync(id);
            if (tap == null)
            {
                return NotFound();
            }

            _context.Taps.Remove(tap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TapExists(int id)
        {
            return _context.Taps.Any(e => e.Id == id);
        }
    }
}
