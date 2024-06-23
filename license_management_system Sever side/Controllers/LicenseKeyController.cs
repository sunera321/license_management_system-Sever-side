using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.LicenseKeyServices;
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
      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenseKey(string key)
        {
            await _licenseKeyServices.DeleteLicenseKey(key);
            return Ok();
        }



        [HttpPost]
        [Route("api/license/generate")]
        public async Task<IActionResult> GenerateLicenseKey(int endClientId, int requestKeyId)
        {
            var hashedKey = await _licenseKeyServices.GenerateLicenseKey(endClientId, requestKeyId);
            return Ok(hashedKey);
        }

        [HttpGet("decode/request/{requestId}")]
        public async Task<ActionResult<string>> DecodeLicenseKeyByRequestId(int requestId)
        {
            try
            {
                var decodedKey = await _licenseKeyServices.DecodeLicenseKeyByRequestId(requestId);
                return Ok(decodedKey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Activation statistics
        [HttpGet("statistics")]
        public async Task<IActionResult> GetActivationStatisticsAsync()
        {
            try
            {
                var statistics = await _licenseKeyServices.GetActivationStatisticsAsync();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






            }

}