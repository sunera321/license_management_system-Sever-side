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
        public async Task<ActionResult<IEnumerable<licenseKey>>> GetLicenseKeys()
        {
            return await _context.licenseKeys.ToListAsync();
        }

        // GET: api/LicenseKey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<licenseKey>> GetLicenseKey(int id)
        {
            var licenseKey = await _context.licenseKeys.FindAsync(id);

            if (licenseKey == null)
            {
                return NotFound();
            }

            return licenseKey;
        }

        // POST: api/LicenseKey
        [HttpPost]
        public async Task<ActionResult<licenseKey>> PostLicenseKey(licenseKey licenseKey)
        {
            _context.licenseKeys.Add(licenseKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLicenseKey), new { id = licenseKey.KeyId }, licenseKey);
        }

        // PUT: api/LicenseKey/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenseKey(int id, licenseKey licenseKey)
        {
            if (id != licenseKey.KeyId)
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
            var licenseKey = await _context.licenseKeys.FindAsync(id);
            if (licenseKey == null)
            {
                return NotFound();
            }

            _context.licenseKeys.Remove(licenseKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicenseKeyExists(int id)
        {
            return _context.licenseKeys.Any(e => e.KeyId == id);
        }
    }
}
