using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.LicenseKeyServices;
using MathNet.Numerics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using SKGL;

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
        [HttpPost]
        [Route("api/license/generate")]
        public IActionResult GenerateLicenseKey(int endClientId, int requestKeyId)
        {
            try
            {
                // Retrieve necessary data from EndClient and RequestKey tables
                var endClient = _context.EndClients.FirstOrDefault(e => e.Id == endClientId);
                var requestKey = _context.RequestKeys.FirstOrDefault(r => r.RequestID == requestKeyId);

                if (endClient != null && requestKey != null)
                {
                    // Generate license key based on the provided data using SKGL library
                    string licenseKey = GenerateSKGLLicenseKey(endClient.Email, endClient.MackAddress, endClient.HostUrl, requestKey.NumberOfDays);

                    // Hash the generated license key
                    string hashedKey = HashString(licenseKey);

                    // Store hashed license key in License_key table
                    var license = new License_key
                    {
                        Key_name = hashedKey,
                        ActivationDate = DateTime.Now,
                        DeactivatedDate = DateTime.Now.AddDays(requestKey.NumberOfDays),
                        Key_Status = "Activated", // Assuming you want to activate the key upon generation
                        RequestId = requestKey.RequestID
                    };

                    _context.License_keys.Add(license);
                    _context.SaveChanges();

                    return Ok(hashedKey);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving license key: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/license/add")]
        public async Task<IActionResult> MakeLicenseKey(License_keyDto licenseKey)
        {
            try
            {
                // Generate license key based on the provided data using SKGL library
                string licenseKeyString = GenerateSKGLLicenseKey(licenseKey.Email, licenseKey.MackAddress, licenseKey.HostUrl, licenseKey.NumberOfDays);

                // Hash the generated license key
                string hashedKey = HashString(licenseKeyString);

                // Store hashed license key in License_key table
                var newLicenseKey = new License_key
                {
                    Key_name = hashedKey,
                    ActivationDate = DateTime.Now,
                    DeactivatedDate = DateTime.Now.AddDays(licenseKey.NumberOfDays),
                    Key_Status = "Activated" ,// Assuming you want to activate the key upon generation
                    RequestId = 28
                };

                _context.License_keys.Add(newLicenseKey);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving license key: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        private string GenerateSKGLLicenseKey(string email, string macAddress, string hostUrl, int numberOfDays)
        {
            // Instantiate SKGL.Generate and set secret phase
            SKGL.Generate gen = new SKGL.Generate();
            gen.secretPhase = "0748#!m";

            // Generate license key based on provided data
            string licenseKey = gen.doKey(numberOfDays);

            return licenseKey;
        }

        private string HashString(string input)
        {
            // Hash the input string using SHA256 algorithm
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
    }
}