using AwareMD.DataLayer.Repositories;
using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwareMD.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AwareMDDbContext _context;
        public IPatientRepository<Patient> Patients { get; private set; }
        public IAppointmentRepository<Appointment> Appointments { get; private set; }

        public UnitOfWork(AwareMDDbContext context)
        {
            _context = context;

            Patients = new PatientRepository(_context);
            Appointments = new AppointmentRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
