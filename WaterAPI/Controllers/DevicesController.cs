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
    public class DevicesController : ControllerBase
    {
        private readonly tp17Context _context;

        public DevicesController(tp17Context context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{userId}/{label}")]
        public List<KeyValuePair<Device, double>> GetDevice(int userId, String label)
        {
            var devices = _context.Devices.ToList();
            var iotRecord = _context.IotRecords.ToList();
            var userDevices = new List<Device>();
            var result = new List<KeyValuePair<Device, double>>();

            if (label == "tap") {
                label = "wash basin taps";
            }

            for (int i = 0; i < devices.Count; i++) {
                if (devices[i].UserId == userId && devices[i].Label == label) {
                    userDevices.Add(devices[i]);
                }
            }



            for (int j = 0; j < userDevices.Count; j++) {
                double sum = 0;
                for (int k = 0; k < iotRecord.Count; k++) {
                    if (userDevices[j].DeviceId == iotRecord[k].DeviceId) {
                        sum += iotRecord[k].UsedSecond.Value * iotRecord[k].FlowPerSec.Value;
                    }
                }
                result.Add(new KeyValuePair<Device, double>(userDevices[j], sum));
            }


            return result;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
