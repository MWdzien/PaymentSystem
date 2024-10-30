﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentSystem.Context;

#nullable disable

namespace PaymentSystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241030200608_AddedRenewalRowInSubscriptionTable")]
    partial class AddedRenewalRowInSubscriptionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaymentSystem.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KrsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Address = "Wrzosowa 1",
                            ClientType = 0,
                            Email = "jankowalski@gmail.com",
                            FirstName = "Jan",
                            IsDeleted = false,
                            LastName = "Kowalski",
                            Pesel = "01010101010",
                            PhoneNumber = "511111111"
                        },
                        new
                        {
                            ClientId = 2,
                            Address = "Różana 3",
                            ClientType = 1,
                            CompanyName = "Firma1",
                            Email = "firma1@op.pl",
                            KrsNumber = "1111111111",
                            PhoneNumber = "000000000"
                        });
                });

            modelBuilder.Entity("PaymentSystem.Models.ContractModels.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("bit");

                    b.Property<int>("MaintenanceYears")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            ContractId = 1,
                            ClientId = 1,
                            DateFrom = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExpired = true,
                            IsSigned = false,
                            MaintenanceYears = 3,
                            Price = 0m,
                            SoftwareId = 1
                        });
                });

            modelBuilder.Entity("PaymentSystem.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("ContractId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaymentSystem.Models.ProductModels.Software", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoftwareId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CurrentVersion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SoftwareId");

                    b.ToTable("Softwares");

                    b.HasData(
                        new
                        {
                            SoftwareId = 1,
                            Category = "Business",
                            CurrentVersion = "1.0",
                            Description = "Description descriptiopn descritortopn",
                            Name = "Software1",
                            Price = 10000m
                        });
                });

            modelBuilder.Entity("PaymentSystem.Models.ProductModels.SoftwareDiscount", b =>
                {
                    b.Property<int>("SoftwareDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoftwareDiscountId"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("DiscountRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.HasKey("SoftwareDiscountId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("SoftwareDiscount");
                });

            modelBuilder.Entity("PaymentSystem.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RenewalPeriodMonths")
                        .HasColumnType("int");

                    b.Property<int>("Renewals")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("ClientId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("PaymentSystem.Models.ContractModels.Contract", b =>
                {
                    b.HasOne("PaymentSystem.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentSystem.Models.ProductModels.Software", "Software")
                        .WithMany()
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Software");
                });

            modelBuilder.Entity("PaymentSystem.Models.Payment", b =>
                {
                    b.HasOne("PaymentSystem.Models.ContractModels.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("PaymentSystem.Models.ProductModels.SoftwareDiscount", b =>
                {
                    b.HasOne("PaymentSystem.Models.ProductModels.Software", "Software")
                        .WithMany("SoftwareDiscounts")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Software");
                });

            modelBuilder.Entity("PaymentSystem.Models.Subscription", b =>
                {
                    b.HasOne("PaymentSystem.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PaymentSystem.Models.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("PaymentSystem.Models.ProductModels.Software", b =>
                {
                    b.Navigation("SoftwareDiscounts");
                });
#pragma warning restore 612, 618
        }
    }
}
