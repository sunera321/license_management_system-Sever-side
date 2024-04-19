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
using SKM.V3.Methods;

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
        public async Task<IActionResult> GenerateLicenseKey(int endClientId, int requestKeyId)
        {
            try
            {
                // Validate endClientId and requestKeyId
                if (endClientId <= 0 || requestKeyId <= 0)
                {
                    return BadRequest("Invalid client or request key ID");
                }

                // Retrieve necessary data from EndClient and RequestKey tables asynchronously
                var endClient = await _context.EndClients.FirstOrDefaultAsync(e => e.Id == endClientId);
                var requestKey = await _context.RequestKeys.FirstOrDefaultAsync(r => r.RequestID == requestKeyId);

                if (endClient != null && requestKey != null)
                {
                    string Email = endClient.Email;
                    string MackAddress = endClient.MackAddress;
                    string HostUrl = endClient.HostUrl;

                    string combine= Email+MackAddress+HostUrl;
                    // Generate license key based on the provided data using SKGL library
                   // string licenseKey = GenerateSKGLLicenseKey( requestKey.NumberOfDays);

                    // Hash the generated license key
                    string hashedKey = HashString(combine);
                    
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
                    await _context.SaveChangesAsync();

                    return Ok(hashedKey);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine(ex.ToString());
                return StatusCode(500, $"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the license key");
            }
        }

      

/*
        private string GenerateSKGLLicenseKey( int numberOfDays)
        {
            // Instantiate SKGL.Generate and set secret phase
            SKGL.Generate gen = new SKGL.Generate();
            gen.secretPhase = "0748#!m";

            // Generate license key based on provided data
            string licenseKey = gen.doKey(numberOfDays);

            return licenseKey;
        }
*/
       /* private string HashString(string input)
        {
            // Hash the input string using SHA256 algorithm
            using (SHA256 sha256Hash = SHA256.Create())
            {
                
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }*/
        private string HashString(string input)
        {
            string result = "";
            try
            {
                result = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
                //result = Encoding.UTF8.GetString(System.Convert.FromBase64String(input));

            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            return result;
        }
       


        [HttpGet("decode/request/{requestId}")]
        public async Task<ActionResult<string>> DecodeLicenseKeyByRequestId(int requestId)
        {
            try
            {
                // Retrieve the license key from the database based on the request ID
                var licenseKey = await _context.License_keys.FirstOrDefaultAsync(l => l.RequestId == requestId);

                if (licenseKey != null)
                {
                    // Decode the base64-encoded string from the license key
                    string decodedKey = Conve(licenseKey.Key_name);


                    return Ok(decodedKey);
                }
                else
                {
                    return NotFound("License key not found for the given request ID.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private string Conve(string input)
        {
            string result = "";
            try
            {
                result = Encoding.UTF8.GetString(Convert.FromBase64String(input));
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log it)
                Console.Error.WriteLine(ex.ToString());
                // Return a default message or null if needed
                result = "Error occurred while decoding the string.";
            }
            return result;
        }
   

    }
}