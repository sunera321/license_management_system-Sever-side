using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.LicenseKeyServices
{
    public interface ILicenseKeyServices
    {
     
        public Task DeleteLicenseKey(string key);

        public Task<string> GenerateLicenseKey(int endClientId, int requestKeyId);
        public Task<string> DecodeLicenseKeyByRequestId(int requestId);

       public Task<List<ActivationStatisticDto>> GetActivationStatisticsAsync();

        public Task<List<ClientLicenseInfo>> GetClientLicenseInfoAsync();
    }

}
