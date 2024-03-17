using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {

        private readonly LicenseKeyContext _licensekeyContext;
        public LicenseController(LicenseKeyContext licenseKeyContext)
        {
            _licensekeyContext = licenseKeyContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenseKey>>> GetLicenseKey()
        {
            if (_licensekeyContext.LicenseKeys == null)
            {
                return NotFound();
            }
            return await _licensekeyContext.LicenseKeys.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenseKey>> GetLicensekey(int id)
        {
            if (_licensekeyContext.LicenseKeys == null)
            {
                return NotFound();
            }
            var licensekey = await _licensekeyContext.LicenseKeys.FindAsync(id);
            if (licensekey == null)
            {
                return NotFound();
            }
            return licensekey;

        }
        [HttpPost]
        public async Task<ActionResult<LicenseKey>> PostLicensekey(LicenseKey licenseKey)
        {
            _licensekeyContext.LicenseKeys.Add(licenseKey);
            await _licensekeyContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLicensekey), new { id = licenseKey.CID }, licenseKey);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLicensekey(int id, LicenseKey licensekey)
        {
            if (id != licensekey.CID)
            {
                return BadRequest();
            }

            _licensekeyContext.Entry(licensekey).State = EntityState.Modified;
            try
            {
                await _licensekeyContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLicensekey(int id)
        {
            if (_licensekeyContext.LicenseKeys == null)
            {
                return NotFound();
            }
            var licensekey = await _licensekeyContext.LicenseKeys.FindAsync(id);
            if (licensekey == null)
            {
                return NotFound();

            }
            _licensekeyContext.LicenseKeys.Remove(licensekey);
            await _licensekeyContext.SaveChangesAsync();

            return Ok();
        }
    }
}
