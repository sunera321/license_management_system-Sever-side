using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseKeyController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public LicenseKeyController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LicenseKey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Key>>> GetKeys()
        {
            return await _context.Keys.ToListAsync();
        }

        // GET: api/LicenseKey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Key>> GetKey(int id)
        {
            var licenseKey = await _context.Keys.FindAsync(id);

            if (licenseKey == null)
            {
                return NotFound();
            }

            return licenseKey;
        }

        

        // POST: api/LicenseKey
        [HttpPost]
        public async Task<ActionResult<Key>> CreateLicenseKey(Key keyDTO)
        {
            var key = new Key
            {
                ClientID = keyDTO.ClientID,
                Hos = keyDTO.Hos,
                SerMac = keyDTO.SerMac,
                ValidDate = keyDTO.ValidDate,
               
                Modules = keyDTO.Modules
            };

            _context.Keys.Add(key);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKey), new { id = key.Cid }, key);
        }
        // PUT: api/LicenseKey/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenseKey(int id, Key licenseKey)
        {
            if (id != licenseKey.Cid)
            {
                return BadRequest();
            }

            _context.Entry(licenseKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenseKeyExists(id))
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

        // DELETE: api/LicenseKey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenseKey(int id)
        {
            var licenseKey = await _context.Keys.FindAsync(id);
            if (licenseKey == null)
            {
                return NotFound();
            }

            _context.Keys.Remove(licenseKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicenseKeyExists(int id)
        {
            return _context.Keys.Any(e => e.Cid == id);
        }
    }
}
