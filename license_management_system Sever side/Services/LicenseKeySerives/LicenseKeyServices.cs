using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task AddLicenseKey(License_keyDto licenseKey)
        {
            var licenseKeyEntity = _mapper.Map<License_key>(licenseKey);
            licenseKeyEntity.Key_Status = "Available";
            await _context.License_keys.AddAsync(licenseKeyEntity);
           

            // Fetch the NumberOfDays from RequestKey table
            var requestKey = await _context.RequestKeys
                .FirstOrDefaultAsync(r => r.RequestID == licenseKeyEntity.RequestId);

            //Console.WriteLine(requestKey.NumberOfDays);
            licenseKeyEntity.DeactivatedDate = licenseKeyEntity.ActivationDate.AddDays(requestKey.NumberOfDays);

            Console.WriteLine(licenseKeyEntity.DeactivatedDate);
            await _context.SaveChangesAsync();
        }

        //delete key
        public async Task DeleteLicenseKey(string key)
        {
            var licenseKey = await _context.License_keys.FirstOrDefaultAsync(l => l.Key_name == key);
            _context.License_keys.Remove(licenseKey);
            await _context.SaveChangesAsync();
        }

    }
}
