using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.LogingValidateInfoSerives
{
    public class LogingValidateInfoSerives: ILogingValidateInfoSerives
    {
        private  DataContext _context;
        public string Loggingmessage;

        public LogingValidateInfoSerives(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddClientServerDetailsAsync(ClientServerInfoDto serverdata)
        {
            if (serverdata.licenceKey == null)
            {
                return "Receviced null licence key";
            }

            if (serverdata.macAddress == null)
            {
                return "Receviced null Mac Address";
            }

            if (serverdata.hostUrl == null)
            {
                return "Receviced null Host Url";
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
                return "Invalid Licence Key";
            }
            else
            {
                if (dbLicenceKey.Key_Status == "Available")
                {
                    return "Licence Key is not Activated";

                }

                if (dbLicenceKey.DeactivatedDate < DateTime.Now)
                {
                    if (dbLicenceKey.Key_Status != "Expired")
                    {
                        dbLicenceKey.Key_Status = "Expired";
                        _context.SaveChanges();
                        Console.WriteLine("Expired");
                        var endClientModules = await _context.EndClientModules.Where(x => x.EndClientId == dbLicenceKey.ClintId).ToListAsync();
                        foreach (var endClientModule in endClientModules)
                        {
                            _context.EndClientModules.Remove(endClientModule);
                        }
                    }

                    return "Expired";
                }
                var EndClintDtl = await _context.EndClients.FirstOrDefaultAsync(c => c.Id == dbLicenceKey.ClintId);
                var partner = await _context.Partners.FirstOrDefaultAsync(p => p.Id == EndClintDtl.PartnerId);

                //call ClintIdByModulesController and cheak the modules eqlea the serverdata.SoftwareName
                var modules = await _context.EndClientModules.Where(x => x.EndClientId == dbLicenceKey.ClintId).ToListAsync();
                var moduleIds = modules.Select(x => x.ModuleId).ToList();
                var moduleNames = new List<string>();
                foreach (var moduleId in moduleIds)
                {
                    var moduleName = await _context.Modules.FirstOrDefaultAsync(x => x.ModulesId == moduleId);
                    moduleNames.Add(moduleName.Modulename);
                }
                if (!moduleNames.Contains(serverdata.SoftwareName))
                {
                    Console.WriteLine("Don't have access this software");
                   return "Don't have access this software";
                }
                keyLog.LogLicenseKey = serverdata.licenceKey;
                keyLog.ClintId = dbLicenceKey.ClintId;
                keyLog.PartnerId = EndClintDtl.PartnerId;
                keyLog.LogMacAddress = serverdata.macAddress;
                keyLog.LogHostUrl = serverdata.hostUrl;
                keyLog.ClintEmail = EndClintDtl.Email;
                keyLog.ClintName = EndClintDtl.Name;
                keyLog.PartnerEmail = partner.Email;
                keyLog.PartnerName = partner.Name;
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
                    return "Invalid Mac Address";



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
                        return "Invalid Host URL";

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
                                //delete EndClientModules table this client related data
                                var endClientModules = await _context.EndClientModules.Where(x => x.EndClientId == dbLicenceKey.ClintId).ToListAsync();
                                foreach (var endClientModule in endClientModules)
                                {
                                    _context.EndClientModules.Remove(endClientModule);
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e);
                            }
                            return "Expired Key";

                        }
                        else
                        {
                            keyLog.StatusCode = "Valid Loging";
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
                            return "Valid Loging";
                        }

                    }
                }

            }
            

        }




    }
}
