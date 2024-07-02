using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using license_management_system_Sever_side.Services.INDashboardServices; // Update this line
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Attributes;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InDashboardController : ControllerBase
    {
        private readonly IInDashboardService _inDashboardService;

        public InDashboardController(IInDashboardService inDashboardService)
        {
            _inDashboardService = inDashboardService;
        }

        [HttpGet("getdashboarddata")]
        public async Task<ActionResult<InDashboardDataDto>> GetDashboardData()
        {
            try
            {
                var dashboardData = await _inDashboardService.GetDashboardDataAsync();
                if (dashboardData == null)
                {
                    return NotFound();
                }
                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [AuthorizeRole("3c5f0eea-412e-4d0a-9fde-849b9d3e5838", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2")]
        [HttpGet("top-modules")]
        public async Task<ActionResult<List<ModuleRevenueDto>>> GetTopModules()
        {
            try
            {
                var topModules = await _inDashboardService.GetTop5ModulesByRevenueIn2024Async();
                if (topModules == null || topModules.Count == 0)
                {
                    return NotFound();
                }
                return Ok(topModules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("module-prices-by-year-month")]
        public async Task<ActionResult<List<ModulePriceByYearMonthDto>>> GetModulePricesByYearMonth()
        {
            try
            {
                var modulePrices = await _inDashboardService.GetModulePricesByYearMonthAsync();
                if (modulePrices == null || modulePrices.Count == 0)
                {
                    return NotFound();
                }
                return Ok(modulePrices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("module-revenue-2024")]
        public async Task<ActionResult<List<ModuleWiseRevenueDto>>> GetModuleRevenue2024()
        {
            try
            {
                var moduleRevenue = await _inDashboardService.GetModuleRevenue2024Async();
                if (moduleRevenue == null || moduleRevenue.Count == 0)
                {
                    return NotFound();
                }
                return Ok(moduleRevenue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
