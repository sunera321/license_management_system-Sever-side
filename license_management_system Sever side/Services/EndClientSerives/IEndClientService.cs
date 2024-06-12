using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.EndClientSerives
{
    public interface IEndClientService
    {
        public Task AddEndClient(AddEndClientDto endClient);
        public Task<IEnumerable<AddEndClientDto>> GetAllEndClients();
        public Task<IEnumerable<ControllPanalClientDto>> GetkeyHasEndClients();
        public Task UpdateEndClient(AddEndClientDto endClient);
        public Task DeleteEndClient(int Id);
        /* public Task UpdateEndClientMackAddress(int Id, string mack, string hostUrl);*/
    }
}