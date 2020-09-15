using AwareMD.EntityLayer.Models;

namespace AwareMD.DataLayer.Repositories
{
    public interface IAppointmentRepository<T> : IGenericRepository<T>
        where T : class, IAppointment
    { }
}
