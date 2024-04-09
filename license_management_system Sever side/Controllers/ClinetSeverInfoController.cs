﻿using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddClientServerDetails(ClientServerInfoDto serverdata)
        {
            if (serverdata.HostUrl == null && serverdata.MacAddress == null)
            {
                return BadRequest();
            }

            ClientServerInfo clientServer = new ClientServerInfo();
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

            EndClient client = _context.EndClients.FirstOrDefault(c => c.MackAddress == serverdata.MacAddress);
            if (client == null)
            {
                // Mac address is invalid
                _context.ClientServerInfos.Add(clientServer);
                Console.WriteLine("ClientServer is Invalid..." + clientServer);
                return BadRequest();
            }

       /*     if (EndClient.HostUrl != serverdata.HostUrl)
            {
                // Host URL is invalid
                _context.ClientServers.Add(clientServer);
                Console.WriteLine("ClientServer is Invalid..." + clientServer);
                return BadRequest();
            }*/

            Console.WriteLine("ClientServer is Validated..." + clientServer);
            return Ok();
        }
    }


}
