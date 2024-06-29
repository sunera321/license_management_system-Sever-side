using license_management_system_Sever_side.Attributes;
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

        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
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


        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
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