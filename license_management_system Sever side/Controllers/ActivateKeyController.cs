using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateKeyController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivateKeyController(DataContext context)
        {
            _context = context;
        }
        private static async Task SendDataToUrl(string licenseKey)
        {
            using (var client = new HttpClient())
            {
                var activationData = new ActivateKey
                {
                    Clint_License_Key = licenseKey
                };

                var json = JsonConvert.SerializeObject(activationData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://licence-management.free.beeceptor.com", content);
            
            }
        }

        [HttpPost]
        public IActionResult ActivateLicnseKey(ActivateKeyDot ValidetKey)
        {
            if (ValidetKey.Clint_License_Key == null)
            {
                return BadRequest();
            }
            ActivateKeyDot activateKey = new ActivateKeyDot();
            activateKey.Clint_License_Key = ValidetKey.Clint_License_Key;

            License_key key = _context.License_keys.FirstOrDefault(c => c.Key_name == ValidetKey.Clint_License_Key);
            if (key == null)
            {
                SendDataToUrl("Invalid Key");
                Console.WriteLine("Invalid Key");
                return Ok("Invalid Key");
            }
            SendDataToUrl("Invalid Key");
            Console.WriteLine("Valid Key");
            return Ok("Valid Key");

        }

    }
}
