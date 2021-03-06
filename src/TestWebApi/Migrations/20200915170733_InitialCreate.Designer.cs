﻿// <auto-generated />
using System;
using AwareMD.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TestWebApi.Migrations
{
    [DbContext(typeof(AwareMDDbContext))]
    [Migration("20200915170733_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("AwareMD.EntityLayer.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Index_AppointmentId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentTime = new DateTime(2020, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentTime = new DateTime(2020, 9, 5, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 02",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 3,
                            AppointmentTime = new DateTime(2020, 9, 10, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 03",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentTime = new DateTime(2020, 9, 20, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 04",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 5,
                            AppointmentTime = new DateTime(2020, 9, 30, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 05",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 6,
                            AppointmentTime = new DateTime(2020, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 2
                        },
                        new
                        {
                            Id = 7,
                            AppointmentTime = new DateTime(2020, 9, 5, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 07",
                            PatientId = 2
                        },
                        new
                        {
                            Id = 8,
                            AppointmentTime = new DateTime(2020, 9, 10, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 08",
                            PatientId = 2
                        },
                        new
                        {
                            Id = 9,
                            AppointmentTime = new DateTime(2020, 9, 20, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 09",
                            PatientId = 2
                        },
                        new
                        {
                            Id = 10,
                            AppointmentTime = new DateTime(2020, 9, 30, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 10",
                            PatientId = 2
                        },
                        new
                        {
                            Id = 11,
                            AppointmentTime = new DateTime(2020, 9, 2, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 3
                        },
                        new
                        {
                            Id = 12,
                            AppointmentTime = new DateTime(2020, 9, 6, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 12",
                            PatientId = 3
                        },
                        new
                        {
                            Id = 13,
                            AppointmentTime = new DateTime(2020, 9, 11, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 13",
                            PatientId = 3
                        },
                        new
                        {
                            Id = 14,
                            AppointmentTime = new DateTime(2020, 9, 21, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 14",
                            PatientId = 3
                        },
                        new
                        {
                            Id = 15,
                            AppointmentTime = new DateTime(2020, 10, 1, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 15",
                            PatientId = 3
                        },
                        new
                        {
                            Id = 16,
                            AppointmentTime = new DateTime(2020, 8, 31, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 4
                        },
                        new
                        {
                            Id = 17,
                            AppointmentTime = new DateTime(2020, 9, 6, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 17",
                            PatientId = 4
                        },
                        new
                        {
                            Id = 18,
                            AppointmentTime = new DateTime(2020, 9, 11, 16, 15, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 18",
                            PatientId = 4
                        },
                        new
                        {
                            Id = 19,
                            AppointmentTime = new DateTime(2020, 9, 21, 14, 15, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 19",
                            PatientId = 4
                        },
                        new
                        {
                            Id = 20,
                            AppointmentTime = new DateTime(2020, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 20",
                            PatientId = 4
                        },
                        new
                        {
                            Id = 21,
                            AppointmentTime = new DateTime(2020, 8, 31, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 5
                        },
                        new
                        {
                            Id = 22,
                            AppointmentTime = new DateTime(2020, 9, 6, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 17",
                            PatientId = 5
                        },
                        new
                        {
                            Id = 23,
                            AppointmentTime = new DateTime(2020, 9, 13, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 18",
                            PatientId = 5
                        },
                        new
                        {
                            Id = 24,
                            AppointmentTime = new DateTime(2020, 9, 21, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 19",
                            PatientId = 5
                        },
                        new
                        {
                            Id = 25,
                            AppointmentTime = new DateTime(2020, 10, 1, 16, 15, 0, 0, DateTimeKind.Unspecified),
                            Notes = "notes 20",
                            PatientId = 5
                        });
                });

            modelBuilder.Entity("AwareMD.EntityLayer.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Index_PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1971, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Patient First 1",
                            LastName = "Patient Last 1"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1972, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Patient First 2",
                            LastName = "Patient Last 2"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1973, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Patient First 3",
                            LastName = "Patient Last 3"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1974, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Patient First 4",
                            LastName = "Patient Last 4"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1975, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Patient First 5",
                            LastName = "Patient Last 5"
                        });
                });

            modelBuilder.Entity("AwareMD.EntityLayer.Models.Appointment", b =>
                {
                    b.HasOne("AwareMD.EntityLayer.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
