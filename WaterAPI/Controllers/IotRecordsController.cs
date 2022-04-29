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
    public class IotRecordsController : ControllerBase
    {
        private readonly tp17Context _context;

        public IotRecordsController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/IotRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IotRecord>>> GetIotRecords()
        {
            return await _context.IotRecords.ToListAsync();
        }

        // GET: api/IotRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IotRecord>> GetIotRecord(int id)
        {
            var iotRecord = await _context.IotRecords.FindAsync(id);

            if (iotRecord == null)
            {
                return NotFound();
            }

            return iotRecord;
        }

        // PUT: api/IotRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIotRecord(int id, IotRecord iotRecord)
        {
            if (id != iotRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(iotRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IotRecordExists(id))
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

        // POST: api/IotRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IotRecord>> PostIotRecord(IotRecord iotRecord)
        {
            _context.IotRecords.Add(iotRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIotRecord", new { id = iotRecord.Id }, iotRecord);
        }

        // DELETE: api/IotRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIotRecord(int id)
        {
            var iotRecord = await _context.IotRecords.FindAsync(id);
            if (iotRecord == null)
            {
                return NotFound();
            }

            _context.IotRecords.Remove(iotRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IotRecordExists(int id)
        {
            return _context.IotRecords.Any(e => e.Id == id);
        }
    }
}
