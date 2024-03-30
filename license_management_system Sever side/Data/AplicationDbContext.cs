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
        public DbSet<EndClient>Clients { get; set; }
        public DbSet<licenseKey> licenseKeys { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<RequestKey> RequestKeys { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerManager> PartnerManagers { get; set; }
        public DbSet<FinaceManager> FinaceManagers { get; set; }
        public DbSet<ClientServer> ClientServers { get; set; }
        public DbSet<ClientServerSiteName> ClientServerSiteNames { get; set; }


        public DbSet<ClientST> ClientSTs { get; set; }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>().ToTable("Partners");
            modelBuilder.Entity<FinaceManager>().ToTable("FinaceManagers");
            modelBuilder.Entity<PartnerManager>().ToTable("PartnerManagers");

            modelBuilder.Entity<RequestKey>(entity =>
            {
                entity.HasMany(e => e.modules).WithMany(e => e.requestKeys).UsingEntity(e => e.ToTable("RequestKeyModules"));
                entity.HasMany(e => e.endClients).WithMany(e => e.requestKeys).UsingEntity(e => e.ToTable("RequestKeyEndClinet"));
                entity.HasMany(e => e.finaceManager).WithOne(e => e.requestKey).HasForeignKey(e => e.RequestId).OnDelete(DeleteBehavior.ClientCascade);
                entity.HasMany(e => e.partnersManager).WithOne(e => e.requestKey).HasForeignKey(e => e.RequestId).OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(e => e.licenseKey).WithOne(e => e.requestKey).HasForeignKey<licenseKey>(e => e.RequestId).OnDelete(DeleteBehavior.ClientCascade);

            });
            
            modelBuilder.Entity<ClientServer>(entity =>
            {
                entity.HasMany(e => e.SiteNames).WithOne(e => e.ClientServer).HasForeignKey(e => e.MacAddress).OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(e => e.client).WithOne(e => e.clientServer).HasForeignKey<EndClient>(e => e.MacAddress).OnDelete(DeleteBehavior.ClientCascade);
            });  
                entity.HasMany(e => e.EndClients).WithOne(e => e.partner).HasForeignKey(e => e.PartnerId).OnDelete(DeleteBehavior.ClientCascade);
                entity.HasMany(e => e.RequestKey).WithOne(e => e.partner).HasForeignKey(e => e.PartnerId).OnDelete(DeleteBehavior.ClientCascade);

            });
         
        }


    }
}
