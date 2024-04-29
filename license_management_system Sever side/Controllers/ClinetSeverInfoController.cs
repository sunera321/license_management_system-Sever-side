using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinetSeverInfoController : ControllerBase
    {
        DataContext _context;
        public ClinetSeverInfoController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("AddClientServerDetails")]
        public async Task<IActionResult> AddClientServerDetails(ClientServerInfoDto serverdata)
        {
            if (serverdata.LicenceKey == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null licence key");
            }
            
            if (serverdata.MacAddress == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null Mac Address");
            }

            if (serverdata.HostUrl == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null Host Url");
            }

            // check whether the licence key is exist on licence_key table
            var dbLicenceKey = await _context.License_keys.FirstOrDefaultAsync(l => l.Key_name == serverdata.LicenceKey);

            if (dbLicenceKey == null)
            {
                // invalid licence key
                return StatusCode(StatusCodes.Status404NotFound, "Invalid Licence Key");
            }

            // check whether the recieved mac address is belongs to the licence key
            if (dbLicenceKey.MacAddress != serverdata.MacAddress)
            {
                // invalid mac address
                
                // create new table for hold login with invalid mac address
                // ClientId, partnerID, macaddress, licence key, login time, status
                // create service for this table
                //these task are done in this function
                // search client id from maac address
                // search partner id from mac address
                // create dto to add data to the table
                // call the function

            }

            ClientServerInfo clientServer = new ClientServerInfo();
            clientServer.HostUrl = serverdata.HostUrl;
            clientServer.MacAddress = serverdata.MacAddress;
            clientServer.testDate = DateTime.Now;
            clientServer.licenceKey = serverdata.LicenceKey;
            clientServer.SiteNames = new List<ClientServerSiteName>();

            foreach (string siteName in serverdata.SiteNames)
            {
                ClientServerSiteName name = new ClientServerSiteName();
                name.SiteName = siteName;
                name.MacAddress = serverdata.MacAddress;
                clientServer.SiteNames.Add(name);
            }

            EndClient client = _context.EndClients.FirstOrDefault(c => c.MackAddress == serverdata.MacAddress);
            Console.WriteLine("ClientServer is Invalid Clint..." + clientServer);
            Console.WriteLine("ClientServer is Invalid Clint..." + clientServer);
            _context.ClientServerInfos.Add(clientServer);
            if (client == null)
            {
                // Mac address is invalid

                Console.WriteLine("ClientServer is Invalid Clint..." + clientServer);
                return Ok("Invalid Clint");
            }

            if (client.HostUrl != serverdata.HostUrl)
            {
                // Host URL is invalid
               
                Console.WriteLine("ClientServer is MacAddress is Validated..." + clientServer);
                Console.WriteLine("ClientServer is Host URl Invalid..." + clientServer);
                return Ok("Invalid Host URl");
            }
         

            Console.WriteLine("ClientServer is MacAddress and Host URl Validated..." + clientServer);
            return Ok();
        }

        //get all ClientServerInfo
        [HttpGet]
        [Route("GetAllClientServerInfo")]
        public IActionResult GetAllClientServerInfo()
        {
            var clientServerInfo = _context.ClientServerInfos.ToList();
            return Ok(clientServerInfo);
        }
    }


}
