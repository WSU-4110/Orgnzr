﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orgnzr.Data;

namespace Orgnzr.Migrations
{
    [DbContext(typeof(contactContext))]
    partial class contactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orgnzr.Models.Appointment", b =>
                {
                    b.Property<int>("appointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("appointmentDay")
                        .HasColumnType("int");

                    b.Property<double>("appointmentDuration")
                        .HasColumnType("float");

                    b.Property<int>("appointmentFinishHour")
                        .HasColumnType("int");

                    b.Property<int>("appointmentFinishMinute")
                        .HasColumnType("int");

                    b.Property<int>("appointmentStartHour")
                        .HasColumnType("int");

                    b.Property<int>("appointmentStartMinute")
                        .HasColumnType("int");

                    b.Property<int>("appointmentYear")
                        .HasColumnType("int");

                    b.Property<int>("appoitnmentMonth")
                        .HasColumnType("int");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("appointmentID");

                    b.HasIndex("clientId");

                    b.HasIndex("serviceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Orgnzr.Models.ClientContact", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("preferredContact")
                        .HasColumnType("int");

                    b.HasKey("clientId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Orgnzr.Models.Inventory", b =>
                {
                    b.Property<int>("inventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("inStockAmount")
                        .HasColumnType("smallint");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("restockAmount")
                        .HasColumnType("smallint");

                    b.HasKey("inventoryID");

                    b.HasIndex("productID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Orgnzr.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("buyPrice")
                        .HasColumnType("float");

                    b.Property<short>("inStockAmount")
                        .HasColumnType("smallint");

                    b.Property<string>("productBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("productID1")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("restockAmount")
                        .HasColumnType("smallint");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("productID");

                    b.HasIndex("productID1");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Orgnzr.Models.Services", b =>
                {
                    b.Property<int>("serviceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("serviceCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serviceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Orgnzr.Models.Appointment", b =>
                {
                    b.HasOne("Orgnzr.Models.ClientContact", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orgnzr.Models.Services", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("serviceId");
                });

            modelBuilder.Entity("Orgnzr.Models.Inventory", b =>
                {
                    b.HasOne("Orgnzr.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Orgnzr.Models.Product", b =>
                {
                    b.HasOne("Orgnzr.Models.Product", null)
                        .WithMany("Products")
                        .HasForeignKey("productID1");
                });
#pragma warning restore 612, 618
        }
    }
}
