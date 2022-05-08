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
    public class ShowerHeadsController : ControllerBase
    {
        private readonly tp17Context _context;

        public ShowerHeadsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/ShowerHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowerHead>>> GetShowerHeads()
        {
            return await _context.ShowerHeads.ToListAsync();
        }

        // GET: api/ShowerHeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowerHead>> GetShowerHead(int id)
        {
            var showerHead = await _context.ShowerHeads.FindAsync(id);

            if (showerHead == null)
            {
                return NotFound();
            }

            return showerHead;
        }

        // PUT: api/ShowerHeads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowerHead(int id, ShowerHead showerHead)
        {
            if (id != showerHead.Id)
            {
                return BadRequest();
            }

            _context.Entry(showerHead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowerHeadExists(id))
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

        // POST: api/ShowerHeads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShowerHead>> PostShowerHead(ShowerHead showerHead)
        {
            _context.ShowerHeads.Add(showerHead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowerHead", new { id = showerHead.Id }, showerHead);
        }

        // DELETE: api/ShowerHeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowerHead(int id)
        {
            var showerHead = await _context.ShowerHeads.FindAsync(id);
            if (showerHead == null)
            {
                return NotFound();
            }

            _context.ShowerHeads.Remove(showerHead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowerHeadExists(int id)
        {
            return _context.ShowerHeads.Any(e => e.Id == id);
        }
    }
}
