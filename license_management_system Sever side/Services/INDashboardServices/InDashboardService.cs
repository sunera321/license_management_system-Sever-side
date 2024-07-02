using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.INDashboardServices
{
    public class InDashboardService : IInDashboardService
    {
        private readonly DataContext _context;

        public InDashboardService(DataContext context)
        {
            _context = context;
        }

        public async Task<InDashboardDataDto> GetDashboardDataAsync()
        {
            InDashboardDataDto dashboardDataDto = new InDashboardDataDto();

            try
            {
                var totalRevenueParam = new SqlParameter("@TotalRevenue", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var totalUsersParam = new SqlParameter("@TotalUsers", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var totalModulesParam = new SqlParameter("@TotalModules", SqlDbType.Int) { Direction = ParameterDirection.Output };

                await _context.Database.ExecuteSqlRawAsync("EXEC GetDashboardData3 @TotalRevenue OUTPUT, @TotalUsers OUTPUT, @TotalModules OUTPUT",
                    totalRevenueParam, totalUsersParam, totalModulesParam);

                dashboardDataDto.TotalRevenue = (int)totalRevenueParam.Value;
                dashboardDataDto.TotalUsers = (int)totalUsersParam.Value;
                dashboardDataDto.TotalModules = (int)totalModulesParam.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
                throw;
            }

            return dashboardDataDto;
        }

        public async Task<List<ModuleRevenueDto>> GetTop5ModulesByRevenueIn2024Async()
        {
            var topModules = new List<ModuleRevenueDto>();

            await using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetTop5Modules";
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await _context.Database.OpenConnectionAsync();
                await using var result = await command.ExecuteReaderAsync();
                while (await result.ReadAsync())
                {
                    topModules.Add(new ModuleRevenueDto
                    {
                        ModuleName = result["ModuleName"].ToString(),
                        ModulePrice = Convert.ToDecimal(result["ModulePrice"]),
                        NumberOfClients = Convert.ToInt32(result["NumberOfClients"]),
                        TotalRevenue = Convert.ToDecimal(result["TotalRevenue"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving top modules by revenue.", ex);
            }

            return topModules;
        }

        public async Task<List<ModulePriceByYearMonthDto>> GetModulePricesByYearMonthAsync()
        {
            var modulePrices = new List<ModulePriceByYearMonthDto>();

            await using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetModulePricesByYearMonth";
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await _context.Database.OpenConnectionAsync();
                await using var result = await command.ExecuteReaderAsync();
                while (await result.ReadAsync())
                {
                    modulePrices.Add(new ModulePriceByYearMonthDto
                    {
                        Year = Convert.ToInt32(result["Year"]),
                        Month = Convert.ToInt32(result["Month"]),
                        TotalModulePrice = Convert.ToDecimal(result["TotalModulePrice"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving module prices by year and month.", ex);
            }

            return modulePrices;
        }

        public async Task<List<ModuleWiseRevenueDto>> GetModuleRevenue2024Async()
        {
            var moduleRevenueList = new List<ModuleWiseRevenueDto>();

            await using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetModuleRevenue2024";
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await _context.Database.OpenConnectionAsync();
                await using var result = await command.ExecuteReaderAsync();
                while (await result.ReadAsync())
                {
                    moduleRevenueList.Add(new ModuleWiseRevenueDto
                    {
                        ModuleName = result["ModuleName"].ToString(),
                        TotalRevenue = Convert.ToDecimal(result["TotalRevenue"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving module revenue for 2024.", ex);
            }

            return moduleRevenueList;
        }
    }
}
