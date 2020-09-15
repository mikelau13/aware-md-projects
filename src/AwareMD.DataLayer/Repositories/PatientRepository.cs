using AwareMD.EntityLayer.Models;

namespace AwareMD.DataLayer.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository<Patient>
    {
        public PatientRepository(AwareMDDbContext context) : base(context) { }
    }
}
