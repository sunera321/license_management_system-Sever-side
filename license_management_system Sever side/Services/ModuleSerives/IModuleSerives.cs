using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.ModuleSerives
{
    public interface IModuleSerives
    {
        public Task AddModule(ModuleDto AddModule);
        public Task<IEnumerable<ModuleDto>> GetAllModule();

        public Task UpdateModule(ModuleDto AddModule);
        public Task<List<ModuleStatisticDTO>> GetModuleStatistics(); //for the dashboard 
    }
}
