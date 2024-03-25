using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.DTOs;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinetSeverDtl : ControllerBase
    {
        AplicationDbContext _context;
        public ClinetSeverDtl(AplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("AddClientServerDetails")]
        public IActionResult AddClientServerDetails(SeverDetailsDto serverdata)
        {
            if (serverdata.HostUrl == null && serverdata.MacAddress == null)
            {
                return BadRequest();
            }

            ClientServer clientServer = new ClientServer();
            clientServer.HostUrl = serverdata.HostUrl;
            clientServer.MacAddress = serverdata.MacAddress;
            clientServer.testDate = DateTime.Now;
            clientServer.SiteNames = new List<ClientServerSiteName>();

            foreach (string siteName in serverdata.SiteNames)
            {
                ClientServerSiteName name = new ClientServerSiteName();
                name.SiteName = siteName;
                name.MacAddress = serverdata.MacAddress;
                clientServer.SiteNames.Add(name);
            }

            EndClient client = _context.Clients.FirstOrDefault(c => c.MacAddress == serverdata.MacAddress);
            if (client == null)
            {
                // Mac address is invalid
                _context.ClientServers.Add(clientServer);
                Console.WriteLine("ClientServer is Invalid..." + clientServer);
                return BadRequest();
            }

            if (client.HostURL != serverdata.HostUrl)
            {
                // Host URL is invalid
                _context.ClientServers.Add(clientServer);
                Console.WriteLine("ClientServer is Invalid..." + clientServer);
                return BadRequest();
            }

            Console.WriteLine("ClientServer is Validated..."+clientServer);
            return Ok();
        }
    }

    
}
