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
    public class WaterDatasController : ControllerBase
    {
        private readonly tp17Context _context;

        public WaterDatasController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/WaterDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterData>>> GetWaterData()
        {
            return await _context.WaterData.ToListAsync();
        }

        // GET: api/WaterDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterData>> GetWaterData(int id)
        {
            var waterData = await _context.WaterData.FindAsync(id);

            if (waterData == null)
            {
                return NotFound();
            }

            return waterData;
        }

        // PUT: api/WaterDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterData(int id, WaterData waterData)
        {
            if (id != waterData.WaterId)
            {
                return BadRequest();
            }

            _context.Entry(waterData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterDataExists(id))
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

        // POST: api/WaterDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WaterData>> PostWaterData(WaterData waterData)
        {
            _context.WaterData.Add(waterData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterData", new { id = waterData.WaterId }, waterData);
        }

        // DELETE: api/WaterDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterData(int id)
        {
            var waterData = await _context.WaterData.FindAsync(id);
            if (waterData == null)
            {
                return NotFound();
            }

            _context.WaterData.Remove(waterData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaterDataExists(int id)
        {
            return _context.WaterData.Any(e => e.WaterId == id);
        }
    }
}
