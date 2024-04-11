using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Services.PartnerSerives
{
    public interface IPartnerSerives
    {
        public Task AddPartner(Partner partner);
        public Task<IEnumerable<Partner>> GetAllPartners();

        public Task DeletePartner(int id);
    }
}
