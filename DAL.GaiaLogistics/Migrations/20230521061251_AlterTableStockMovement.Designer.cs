﻿// <auto-generated />
using System;
using DAL.GaiaLogistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.GaiaLogistics.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230521061251_AlterTableStockMovement")]
    partial class AlterTableStockMovement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.GaiaLogistics.Models.BranchModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("BranchType")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Branches", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.CityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int?>("AreaCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.CountryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("AreaCode")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.ProvinceModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int?>("AreaCode")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.StockMovementItemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("StockMovementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockMovementId");

                    b.ToTable("StockMovementItems", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.StockMovementModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("BranchDestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchOriginId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CauseType")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BranchDestinationId");

                    b.HasIndex("BranchOriginId");

                    b.HasIndex("UserId");

                    b.ToTable("StockMovements", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.BranchModel", b =>
                {
                    b.HasOne("Domain.GaiaLogistics.Models.CityModel", "City")
                        .WithMany("Branches")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.CityModel", b =>
                {
                    b.HasOne("Domain.GaiaLogistics.Models.ProvinceModel", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.ProvinceModel", b =>
                {
                    b.HasOne("Domain.GaiaLogistics.Models.CountryModel", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.StockMovementItemModel", b =>
                {
                    b.HasOne("Domain.GaiaLogistics.Models.ProductModel", "Product")
                        .WithMany("StockMovementItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.GaiaLogistics.Models.StockMovementModel", "StockMovement")
                        .WithMany("StockMovementItems")
                        .HasForeignKey("StockMovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StockMovement");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.StockMovementModel", b =>
                {
                    b.HasOne("Domain.GaiaLogistics.Models.BranchModel", "BranchDestination")
                        .WithMany("DestinationStockMovements")
                        .HasForeignKey("BranchDestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.GaiaLogistics.Models.BranchModel", "BranchOrigin")
                        .WithMany("OriginStockMovements")
                        .HasForeignKey("BranchOriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.GaiaLogistics.Models.UserModel", "User")
                        .WithMany("StockMovements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchDestination");

                    b.Navigation("BranchOrigin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.BranchModel", b =>
                {
                    b.Navigation("DestinationStockMovements");

                    b.Navigation("OriginStockMovements");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.CityModel", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.CountryModel", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.ProductModel", b =>
                {
                    b.Navigation("StockMovementItems");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.ProvinceModel", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.StockMovementModel", b =>
                {
                    b.Navigation("StockMovementItems");
                });

            modelBuilder.Entity("Domain.GaiaLogistics.Models.UserModel", b =>
                {
                    b.Navigation("StockMovements");
                });
#pragma warning restore 612, 618
        }
    }
}
