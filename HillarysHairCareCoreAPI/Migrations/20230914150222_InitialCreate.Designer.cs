﻿// <auto-generated />
using System;
using HillarysHairCareCoreAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCareCoreAPI.Migrations
{
    [DbContext(typeof(HillarysHairCareDbContext))]
    [Migration("20230914150222_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Date = new DateTime(2023, 9, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCanceled = false,
                            IsCompleted = false,
                            StylistId = 3
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 4,
                            Date = new DateTime(2023, 9, 16, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCanceled = false,
                            IsCompleted = false,
                            StylistId = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 5,
                            Date = new DateTime(2023, 9, 16, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCanceled = false,
                            IsCompleted = false,
                            StylistId = 2
                        });
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 3,
                            ServiceId = 5
                        });
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Zephyr",
                            LastName = "Evergreen"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Seraphina",
                            LastName = "Nightshade"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Orion",
                            LastName = "Thunderstruck"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Azura",
                            LastName = "Starfall"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Caspian",
                            LastName = "Moonshadow"
                        });
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 50.00m,
                            Name = "Haircut - Long"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 40.00m,
                            Name = "Haircut - Short"
                        },
                        new
                        {
                            Id = 3,
                            Cost = 35.00m,
                            Name = "Shampoo and Blowout"
                        },
                        new
                        {
                            Id = 4,
                            Cost = 65.00m,
                            Name = "Hair Color - Single Process"
                        },
                        new
                        {
                            Id = 5,
                            Cost = 35.00m,
                            Name = "Bread Trim"
                        });
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "George",
                            IsActive = true,
                            LastName = "Hamilton"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Alex",
                            IsActive = true,
                            LastName = "Jefferson"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Bill",
                            IsActive = true,
                            LastName = "Kennedy"
                        });
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Appointment", b =>
                {
                    b.HasOne("HillarysHairCareCoreAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCareCoreAPI.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.AppointmentService", b =>
                {
                    b.HasOne("HillarysHairCareCoreAPI.Models.Appointment", null)
                        .WithMany("AppointmentServices")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HillarysHairCareCoreAPI.Models.Appointment", b =>
                {
                    b.Navigation("AppointmentServices");
                });
#pragma warning restore 612, 618
        }
    }
}
