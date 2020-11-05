﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orgnzr.Data;

namespace Orgnzr.Migrations
{
    [DbContext(typeof(contactContext))]
    [Migration("20201021015512_ProductEntityCreation")]
    partial class ProductEntityCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("restockAmount")
                        .HasColumnType("smallint");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("productID");

                    b.ToTable("Product");
                });
#pragma warning restore 612, 618
        }
    }
}