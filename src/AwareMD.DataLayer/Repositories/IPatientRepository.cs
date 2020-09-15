using AwareMD.EntityLayer.Models;

namespace AwareMD.DataLayer.Repositories
{
    public interface IPatientRepository<T> : IGenericRepository<T>
        where T : class, IPatient
    { }
}
