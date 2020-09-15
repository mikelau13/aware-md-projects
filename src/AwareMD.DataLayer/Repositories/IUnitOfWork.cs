using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwareMD.DataLayer.Repositories
{
    public interface IUnitOfWork
    {
        IAppointmentRepository<Appointment> Appointments { get; }
        IPatientRepository<Patient> Patients { get; }
        int Complete();
    }
}
