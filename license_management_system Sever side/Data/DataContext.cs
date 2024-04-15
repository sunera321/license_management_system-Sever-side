using Microsoft.EntityFrameworkCore;
using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Data
{
    public class DataContext:DbContext
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

        public DbSet<ClientServerInfo> ClientServerInfos { get; set; }
        public DbSet<ClientServerSiteName> ClientServerSiteNames { get; set;}






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License_key>()
               .HasOne(lk => lk.RequestKey)
               .WithOne(rk => rk.License_key)
               .HasForeignKey<License_key>(lk => lk.RequestId);
        }

     
    }
}
