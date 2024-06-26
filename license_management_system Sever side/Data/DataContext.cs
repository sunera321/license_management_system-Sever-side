﻿using Microsoft.EntityFrameworkCore;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Models.DTOs;

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

        public DbSet<Loging_Validetion> Loging_Validetion { get; set; }
        public DbSet<ClientServerInfo> ClientServerInfos { get; set; }
        public DbSet<ClientServerSiteName> ClientServerSiteNames { get; set;}
        public DbSet<EndClientModule> EndClientModules { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<ModuleStatisticDTO> ModuleStatistics { get; set; }
        public DbSet<ActivationStatisticDto> ActivationStatistics { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<ClientLicenseInfo> ClientLicenseInfos { get; set; }


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
                modelBuilder.Entity<User>()
                    .HasIndex(u => u.UserId)
                    .IsUnique();

            // Configure ModuleStatisticDTO  and ActivationStatisticDto as a keyless entity
            modelBuilder.Entity<ModuleStatisticDTO>().HasNoKey();

            modelBuilder.Entity<ActivationStatisticDto>().HasNoKey().ToView(null);

            modelBuilder.Entity<ClientLicenseInfo>().HasNoKey();


        }




    }
}
