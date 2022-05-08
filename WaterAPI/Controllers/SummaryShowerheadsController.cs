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
    public class SummaryShowerheadsController : ControllerBase
    {
        private readonly tp17Context _context;

        public SummaryShowerheadsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/SummaryShowerheads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummaryShowerhead>>> GetSummaryShowerheads()
        {
            return await _context.SummaryShowerheads.ToListAsync();
        }

        // GET: api/SummaryShowerheads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SummaryShowerhead>> GetSummaryShowerhead(int id)
        {
            var summaryShowerhead = await _context.SummaryShowerheads.FindAsync(id);

            if (summaryShowerhead == null)
            {
                return NotFound();
            }

            return summaryShowerhead;
        }

        // PUT: api/SummaryShowerheads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummaryShowerhead(int id, SummaryShowerhead summaryShowerhead)
        {
            if (id != summaryShowerhead.Id)
            {
                return BadRequest();
            }

            _context.Entry(summaryShowerhead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummaryShowerheadExists(id))
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

        // POST: api/SummaryShowerheads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SummaryShowerhead>> PostSummaryShowerhead(SummaryShowerhead summaryShowerhead)
        {
            _context.SummaryShowerheads.Add(summaryShowerhead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSummaryShowerhead", new { id = summaryShowerhead.Id }, summaryShowerhead);
        }

        // DELETE: api/SummaryShowerheads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummaryShowerhead(int id)
        {
            var summaryShowerhead = await _context.SummaryShowerheads.FindAsync(id);
            if (summaryShowerhead == null)
            {
                return NotFound();
            }

            _context.SummaryShowerheads.Remove(summaryShowerhead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummaryShowerheadExists(int id)
        {
            return _context.SummaryShowerheads.Any(e => e.Id == id);
        }
    }
}
