using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.EndClientSerives
{
    public interface IEndClientService
    {
        public Task AddEndClient(AddEndClientDto endClient);
    }
}
