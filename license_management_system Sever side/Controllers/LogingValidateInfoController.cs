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
    public class LogingValidateInfoController : ControllerBase
    {
        DataContext _context;
        public LogingValidateInfoController(DataContext context)
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
                return Ok( "Receviced null licence key");
            }

            if (serverdata.macAddress == null)
            {
                return Ok("Receviced null Mac Address");
            }

            if (serverdata.hostUrl == null)
            {
                return Ok("Receviced null Host Url");
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
                return Ok("Invalid Licence Key");
            }
            else
            {
                if(dbLicenceKey.Key_Status == "Available")
                {
                    return Ok("Licence Key is not Activated");

                }
               
               if(dbLicenceKey.DeactivatedDate < DateTime.Now)
                {
                    dbLicenceKey.Key_Status = "Expired";
                    _context.SaveChanges();
                }
                keyLog.LogLicenseKey = serverdata.licenceKey;
                keyLog.ClintId = dbLicenceKey.ClintId;
                var EndClintDtl = await _context.EndClients.FirstOrDefaultAsync(c => c.Id == dbLicenceKey.ClintId);
                var partner = await _context.Partners.FirstOrDefaultAsync(p => p.Id == EndClintDtl.PartnerId);
                keyLog.PartnerId = EndClintDtl.PartnerId;
                keyLog.LogMacAddress = serverdata.macAddress;
                keyLog.LogHostUrl = serverdata.hostUrl;
                keyLog.ClintEmail= EndClintDtl.Email;
                keyLog.ClintName = EndClintDtl.Name;
                keyLog.PartnerEmail= partner.Name;
                keyLog.PartnerName = partner.Email;
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
                    return Ok("Invalid Mac Address");
                  

                 
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
                        return Ok("Invalid Host URL");
                       
                    }
                    else
                    {
                        if (dbLicenceKey.Key_Status == "Expired")
                        {
                           
                            keyLog.StatusCode = "Expired Key";
                            Console.WriteLine("Expired Key");
                            try
                            {
                                _context.Loging_Validetion.Add(keyLog);
                                _context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e);
                            }
                            return Ok("Expired Key");
                            
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
                            return Ok("Valid Loging");
                        }

                    }
                }

            }


        }




        //get all ClientServerInfo
        [HttpGet]
        [Route("GetAllClientServerInfo")]
        public IActionResult GetAllClientServerInfo()
        {
            var Loging_Validetion = _context.Loging_Validetion.ToList();
            return Ok(Loging_Validetion);
        }

        //get clinet withing the logkey
        [HttpGet]
        [Route("GetClientServerInfo/{logKey}")]
        public IActionResult GetClientServerInfo(string logKey)
        {
            var Loging_Validetion = _context.Loging_Validetion.FirstOrDefault(l => l.LogKey == logKey);
            return Ok(Loging_Validetion);
        }


    }


}
