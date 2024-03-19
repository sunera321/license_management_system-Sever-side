using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostedSitesController : ControllerBase
    {
        private List<PostDataModel> _siteDataList = new List<PostDataModel>();

        [HttpPost]
        public IActionResult PostData([FromBody] PostDataModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data received");
                }

               
                _siteDataList.Add(model);

               
                Console.WriteLine("Received Data:");
                Console.WriteLine($"Host URL: {model.HostUrl}");
                Console.WriteLine($"MAC Address: {model.MacAddress}");
                Console.WriteLine("Site Names:");
                foreach (var siteName in model.SiteNames)
                {
                    Console.WriteLine(siteName);
                }

                return Ok("Data received and stored successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetStoredData()
        {
            try
            {
                return Ok(_siteDataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
