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
            Console.WriteLine("Server Data: " );
            if (serverdata.licenceKey == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null licence key");
            }

            if (serverdata.macAddress == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null Mac Address");
            }

            if (serverdata.hostUrl == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Receviced null Host Url");
            }

            // check whether the licence key is exist on licence_key table
            var dbLicenceKey = await _context.License_keys.FirstOrDefaultAsync(l => l.Key_name == serverdata.licenceKey);
            Loging_Validetion keyLog = new Loging_Validetion();
            if (dbLicenceKey == null)
            {
                // invalid licence key
                Console.WriteLine("Invalid Licence Key");
                try
                {
                    _context.Loging_Validetion.Add(keyLog);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
                return StatusCode(StatusCodes.Status200OK, "Invalid Licence Key");
            }
            else
            {
               
                keyLog.LogLicenseKey = serverdata.licenceKey;
                keyLog.ClintId = dbLicenceKey.ClintId;
                var EndClintDtl = await _context.EndClients.FirstOrDefaultAsync(c => c.Id == dbLicenceKey.ClintId);
                keyLog.PartnerId = EndClintDtl.PartnerId;
                keyLog.LogMacAddress = serverdata.macAddress;
                keyLog.LogHostUrl = serverdata.hostUrl;
                if (dbLicenceKey.MacAddress != serverdata.macAddress)
                {
                    keyLog.StatusCode = "Invalid Mac Address";
                    Console.WriteLine("Invalid Mac Address");
                    //save infomation to the database Loging_Validetion table with exeption
                    try
                    {
                        _context.Loging_Validetion.Add(keyLog);
                        _context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                    }
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid Mac Address");
                  

                 
                }
                else
                {
                    if (dbLicenceKey.HostUrl != serverdata.hostUrl)
                    {
                        keyLog.StatusCode = "Invalid Host URL";
                        Console.WriteLine("Invalid Host URL");
                        try
                        {
                            _context.Loging_Validetion.Add(keyLog);
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e);
                        }
                        return StatusCode(StatusCodes.Status404NotFound, "Invalid Host URL");
                       
                    }
                    else
                    {
                        keyLog.StatusCode = "Valid_Loging";
                        Console.WriteLine("Valid Loging");
                        try
                        {
                            _context.Loging_Validetion.Add(keyLog);
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e);
                        }
                        return StatusCode(StatusCodes.Status200OK, "Valid Loging");
                    }
                    


                }

            }



            ////////////////////////////not need////////////////////////////////////////////////////////////
/*            ClientServerInfo clientServer = new ClientServerInfo();
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
            return Ok();*/

            ///////////not need/////////////////////////////////////////////////
        }




        //get all ClientServerInfo
        [HttpGet]
        [Route("GetAllClientServerInfo")]
        public IActionResult GetAllClientServerInfo()
        {
            var Loging_Validetion = _context.Loging_Validetion.ToList();
            return Ok(Loging_Validetion);
        }
    }


}
