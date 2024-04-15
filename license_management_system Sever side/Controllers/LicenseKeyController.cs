using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.LicenseKeyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseKeyController : ControllerBase
    {
        private readonly ILicenseKeyServices _licenseKeyServices;
        private readonly DataContext _context;

        public LicenseKeyController(ILicenseKeyServices licenseKeyServices, DataContext context)
        {
            _licenseKeyServices = licenseKeyServices;
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllLicenseKeys()
        {
            var licenseKey = await _context.License_keys.ToListAsync();
            return Ok(licenseKey);
        }
        [HttpPost]
        public async Task<IActionResult> AddLicenseKey(License_keyDto licenseKey)
        {
            await _licenseKeyServices.AddLicenseKey(licenseKey);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenseKey(string key)
        {
            await _licenseKeyServices.DeleteLicenseKey(key);
            return Ok();
        }
    }
}