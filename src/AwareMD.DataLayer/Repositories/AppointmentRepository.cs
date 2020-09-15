using AwareMD.EntityLayer.Models;


namespace AwareMD.DataLayer.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository<Appointment>
    {
        public AppointmentRepository(AwareMDDbContext context) : base(context) { }
    }
}
