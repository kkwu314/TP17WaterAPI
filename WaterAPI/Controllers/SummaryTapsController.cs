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
    public class SummaryTapsController : ControllerBase
    {
        private readonly tp17Context _context;

        public SummaryTapsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/SummaryTaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummaryTap>>> GetSummaryTaps()
        {
            return await _context.SummaryTaps.ToListAsync();
        }

        // GET: api/SummaryTaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SummaryTap>> GetSummaryTap(int id)
        {
            var summaryTap = await _context.SummaryTaps.FindAsync(id);

            if (summaryTap == null)
            {
                return NotFound();
            }

            return summaryTap;
        }

        // PUT: api/SummaryTaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummaryTap(int id, SummaryTap summaryTap)
        {
            if (id != summaryTap.Id)
            {
                return BadRequest();
            }

            _context.Entry(summaryTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummaryTapExists(id))
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

        // POST: api/SummaryTaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SummaryTap>> PostSummaryTap(SummaryTap summaryTap)
        {
            _context.SummaryTaps.Add(summaryTap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSummaryTap", new { id = summaryTap.Id }, summaryTap);
        }

        // DELETE: api/SummaryTaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummaryTap(int id)
        {
            var summaryTap = await _context.SummaryTaps.FindAsync(id);
            if (summaryTap == null)
            {
                return NotFound();
            }

            _context.SummaryTaps.Remove(summaryTap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummaryTapExists(int id)
        {
            return _context.SummaryTaps.Any(e => e.Id == id);
        }
    }
}
