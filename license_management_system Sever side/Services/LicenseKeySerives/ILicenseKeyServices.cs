using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.LicenseKeyServices
{
    public interface ILicenseKeyServices
    {
        public Task AddLicenseKey(License_keyDto licenseKey);
        public Task DeleteLicenseKey(string key);
       
    }
}
