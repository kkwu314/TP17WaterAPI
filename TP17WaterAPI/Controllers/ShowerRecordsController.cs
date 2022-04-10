using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP17WaterAPI.Models;

namespace TP17WaterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class ShowerRecordsController : ControllerBase
    {
        private readonly tp17Context _context;

        public ShowerRecordsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/ShowerRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowerRecord>>> GetShowerRecords()
        {
            return await _context.ShowerRecords.ToListAsync();
        }

        // GET: api/ShowerRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowerRecord>> GetShowerRecord(int id)
        {
            var showerRecord = await _context.ShowerRecords.FindAsync(id);

            if (showerRecord == null)
            {
                return NotFound();
            }

            return showerRecord;
        }

        // PUT: api/ShowerRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowerRecord(int id, ShowerRecord showerRecord)
        {
            if (id != showerRecord.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(showerRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowerRecordExists(id))
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

        // POST: api/ShowerRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShowerRecord>> PostShowerRecord(ShowerRecord showerRecord)
        {
            _context.ShowerRecords.Add(showerRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowerRecord", new { id = showerRecord.RecordId }, showerRecord);
        }

        // DELETE: api/ShowerRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowerRecord(int id)
        {
            var showerRecord = await _context.ShowerRecords.FindAsync(id);
            if (showerRecord == null)
            {
                return NotFound();
            }

            _context.ShowerRecords.Remove(showerRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowerRecordExists(int id)
        {
            return _context.ShowerRecords.Any(e => e.RecordId == id);
        }
    }
}
