﻿// <auto-generated />
using System;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppInfraDbSqlServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250112195442_add")]
    partial class add
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppDomainCore.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarEnum")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarEnum = 1,
                            Model = "206 تیپ2"
                        },
                        new
                        {
                            Id = 2,
                            CarEnum = 1,
                            Model = "206 تیپ5"
                        },
                        new
                        {
                            Id = 3,
                            CarEnum = 1,
                            Model = "پارس"
                        },
                        new
                        {
                            Id = 4,
                            CarEnum = 1,
                            Model = "405 slx"
                        },
                        new
                        {
                            Id = 5,
                            CarEnum = 1,
                            Model = "تارا"
                        },
                        new
                        {
                            Id = 6,
                            CarEnum = 1,
                            Model = "دنا"
                        },
                        new
                        {
                            Id = 7,
                            CarEnum = 1,
                            Model = "رانا"
                        },
                        new
                        {
                            Id = 8,
                            CarEnum = 1,
                            Model = "207"
                        },
                        new
                        {
                            Id = 9,
                            CarEnum = 2,
                            Model = "پراید 111"
                        },
                        new
                        {
                            Id = 10,
                            CarEnum = 2,
                            Model = "پراید 131"
                        },
                        new
                        {
                            Id = 11,
                            CarEnum = 2,
                            Model = "کوییک"
                        },
                        new
                        {
                            Id = 12,
                            CarEnum = 2,
                            Model = "کوییک ار"
                        },
                        new
                        {
                            Id = 13,
                            CarEnum = 2,
                            Model = "کوییک اس"
                        },
                        new
                        {
                            Id = 14,
                            CarEnum = 2,
                            Model = "کوییک جی ایکس"
                        },
                        new
                        {
                            Id = 15,
                            CarEnum = 2,
                            Model = "ساینا"
                        },
                        new
                        {
                            Id = 16,
                            CarEnum = 2,
                            Model = "ساینا اس"
                        },
                        new
                        {
                            Id = 17,
                            CarEnum = 2,
                            Model = "شاهین"
                        });
                });

            modelBuilder.Entity("AppDomainCore.Entities.OldCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TechnicalExaminationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TechnicalExaminationId")
                        .IsUnique();

                    b.ToTable("OldCarsCars");
                });

            modelBuilder.Entity("AppDomainCore.Entities.TechnicalExamination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CarLicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("YearProduction")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("TechnicalExaminations");
                });

            modelBuilder.Entity("AppDomainCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "12345@",
                            Phone = "09913466961",
                            Role = 1,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "12345@",
                            Phone = "03103905561",
                            Role = 1,
                            UserName = "Admin2"
                        },
                        new
                        {
                            Id = 3,
                            Password = "12345@",
                            Phone = "03103905561",
                            Role = 1,
                            UserName = "User"
                        },
                        new
                        {
                            Id = 4,
                            Password = "12345@",
                            Phone = "03103905561",
                            Role = 1,
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("AppDomainCore.Entities.OldCar", b =>
                {
                    b.HasOne("AppDomainCore.Entities.TechnicalExamination", "TechnicalExamination")
                        .WithOne("OldCar")
                        .HasForeignKey("AppDomainCore.Entities.OldCar", "TechnicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TechnicalExamination");
                });

            modelBuilder.Entity("AppDomainCore.Entities.TechnicalExamination", b =>
                {
                    b.HasOne("AppDomainCore.Entities.Car", "Car")
                        .WithMany("TechnicalExamination")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AppDomainCore.Entities.Car", b =>
                {
                    b.Navigation("TechnicalExamination");
                });

            modelBuilder.Entity("AppDomainCore.Entities.TechnicalExamination", b =>
                {
                    b.Navigation("OldCar");
                });
#pragma warning restore 612, 618
        }
    }
}
