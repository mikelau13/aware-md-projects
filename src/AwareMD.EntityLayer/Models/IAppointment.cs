using System;

namespace AwareMD.EntityLayer.Models
{
    public interface IAppointment
    {
        int Id { get; }
        int PatientId { get; }
        DateTime AppointmentTime { get; }
        string Notes { get; }
    }
}
