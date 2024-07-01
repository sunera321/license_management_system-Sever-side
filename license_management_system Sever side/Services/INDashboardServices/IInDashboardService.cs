using System.Collections.Generic;
using System.Threading.Tasks;
using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.INDashboardServices
{
    public interface IInDashboardService
    {
        Task<InDashboardDataDto> GetDashboardDataAsync();
        Task<List<ModuleRevenueDto>> GetTop5ModulesByRevenueIn2024Async();
        Task<List<ModulePriceByYearMonthDto>> GetModulePricesByYearMonthAsync();
        Task<List<ModuleWiseRevenueDto>> GetModuleRevenue2024Async();
    }
}
