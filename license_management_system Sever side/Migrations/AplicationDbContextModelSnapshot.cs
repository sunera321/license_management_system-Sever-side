﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using license_management_system_Sever_side.Data;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EndClientRequestKey", b =>
                {
                    b.Property<int>("endClientsclientId")
                        .HasColumnType("int");

                    b.Property<int>("requestKeysRequestId")
                        .HasColumnType("int");

                    b.HasKey("endClientsclientId", "requestKeysRequestId");

                    b.HasIndex("requestKeysRequestId");

                    b.ToTable("RequestKeyEndClinet", (string)null);
                });

            modelBuilder.Entity("ModuleRequestKey", b =>
                {
                    b.Property<int>("modulesmoduleId")
                        .HasColumnType("int");

                    b.Property<int>("requestKeysRequestId")
                        .HasColumnType("int");

                    b.HasKey("modulesmoduleId", "requestKeysRequestId");

                    b.HasIndex("requestKeysRequestId");

                    b.ToTable("RequestKeyModules", (string)null);
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.ClientPanal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ActivetDta")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeactivatedDta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientPanals");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.ClientST", b =>
                {
                    b.Property<int>("CID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CID"));

                    b.Property<string>("CName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Finance")
                        .HasColumnType("bit");

                    b.Property<string>("Modules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Partner")
                        .HasColumnType("bit");

                    b.Property<string>("PartnerRequested")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TImePeriod")
                        .HasColumnType("int");

                    b.HasKey("CID");

                    b.ToTable("ClientSTs");

                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.EndClient", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clientId"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MacAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clientId");

                    b.HasIndex("MacAddress")
                        .IsUnique()
                        .HasFilter("[MacAddress] IS NOT NULL");

                    b.HasIndex("PartnerId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Key", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<bool>("BFI")
                        .HasColumnType("bit");

                    b.Property<string>("Hos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MR")
                        .HasColumnType("bit");

                    b.Property<bool>("Retail")
                        .HasColumnType("bit");

                    b.Property<string>("SerMac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValidDate")
                        .HasColumnType("int");

                    b.HasKey("Cid");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Module", b =>
                {
                    b.Property<int>("moduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("moduleId"));

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moduleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moduleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("moduleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.RequestKey", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("CommentFinaceMgt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentPartnerMgt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequiredTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFinanceApproval")
                        .HasColumnType("bit");

                    b.Property<bool>("isPartnerMgrApproval")
                        .HasColumnType("bit");

                    b.HasKey("RequestId");

                    b.HasIndex("PartnerId");

                    b.ToTable("RequestKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.licenseKey", b =>
                {
                    b.Property<int>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeyId"));

                    b.Property<DateTime>("Activetiondate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeactivatedDta")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIssused")
                        .HasColumnType("bit");

                    b.Property<string>("LicenseKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("KeyId");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("licenseKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.user", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.FinaceManager", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.user");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasIndex("RequestId");

                    b.ToTable("FinaceManagers", (string)null);
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Partner", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.user");

                    b.ToTable("Partners", (string)null);
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.PartnerManager", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.user");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasIndex("RequestId");

                    b.ToTable("PartnerManagers", (string)null);
                });

            modelBuilder.Entity("EndClientRequestKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.EndClient", null)
                        .WithMany()
                        .HasForeignKey("endClientsclientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.RequestKey", null)
                        .WithMany()
                        .HasForeignKey("requestKeysRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModuleRequestKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("modulesmoduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.RequestKey", null)
                        .WithMany()
                        .HasForeignKey("requestKeysRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.ClientServerSiteName", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.ClientServer", "ClientServer")
                        .WithMany("SiteNames")
                        .HasForeignKey("MacAddress")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("ClientServer");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.EndClient", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.ClientServer", "clientServer")
                        .WithOne("client")
                        .HasForeignKey("license_management_system_Sever_side.Models.EndClient", "MacAddress")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("license_management_system_Sever_side.Models.Partner", "partner")
                        .WithMany("EndClients")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("clientServer");

                    b.Navigation("partner");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.RequestKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Partner", "partner")
                        .WithMany("RequestKey")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("partner");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.licenseKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.RequestKey", "requestKey")
                        .WithOne("licenseKey")
                        .HasForeignKey("license_management_system_Sever_side.Models.licenseKey", "RequestId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("requestKey");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.FinaceManager", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.RequestKey", "requestKey")
                        .WithMany("finaceManager")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.user", null)
                        .WithOne()
                        .HasForeignKey("license_management_system_Sever_side.Models.FinaceManager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("requestKey");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Partner", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.user", null)
                        .WithOne()
                        .HasForeignKey("license_management_system_Sever_side.Models.Partner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.PartnerManager", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.RequestKey", "requestKey")
                        .WithMany("partnersManager")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.user", null)
                        .WithOne()
                        .HasForeignKey("license_management_system_Sever_side.Models.PartnerManager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("requestKey");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.ClientServer", b =>
                {
                    b.Navigation("SiteNames");

                    b.Navigation("client");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.RequestKey", b =>
                {
                    b.Navigation("finaceManager");

                    b.Navigation("licenseKey")
                        .IsRequired();

                    b.Navigation("partnersManager");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Partner", b =>
                {
                    b.Navigation("EndClients");

                    b.Navigation("RequestKey");
                });
#pragma warning restore 612, 618
        }
    }
}
