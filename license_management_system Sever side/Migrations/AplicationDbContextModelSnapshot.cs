﻿// <auto-generated />
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

            modelBuilder.Entity("license_management_system_Sever_side.Models.Key", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<bool>("BFI")
                        .HasColumnType("bit");

                    b.Property<string>("ClientID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MR")
                        .HasColumnType("bit");

                    b.Property<string>("ModulesJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Retail")
                        .HasColumnType("bit");

                    b.Property<string>("SerMac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValidDate")
                        .HasColumnType("int");

                    b.HasKey("Cid");

                    b.ToTable("Keys");
                });
#pragma warning restore 612, 618
        }
    }
}
