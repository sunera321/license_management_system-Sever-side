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
            licenseKeyEntity.DeactivatedDate = licenseKeyEntity.ActivationDate.AddMonths(6);
            licenseKeyEntity.Key_Status = "Available";
            await _context.License_keys.AddAsync(licenseKeyEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<License_keyDto>> GetAllLicenseKeys()
        {
            var licenseKeys = await _context.License_keys.ToListAsync();
            return _mapper.Map<IEnumerable<License_keyDto>>(licenseKeys);
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
