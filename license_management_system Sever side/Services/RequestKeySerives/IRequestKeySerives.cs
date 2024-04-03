using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.RequestKeySerives
{
    public interface IRequestKeySerives
    {
        public Task AddRequestKey(RequestKeyDto requestKey);
        public Task<IEnumerable<RequestKeyDto>> GetAllrequestkeys();
    }
}
