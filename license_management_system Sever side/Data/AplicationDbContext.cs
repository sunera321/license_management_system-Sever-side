using license_management_system_Sever_side.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace license_management_system_Sever_side.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ClientPanal>ClientPanals { get; set; }
        public DbSet<ClientServer>ClientServers { get; set; }
        public DbSet<ClientServerSiteName>ClientServerSiteNames { get; set; }
        public DbSet<Module>Modules { get; set; }
        public DbSet<user>Users { get; set; }
        public DbSet<licenseKey> licenseKeys { get; set; }
        public DbSet<EndClient> endClients { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerManager> PartnerManagers { get; set; }
        public DbSet<RequestKey> RequestKeys { get; set; }



    }
}
