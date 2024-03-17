﻿// <auto-generated />
using System;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations.Activate
{
    [DbContext(typeof(ActivateContext))]
    partial class ActivateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Model.Activate", b =>
                {
                    b.Property<int>("LID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LID"), 1L, 1);

                    b.Property<int>("CID")
                        .HasColumnType("int");

                    b.Property<int>("HsenidPartner")
                        .HasColumnType("int");

                    b.Property<int>("HsenidUser")
                        .HasColumnType("int");

                    b.HasKey("LID");

                    b.HasIndex("CID");

                    b.ToTable("Activate");
                });

            modelBuilder.Entity("API.Model.LicenseKey", b =>
                {
                    b.Property<int>("CID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CID"), 1L, 1);

                    b.Property<string>("HostURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerMacAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidDateUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("CID");

                    b.ToTable("LicenseKey");
                });

            modelBuilder.Entity("API.Model.Activate", b =>
                {
                    b.HasOne("API.Model.LicenseKey", "LicenseKey")
                        .WithMany()
                        .HasForeignKey("CID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicenseKey");
                });
#pragma warning restore 612, 618
        }
    }
}
