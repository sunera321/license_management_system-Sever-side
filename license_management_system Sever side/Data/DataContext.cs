using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;



namespace license_management_system_Sever_side.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PartnerManager> PartnerManagers { get; set; }
        public DbSet<FinaceManager> FinaceManagers { get; set; }

        public DbSet<Modules> Modules { get; set; }
        public DbSet<RequestKey> RequestKeys { get; set; }
        public DbSet<EndClient> EndClients { get; set; }
        public DbSet<Partner> Partners { get; set; }


        public DbSet<License_key> License_keys { get; set; }

        public DbSet<Loging_Validetion> Loging_Validetion { get; set; }
        public DbSet<ClientServerInfo> ClientServerInfos { get; set; }
        public DbSet<ClientServerSiteName> ClientServerSiteNames { get; set; }
        public DbSet<EndClientModule> EndClientModules { get; set; }









        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License_key>()
               .HasOne(lk => lk.RequestKey)
               .WithOne(rk => rk.License_key)
               .HasForeignKey<License_key>(lk => lk.RequestId);



            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<EndClientModule>()
                .HasKey(ecm => new { ecm.EndClientId, ecm.ModuleId });

            modelBuilder.Entity<EndClientModule>()
                .HasOne(ecm => ecm.EndClient)
                .WithMany(ec => ec.EndClientModules)
                .HasForeignKey(ecm => ecm.EndClientId);

            modelBuilder.Entity<EndClientModule>()
                .HasOne(ecm => ecm.Module)
                .WithMany(m => m.EndClientModules)
                .HasForeignKey(ecm => ecm.ModuleId);

        }
        // Method to execute stored procedure and map to DashboardDataDto
        public async Task<InDashboardDataDto> GetDashboardDataAsync()
        {
            InDashboardDataDto dashboardDataDto = new InDashboardDataDto();

            try
            {
                // Create SqlParameter instances with simplified 'new' expression
                var totalRevenueParam = new SqlParameter("@TotalRevenue", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var totalUsersParam = new SqlParameter("@TotalUsers", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var totalModulesParam = new SqlParameter("@TotalModules", SqlDbType.Int) { Direction = ParameterDirection.Output };

                // Execute stored procedure using raw SQL with output parameters
                await Database.ExecuteSqlRawAsync("EXEC GetDashboardData3 @TotalRevenue OUTPUT, @TotalUsers OUTPUT, @TotalModules OUTPUT",
                    totalRevenueParam, totalUsersParam, totalModulesParam);

                // Map output parameter values to DashboardDataDto
                dashboardDataDto.TotalRevenue = (int)totalRevenueParam.Value;
                dashboardDataDto.TotalUsers = (int)totalUsersParam.Value;
                dashboardDataDto.TotalModules = (int)totalModulesParam.Value;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
                throw; // Rethrow the exception to propagate it to the caller
            }

            return dashboardDataDto;
        }
        public async Task<List<ModuleRevenueDto>> GetTop5ModulesByRevenueIn2024Async()
        {
            var topModules = new List<ModuleRevenueDto>();

            await using var command = Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetTop5Modules"; // Stored procedure name
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await Database.OpenConnectionAsync();
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
                // Handle exception (logging, rethrowing, etc.)
                throw new Exception("Error while retrieving top modules by revenue.", ex);
            }

            return topModules;
        }
        public async Task<List<ModulePriceByYearMonthDto>> GetModulePricesByYearMonthAsync()
        {
            var modulePrices = new List<ModulePriceByYearMonthDto>();

            await using var command = Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetModulePricesByYearMonth"; // Stored procedure name
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await Database.OpenConnectionAsync();
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
                // Handle exception (logging, rethrowing, etc.)
                throw new Exception("Error while retrieving module prices by year and month.", ex);
            }

            return modulePrices;
        }


        public async Task<List<ModuleWiseRevenueDto>> GetModuleRevenue2024Async()
        {
            var moduleRevenueList = new List<ModuleWiseRevenueDto>();

            await using var command = Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetModuleRevenue2024";
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await Database.OpenConnectionAsync();
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
                // Handle exception (logging, rethrowing, etc.)
                throw new Exception("Error while retrieving module revenue for 2024.", ex);
            }

            return moduleRevenueList;
        }
    }



}
