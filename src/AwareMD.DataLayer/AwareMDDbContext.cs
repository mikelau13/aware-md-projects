using AwareMD.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AwareMD.DataLayer
{
    public class AwareMDDbContext : DbContext
    {
        public AwareMDDbContext(DbContextOptions<AwareMDDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Id)
                .HasName("Index_PatientId");

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => a.Id)
                .HasName("Index_AppointmentId");

            // creating 5 patients
            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient { Id = 1, FirstName = "Patient First 1", LastName = "Patient Last 1", DateOfBirth = new DateTime(1971, 1, 1) },
                    new Patient { Id = 2, FirstName = "Patient First 2", LastName = "Patient Last 2", DateOfBirth = new DateTime(1972, 2, 11) },
                    new Patient { Id = 3, FirstName = "Patient First 3", LastName = "Patient Last 3", DateOfBirth = new DateTime(1973, 3, 21) },
                    new Patient { Id = 4, FirstName = "Patient First 4", LastName = "Patient Last 4", DateOfBirth = new DateTime(1974, 4, 30) },
                    new Patient { Id = 5, FirstName = "Patient First 5", LastName = "Patient Last 5", DateOfBirth = new DateTime(1975, 5, 1) }
                );

            // each list should contain 5 entities
            modelBuilder.Entity<Appointment>()
                .HasData(
                    // Patient 1
                    new Appointment { Id = 1, PatientId = 1, AppointmentTime = new DateTime(2020, 9, 1, 9, 0, 0), Notes = null },
                    new Appointment { Id = 2, PatientId = 1, AppointmentTime = new DateTime(2020, 9, 5, 9, 15, 0), Notes = "notes 02" },
                    new Appointment { Id = 3, PatientId = 1, AppointmentTime = new DateTime(2020, 9, 10, 10, 45, 0), Notes = "notes 03" },
                    new Appointment { Id = 4, PatientId = 1, AppointmentTime = new DateTime(2020, 9, 20, 9, 45, 0), Notes = "notes 04" },
                    new Appointment { Id = 5, PatientId = 1, AppointmentTime = new DateTime(2020, 9, 30, 15, 30, 0), Notes = "notes 05" },
                    
                    // Patient 2
                    new Appointment { Id = 6, PatientId = 2, AppointmentTime = new DateTime(2020, 9, 1, 9, 15, 0), Notes = null },
                    new Appointment { Id = 7, PatientId = 2, AppointmentTime = new DateTime(2020, 9, 5, 9, 30, 0), Notes = "notes 07" },
                    new Appointment { Id = 8, PatientId = 2, AppointmentTime = new DateTime(2020, 9, 10, 11, 0, 0), Notes = "notes 08" },
                    new Appointment { Id = 9, PatientId = 2, AppointmentTime = new DateTime(2020, 9, 20, 10, 0, 0), Notes = "notes 09" },
                    new Appointment { Id = 10, PatientId = 2, AppointmentTime = new DateTime(2020, 9, 30, 15, 45, 0), Notes = "notes 10" },

                    // Patient 3
                    new Appointment { Id = 11, PatientId = 3, AppointmentTime = new DateTime(2020, 9, 2, 9, 15, 0), Notes = null },
                    new Appointment { Id = 12, PatientId = 3, AppointmentTime = new DateTime(2020, 9, 6, 9, 30, 0), Notes = "notes 12" },
                    new Appointment { Id = 13, PatientId = 3, AppointmentTime = new DateTime(2020, 9, 11, 16, 0, 0), Notes = "notes 13" },
                    new Appointment { Id = 14, PatientId = 3, AppointmentTime = new DateTime(2020, 9, 21, 14, 0, 0), Notes = "notes 14" },
                    new Appointment { Id = 15, PatientId = 3, AppointmentTime = new DateTime(2020, 10, 1, 15, 45, 0), Notes = "notes 15" },

                    // Patient 4
                    new Appointment { Id = 16, PatientId = 4, AppointmentTime = new DateTime(2020, 8, 31, 13, 0, 0), Notes = null },
                    new Appointment { Id = 17, PatientId = 4, AppointmentTime = new DateTime(2020, 9, 6, 9, 45, 0), Notes = "notes 17" },
                    new Appointment { Id = 18, PatientId = 4, AppointmentTime = new DateTime(2020, 9, 11, 16, 15, 0), Notes = "notes 18" },
                    new Appointment { Id = 19, PatientId = 4, AppointmentTime = new DateTime(2020, 9, 21, 14, 15, 0), Notes = "notes 19" },
                    new Appointment { Id = 20, PatientId = 4, AppointmentTime = new DateTime(2020, 10, 1, 16, 00, 0), Notes = "notes 20" },

                    // Patient 5
                    new Appointment { Id = 21, PatientId = 5, AppointmentTime = new DateTime(2020, 8, 31, 13, 0, 0), Notes = null },
                    new Appointment { Id = 22, PatientId = 5, AppointmentTime = new DateTime(2020, 9, 6, 9, 45, 0), Notes = "notes 17" },
                    new Appointment { Id = 23, PatientId = 5, AppointmentTime = new DateTime(2020, 9, 13, 09, 0, 0), Notes = "notes 18" },
                    new Appointment { Id = 24, PatientId = 5, AppointmentTime = new DateTime(2020, 9, 21, 14, 30, 0), Notes = "notes 19" },
                    new Appointment { Id = 25, PatientId = 5, AppointmentTime = new DateTime(2020, 10, 1, 16, 15, 0), Notes = "notes 20" }
                );
        }
    }
}
