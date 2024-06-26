﻿using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace license_management_system_Sever_side.Services.LicenseKeyServices
{
    public class LicenseKeyServices : ILicenseKeyServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LicenseKeyServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //////////////////////////sunera's part/////////////////////////////////////////////////
        public async Task<string> GenerateLicenseKey(int endClientId, int requestKeyId)
        {
            try
            {
                if (endClientId <= 0 || requestKeyId <= 0)
                {
                    throw new ArgumentException("Invalid client or request key ID");
                }

                var endClient = await _context.EndClients.FirstOrDefaultAsync(e => e.Id == endClientId);
                var requestKey = await _context.RequestKeys.FirstOrDefaultAsync(r => r.RequestID == requestKeyId);

                if (endClient != null && requestKey != null)
                {
                    string email = endClient.Email;
                    string macAddress = endClient.MacAddress;
                    string hostUrl = endClient.HostUrl;
                    string combinedData = email + macAddress + hostUrl;
                    string hashedKey = HashString(combinedData);

                    var license = new License_key
                    {
                      

                        Key_name = hashedKey,
                        ActivationDate = DateTime.Now,
                        DeactivatedDate = DateTime.Now.AddDays(requestKey.NumberOfDays),
                        Key_Status = "Available", // Assuming you want to activate the key upon generation
                        RequestId = requestKey.RequestID,
                        ClintId = endClient.Id,
                        MacAddress = endClient.MacAddress,
                        HostUrl= endClient.HostUrl

                    };
                    var ClintDate= _context.EndClients.FirstOrDefault(x => x.Id == endClientId);
                    ClintDate.ActiveDate = DateTime.Now;
                    ClintDate.ExpireDate = DateTime.Now.AddDays(requestKey.NumberOfDays);
                    _context.EndClients.Update(ClintDate);
                    //check if the key is already generated
                    var key = await _context.License_keys.FirstOrDefaultAsync(l => l.Key_name == hashedKey);
                    if (key == null)
                    {
                        _context.License_keys.Add(license);
                        await _context.SaveChangesAsync();
                        return hashedKey;
                    }
                    else
                    {
                        throw new Exception("License key already generated");
                    }                   
                }
                else
                {
                    throw new KeyNotFoundException("End client or request key not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating license key", ex);
            }
        }

        //delete key
        public async Task DeleteLicenseKey(string key)
        {
            try
            {
                var licenseKey = await _context.License_keys.FirstOrDefaultAsync(l => l.Key_name == key);

                if (licenseKey != null)
                {
                    _context.License_keys.Remove(licenseKey);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("License key not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting license key", ex);
            }

        }

//////////////////////////Himasha's part/////////////////////////////////////////////////
 






        //decode key
        public async Task<string> DecodeLicenseKeyByRequestId(int requestId)
        {
            try
            {
                var licenseKey = await _context.License_keys.FirstOrDefaultAsync(l => l.RequestId == requestId);

                if (licenseKey != null)
                {
                    string decodedKey = DecodeString(licenseKey.Key_name);
                    return decodedKey;
                }
                else
                {
                    throw new KeyNotFoundException("License key not found for the given request ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error decoding license key", ex);
            }
        }

        private string HashString(string input)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            }
            catch (Exception ex)
            {
                throw new Exception("Error hashing string", ex);
            }
        }

        private string DecodeString(string input)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(input));
            }
            catch (Exception ex)
            {
                throw new Exception("Error decoding string", ex);
            }
        }
        public async Task<List<ActivationStatisticDto>> GetActivationStatisticsAsync()
        {
            var query = "SELECT YEAR(activation_date) AS Year, MONTH(activation_date) AS Month, COUNT(*) AS Count  FROM License_keys WHERE key_status = 'Activated' GROUP BY YEAR(activation_date),  MONTH(activation_date) ORDER BY Year, Month;";
            var result = await _context.Set<ActivationStatisticDto>()
                                       .FromSqlRaw(query)
                                       .ToListAsync();
            return result;

        }
        
        public async Task<List<ClientLicenseInfo>> GetClientLicenseInfoAsync()
        {
            var query = " SELECT ec.id  AS Id , ec.name AS Name , ec.email AS Email, lk.activation_date  AS ActivationDate,lk.deactivated_Date AS DeactivatedDate,lk.key_status AS KeyStatus FROM EndClients ec  JOIN license_keys lk ON ec.id = lk.[Clint Id];";
            var result = await _context.Set < ClientLicenseInfo>()
                                       .FromSqlRaw(query)
                                       .ToListAsync();
            return result;
        }
        /* private string HashString(string input)
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
         }*/

    }
}

